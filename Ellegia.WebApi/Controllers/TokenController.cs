using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Core;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Ellegia.WebApi.Controllers
{
    [Route(Routes.TokenEndpoint)]
    public class TokenController : Controller
    {
        private readonly SignInManager<EllegiaUser> _signInManager;
        private readonly UserManager<EllegiaUser> _userManager;
        //private readonly IConfigurationRoot _configuration;

        public TokenController(
            SignInManager<EllegiaUser> signInManager,
            UserManager<EllegiaUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Generate([FromBody] OpenIdConnectRequest request)
        {
            if (!request.IsPasswordGrantType())
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    ErrorDescription = "The specified grant type is not supported."
                });

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = "The username/password couple is invalid."
                });
            }

            // Ensure the user is allowed to sign in.
            if (!await _signInManager.CanSignInAsync(user))
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = "The specified user is not allowed to sign in."
                });
            }

            // Reject the token request if two-factor authentication has been enabled by the user.
            if (_userManager.SupportsUserTwoFactor && await _userManager.GetTwoFactorEnabledAsync(user))
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = "The specified user is not allowed to sign in."
                });
            }

            // Ensure the user is not already locked out.
            if (_userManager.SupportsUserLockout && await _userManager.IsLockedOutAsync(user))
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = "The username/password couple is invalid."
                });
            }

            // Ensure the password is valid.
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                if (_userManager.SupportsUserLockout)
                {
                    await _userManager.AccessFailedAsync(user);
                }

                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = "The username/password couple is invalid."
                });
            }

            if (_userManager.SupportsUserLockout)
            {
                await _userManager.ResetAccessFailedCountAsync(user);
            }

            // Create a new authentication ticket.
            var ticket = await CreateTicketAsync(request, user);

            return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
        }

        private async Task<AuthenticationTicket> CreateTicketAsync(OpenIdConnectRequest request, EllegiaUser user)
        {
            var principal = await _signInManager.CreateUserPrincipalAsync(user);

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(OpenIdConnectConstants.Destinations.AccessToken,
                                      OpenIdConnectConstants.Destinations.IdentityToken);
            }

            var ticket = new AuthenticationTicket(
                principal, new AuthenticationProperties(),
                OpenIdConnectServerDefaults.AuthenticationScheme);

            ticket.SetScopes(new[] {
                OpenIdConnectConstants.Scopes.OpenId,
                OpenIdConnectConstants.Scopes.Email,
                OpenIdConnectConstants.Scopes.Profile,
                OpenIddictConstants.Scopes.Roles
            }.Intersect(request.GetScopes()));

            return ticket;
        }
    }
}
