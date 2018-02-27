using System;
using Metro.DynamicModeules.Core.Interfaces;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Interface.Sys;

namespace Metro.DynamicModeules.Core
{
    public class CoreModule : IModuleBase
    {
        public sys_Modules ModulesInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PackIconModernKind Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public sys_Modules Module => throw new NotImplementedException();

        public Control GetContainer()
        {
            throw new NotImplementedException();
        }

        public MenuItem GetModuleMenu()
        {
            throw new NotImplementedException();
        }

        public void InitButton()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
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