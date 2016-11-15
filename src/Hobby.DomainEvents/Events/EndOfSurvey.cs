using Hobby.DomainEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DomainEvents.Events
{
    public class EndOfSurvey : IDomainEvent
    {
        public Survey Survey { get; set; }
    }
}
