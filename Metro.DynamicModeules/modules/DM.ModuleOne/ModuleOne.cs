using Metro.DynamicModeules.Core.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace DM.ModuleOne
{
    [Export(typeof(IModuleBase))]
    public class ModuleOne : IModuleBase
    {       
        public ushort ModuleID { get; set; }

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

        public void Initialize()
        {
            //_container.RegisterType<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show($"{nameof(ModuleOne)} has been initialized ;-)");
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