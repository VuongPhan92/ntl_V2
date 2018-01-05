using Domain.IServices;
using Domain.ViewModels;
using Infrastructure.Decorator;
using Infrastructure.Queries;
using SimpleInjector;
using System;
using WebCore.Services;

namespace IOC
{
    public class BootStrapper
    {
        private readonly Container container;

        public BootStrapper(Container _container)
        {
            container = _container;
        }

        public void Boot()
        {
         
            container.Register(typeof(IDeliveryTypeService), typeof(DeliveryTypeService));
            container.Register(typeof(IBranchService), typeof(BranchService));
            container.Register(typeof(IStatusService), typeof(StatusService));
            container.Register(typeof(IMerchandiseTypeService), typeof(MerchandiseTypeService));
            container.Register(typeof(IService<>), AppDomain.CurrentDomain.GetAssemblies());
            container.Register(typeof(IQueryHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.Register(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            
        }
    }
}