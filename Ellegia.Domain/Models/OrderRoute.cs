using System;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class OrderRoute : Entity
    {
        public int RecipientId { get; private set; }
        public int SenderId { get; private set; }
        public int OrderId { get; private set; }
        public DateTime DateTimeSent { get; private set; }
        public string Comment { get; private set; }

        protected OrderRoute()
        {
            // required by EF
        }

        public OrderRoute(int recipientId, int senderId, int orderId, string сomment) 
            : this()
        {
            RecipientId = recipientId;
            SenderId = senderId;
            OrderId = orderId;
            DateTimeSent = DateTime.UtcNow;
            Comment = сomment;
        }    
    }
}

