(window.webpackJsonp=window.webpackJsonp||[]).push([[9],{"3247a221d3b0808c8435":function(e,t,n){"use strict";n.r(t);var r,c=n("8af190b70a6bc55c6f1b"),a=n.n(c),o=(n("8a2d1b95e05b6a321e74"),n("d7dd51e1bf6bfc2c9c3d")),u=n("ab4cb61bcb2dc161defb"),i=n("ab039aecd4a1d4fedc0e"),f=n("adc20f99e57c573c589c"),s=n("bd67310ccfbbd9399274"),b=n("c04b6bf001e7257e27d8"),d=Object(i.defineMessages)({header:{id:"app.components.ManageCustomerPage.header",defaultMessage:"Customer form"},customerName:{id:"app.components.ManageCustomerPage.customerName",defaultMessage:"Customer name"},save:{id:"app.components.ManageCustomerPage.save",defaultMessage:"Save"}}),l=n("edc5ec6b13db97ea0a32"),p=n("3896c6a36d5a1023e179"),m=n("bbeaf91f6834df5f1f31"),v=(r="function"==typeof Symbol&&Symbol.for&&Symbol.for("react.element")||60103,function(e,t,n,c){var a=e&&e.defaultProps,o=arguments.length-3;if(t||0===o||(t={}),t&&a)for(var u in a)void 0===t[u]&&(t[u]=a[u]);else t||(t=a||{});if(1===o)t.children=c;else if(o>1){for(var i=Array(o),f=0;f<o;f++)i[f]=arguments[f+3];t.children=i}return{$$typeof:r,type:e,key:void 0===n?null:""+n,ref:null,props:t,_owner:null}}),y=Object(l.reduxForm)({form:"customerForm",validate:function(e){var t={};return["name"].forEach(function(n){e.get(n)||(t[n]="Обязательное поле")}),t}})(function(e){var t=e.handleSubmit;return v("form",{onSubmit:t},void 0,v("div",{},void 0,v(p.a,{name:"name",label:a.a.createElement(i.FormattedMessage,d.customerName)})),v("div",{},void 0,v(m.a,{label:a.a.createElement(i.FormattedMessage,d.save)})))});n.d(t,"mapDispatchToProps",function(){return O});var j=function(){var e="function"==typeof Symbol&&Symbol.for&&Symbol.for("react.element")||60103;return function(t,n,r,c){var a=t&&t.defaultProps,o=arguments.length-3;if(n||0===o||(n={}),n&&a)for(var u in a)void 0===n[u]&&(n[u]=a[u]);else n||(n=a||{});if(1===o)n.children=c;else if(o>1){for(var i=Array(o),f=0;f<o;f++)i[f]=arguments[f+3];n.children=i}return{$$typeof:e,type:t,key:void 0===r?null:""+r,ref:null,props:n,_owner:null}}}(),g=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}();var h=function(e){function t(){return function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,t),function(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}(this,(t.__proto__||Object.getPrototypeOf(t)).apply(this,arguments))}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(t,a.a.PureComponent),g(t,[{key:"render",value:function(){return j("div",{},void 0,j("h1",{},void 0,a.a.createElement(i.FormattedMessage,d.header)),j(y,{onSubmit:this.props.onSubmitForm}))}}]),t}();function O(e){return{onSubmitForm:function(t){var n=Object.assign({},t.toJS(),{id:0,contacts:[]});e(Object(s.c)(n))}}}var w=Object(o.connect)(null,O),S=Object(f.a)({key:"manageCustomer",saga:b.a});t.default=Object(u.compose)(S,w)(h)},"3896c6a36d5a1023e179":function(e,t,n){"use strict";n("8af190b70a6bc55c6f1b"),n("8a2d1b95e05b6a321e74");var r,c=n("6938d226fd372a75cbf9"),a=n("edc5ec6b13db97ea0a32"),o=n("ab5fa99c40f6b171ec35"),u=(r="function"==typeof Symbol&&Symbol.for&&Symbol.for("react.element")||60103,function(e,t,n,c){var a=e&&e.defaultProps,o=arguments.length-3;if(t||0===o||(t={}),t&&a)for(var u in a)void 0===t[u]&&(t[u]=a[u]);else t||(t=a||{});if(1===o)t.children=c;else if(o>1){for(var i=Array(o),f=0;f<o;f++)i[f]=arguments[f+3];t.children=i}return{$$typeof:r,type:e,key:void 0===n?null:""+n,ref:null,props:t,_owner:null}});t.a=Object(c.withStyles)(function(e){return{textField:{marginLeft:e.spacing.unit,marginRight:e.spacing.unit,width:300}}})(function(e){var t=e.name,n=e.label,r=e.classes,c=e.type;return u(a.Field,{name:t,component:o.TextField,label:n,className:r.textField,margin:"normal",type:c})})},"3cc20616daf11836520d":function(e,t,n){"use strict";n.d(t,"b",function(){return c}),n.d(t,"a",function(){return a});var r=n("16bf8f695471e51e7917");function c(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"Успех",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"Операция успешно выполнена.";return Object(r.success)({title:e,message:t,position:"tr",autoDismiss:5})}function a(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"Ошибка",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"Произошла ошибка при выполнении операции.";return Object(r.error)({title:e,message:t,position:"tr",autoDismiss:3})}},"4ba745009885ed21e3eb":function(e,t,n){"use strict";n.d(t,"b",function(){return r}),n.d(t,"a",function(){return c});var r="/",c=r+"api/"},"8b2962270a2d760cc753":function(e,t,n){"use strict";n.d(t,"b",function(){return c}),n.d(t,"a",function(){return a});var r=n("cfcd288d5a7e166abf92");function c(){return{type:r.b}}function a(){return{type:r.a}}},adc20f99e57c573c589c:function(e,t,n){"use strict";var r=n("8af190b70a6bc55c6f1b"),c=n.n(r),a=n("8a2d1b95e05b6a321e74"),o=n.n(a),u=n("5ef9de3df8d92ea0e41c"),i=n.n(u),f=n("a1cf5d6fa4ed65a6ddd5"),s=n.n(f),b=n("f3b0ff1628e56352bcbf"),d=n.n(b),l=n("5fa3f8487e09c6182715"),p=n.n(l),m=n("6a4f9c383785f9168266"),v=n.n(m),y=n("f2873ecf7390fe7d7c89"),j=n.n(y),g=n("cc13decd9f9c09598c2f"),h="@@saga-injector/restart-on-remount",O="@@saga-injector/daemon",w="@@saga-injector/once-till-unmount",S=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},x=[h,O,w],k=function(e){return v()(p()(e)&&!s()(e),"(app/utils...) injectSaga: Expected `key` to be a non empty string")},_=function(e){var t={saga:d.a,mode:function(e){return p()(e)&&x.includes(e)}};v()(j()(e,t),"(app/utils...) injectSaga: Expected a valid saga descriptor")};function P(e){return Object(g.a)(e),{injectSaga:function(e,t){return function(n){var r=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{},c=arguments[2];t||Object(g.a)(e);var a=S({},r,{mode:r.mode||h}),o=a.saga,u=a.mode;k(n),_(a);var i=Reflect.has(e.injectedSagas,n);(!i||i&&u!==O&&u!==w)&&(e.injectedSagas[n]=S({},a,{task:e.runSaga(o,c)}))}}(e,!0),ejectSaga:function(e,t){return function(n){if(t||Object(g.a)(e),k(n),Reflect.has(e.injectedSagas,n)){var r=e.injectedSagas[n];r.mode&&r.mode!==O&&(r.task.cancel(),e.injectedSagas[n]="done")}}}(e,!0)}}var C=function(){function e(e,t){for(var n=0;n<t.length;n++){var r=t[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(t,n,r){return n&&e(t.prototype,n),r&&e(t,r),t}}();function E(e,t){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!t||"object"!=typeof t&&"function"!=typeof t?e:t}t.a=function(e){var t=e.key,n=e.saga,r=e.mode;return function(e){var a=function(a){function o(){var e,t,n;!function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,o);for(var r=arguments.length,c=Array(r),a=0;a<r;a++)c[a]=arguments[a];return t=n=E(this,(e=o.__proto__||Object.getPrototypeOf(o)).call.apply(e,[this].concat(c))),n.injectors=P(n.context.store),E(n,t)}return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function, not "+typeof t);e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}(o,c.a.Component),C(o,[{key:"componentWillMount",value:function(){(0,this.injectors.injectSaga)(t,{saga:n,mode:r},this.props)}},{key:"componentWillUnmount",value:function(){(0,this.injectors.ejectSaga)(t)}},{key:"render",value:function(){return c.a.createElement(e,this.props)}}]),o}();return a.WrappedComponent=e,a.contextTypes={store:o.a.object.isRequired},a.displayName="withSaga("+(e.displayName||e.name||"Component")+")",i()(a,e)}}},bbeaf91f6834df5f1f31:function(e,t,n){"use strict";n("8af190b70a6bc55c6f1b"),n("8a2d1b95e05b6a321e74");var r,c=n("6938d226fd372a75cbf9"),a=n("2aea235afd5c55b8b19b"),o=n.n(a),u=(r="function"==typeof Symbol&&Symbol.for&&Symbol.for("react.element")||60103,function(e,t,n,c){var a=e&&e.defaultProps,o=arguments.length-3;if(t||0===o||(t={}),t&&a)for(var u in a)void 0===t[u]&&(t[u]=a[u]);else t||(t=a||{});if(1===o)t.children=c;else if(o>1){for(var i=Array(o),f=0;f<o;f++)i[f]=arguments[f+3];t.children=i}return{$$typeof:r,type:e,key:void 0===n?null:""+n,ref:null,props:t,_owner:null}});t.a=Object(c.withStyles)(function(e){return{button:{margin:e.spacing.unit},input:{display:"none"}}})(function(e){var t=e.classes,n=e.label,r=e.variant,c=void 0===r?"contained":r;return u(o.a,{variant:c,color:"primary",type:"submit",className:t.button},void 0,n)})},bd67310ccfbbd9399274:function(e,t,n){"use strict";n.d(t,"i",function(){return c}),n.d(t,"j",function(){return a}),n.d(t,"c",function(){return o}),n.d(t,"d",function(){return u}),n.d(t,"g",function(){return i}),n.d(t,"h",function(){return f}),n.d(t,"a",function(){return s}),n.d(t,"b",function(){return b}),n.d(t,"e",function(){return d}),n.d(t,"f",function(){return l});var r=n("617796c05e33bd68ca94");function c(){return{type:r.i}}function a(e){return{type:r.j,customers:e}}function o(e){return{type:r.c,customer:e}}function u(e){return{type:r.d,customer:e}}function i(e){return{type:r.g,customerId:e}}function f(e){return{type:r.h,customerId:e}}function s(e){return{type:r.a,contact:e}}function b(e){return{type:r.b,contact:e}}function d(e){return{type:r.e,contactId:e}}function l(e){return{type:r.f,contact:e}}},bf45e7638178e6e3f979:function(e,t,n){"use strict";var r=n("4ba745009885ed21e3eb"),c=n("bd183afcc37eabd79225"),a=n.n(c),o=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var r in n)Object.prototype.hasOwnProperty.call(n,r)&&(e[r]=n[r])}return e},u=function(e){var t={headers:{Authorization:(arguments.length>1&&void 0!==arguments[1]?arguments[1]:null)||"","Access-Control-Allow-Origin":"*"},baseURL:e};return{get:function(e){var n=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};return a.a.get(e,o({},t,n)).then(function(e){return e.data})},post:function(e,n){var r=arguments.length>2&&void 0!==arguments[2]?arguments[2]:{};return a.a.post(e,n,o({},t,r)).then(function(e){return e.data})},delete:function(e){var n=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};return a.a.delete(e,o({},t,n))}}};n.d(t,"b",function(){return i}),n.d(t,"a",function(){return f});var i=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:null;return u(r.b,e)},f=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:null;return u(r.a,e)}},c04b6bf001e7257e27d8:function(e,t,n){"use strict";n.d(t,"a",function(){return v});var r=n("6c68d13fe9e3e77d8fc4"),c=n("a7e3807798c0b990af09"),a=n("8b2962270a2d760cc753"),o=n("3cc20616daf11836520d"),u=n("bf45e7638178e6e3f979"),i=n("408a21a5a81019839db6"),f=n("617796c05e33bd68ca94"),s=n("bd67310ccfbbd9399274"),b=regeneratorRuntime.mark(p),d=regeneratorRuntime.mark(m),l=regeneratorRuntime.mark(v);function p(e){var t,n,f;return regeneratorRuntime.wrap(function(b){for(;;)switch(b.prev=b.next){case 0:return t=e.customer,b.next=3,Object(r.d)(Object(i.b)());case 3:return n=b.sent,f="customers/",b.prev=5,b.next=8,Object(r.c)(Object(a.b)());case 8:return b.next=10,Object(r.b)(Object(u.a)(n).post,f,t);case 10:return t=b.sent,b.next=13,Object(r.a)([Object(r.c)(Object(s.d)(t)),Object(r.c)(Object(a.a)()),Object(r.c)(Object(o.b)()),Object(r.c)(Object(c.push)("/customers"))]);case 13:b.next=19;break;case 15:return b.prev=15,b.t0=b.catch(5),b.next=19,Object(r.a)([Object(r.c)(Object(a.a)()),Object(r.c)(Object(o.a)()),Object(r.c)(Object(c.push)("/customers"))]);case 19:case"end":return b.stop()}},b,this,[[5,15]])}function m(e){var t,n,c;return regeneratorRuntime.wrap(function(f){for(;;)switch(f.prev=f.next){case 0:return t=e.customerId,f.next=3,Object(r.d)(Object(i.b)());case 3:return n=f.sent,c="customers/"+t,f.prev=5,f.next=8,Object(r.c)(Object(a.b)());case 8:return f.next=10,Object(r.b)(Object(u.a)(n).delete,c);case 10:return f.next=12,Object(r.a)([Object(r.c)(Object(s.h)(t)),Object(r.c)(Object(a.a)()),Object(r.c)(Object(o.b)())]);case 12:f.next=18;break;case 14:return f.prev=14,f.t0=f.catch(5),f.next=18,Object(r.a)([Object(r.c)(Object(a.a)()),Object(r.c)(Object(o.a)())]);case 18:case"end":return f.stop()}},d,this,[[5,14]])}function v(){return regeneratorRuntime.wrap(function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,[Object(r.f)(f.c,p),Object(r.f)(f.g,m)];case 2:case"end":return e.stop()}},l,this)}}}]);