using Hobby.DomainEvents.Events;
using Hobby.DomainEvents.Service;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Ninject.Containers
{
    public class NinjectEventContainer : IEventDispatcher
    {
        private readonly IKernel _kernel;

        public NinjectEventContainer(IKernel kernel)
        {
            _kernel = kernel;
        }


        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (var handler in _kernel.GetAll<IDomainHandler<TEvent>>())
            {
                handler.Handle(eventToDispatch);
            }
        }
    }
}
