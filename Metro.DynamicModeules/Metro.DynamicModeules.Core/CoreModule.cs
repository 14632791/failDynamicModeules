using System;
using Metro.DynamicModeules.Core.Interfaces;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Core
{
    public class CoreModule : IModuleBase
    {       
        public void Initialize()
        {
           // _container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());
        }
        public UInt16 ModuleID { get; set; }

        public string ModuleName { get; set; }

        public Control GetContainer()
        {
            throw new NotImplementedException();
        }

        public Menu GetModuleMenu()
        {
            throw new NotImplementedException();
        }

        public void InitButton()
        {
            throw new NotImplementedException();
        }

        public void InitMenu()
        {
            throw new NotImplementedException();
        }

        public void SetSecurity(object securityInfo)
        {
            throw new NotImplementedException();
        }
    }
}