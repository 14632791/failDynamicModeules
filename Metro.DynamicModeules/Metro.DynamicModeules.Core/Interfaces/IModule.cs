using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Core.Interfaces
{
    /// <summary>
    /// 这是二级选项的内容
    /// </summary>
    public abstract class SubModuleBase : ModuleBase
    {       
        public SubModuleBase(ModuleID mid, ModuleID ParentModuleID) : base(mid)
        {
            this.ParentModuleID = ParentModuleID;
        }

        /// <summary>
        /// 父结点
        /// </summary>
        public readonly ModuleID ParentModuleID;
       
        /// <summary>
        /// 初始化功能按钮
        /// </summary>
        public void InitButton()
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="securityInfo"></param>
        public void SetSecurity(object securityInfo)
        {
            throw new NotImplementedException();
        }
    }

    public class ModuleBase //: IModuleBase
    {
        public ModuleBase(ModuleID mid)
        {
            ModuleID = (ushort)mid;
            ModuleName = mid.ToString();
        }
        public readonly ushort ModuleID;//{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public readonly string ModuleName;// { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 获取当前的容器
        /// </summary>
        /// <returns></returns>
        public virtual Control GetContainer()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MenuItem GetModuleMenu()
        {
            throw new NotImplementedException();
        }

        //public void InitButton()
        //{
        //    throw new NotImplementedException();
        //}

        public void Initialize()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 初始化上下文菜单
        /// </summary>
        public void InitMenu()
        {
            throw new NotImplementedException();
        }
        
    }


    /// <summary>
    /// 模块编号.
    /// </summary>
    public enum ModuleID: ushort
    {
        None = 0,
        基础信息 = 1,
        财务管理 = 7,
        生产管理 = 8 //用于排序
    }
}
