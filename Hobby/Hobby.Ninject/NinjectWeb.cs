using Hobby.Data;
using Hobby.Data.Interface;
using Hobby.DomainEvents;
using Hobby.DomainEvents.Events;
using Hobby.DomainEvents.Handler;
using Hobby.DomainEvents.Service;
using Hobby.Services;
using Hobby.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Ninject
{
    public class NinjectWeb
    {
        public static void Container(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            kernel.Bind<IUserService>().To<UserService>();

            DomainEvent.Dispatcher = new NinjectEventContainer(kernel);
            kernel.Bind<IDomainHandler<EndOfSurvey>>().To<EndOfSurveyHandler>();
            kernel.Bind<IDomainHandler<ActivateEmailNewUserEvent>>().To<ActivateEmailNewUserHandler>();
        }
    }
}
