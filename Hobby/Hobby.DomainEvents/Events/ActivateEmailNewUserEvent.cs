using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DomainEvents.Events
{
    public class ActivateEmailNewUserEvent : IDomainEvent
    {
        //Create properties to raise event
        public decimal idUser { get; set; }
        public string Email { get; set; }
    }
}
