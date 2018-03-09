﻿using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Metro.DynamicModeules.Interface;
using System.Windows.Controls;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// 带数据处理的子窗体viewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
 public  abstract class DataChildBaseViewModel<T>: ChildBaseViewModel, IDataOperatable<T>, ISummaryView<T>, IPrintableForm
        where T:class,new()
    {

        /// <summary>
        /// 当显示修改明细页时,首先获取焦点的编辑框.
        /// </summary>
        protected Control _ActiveEditor;

        /// <summary>
        /// 关键字段输入框,新增时不可修改
        /// </summary>
        protected Control _KeyEditor;

     
        /// <summary>
        /// 数据编辑页的主容器
        /// 因继承问题,需要在子类窗体Load的时候需要赋值
        /// </summary>
        protected Control _DetailGroupControl;

        /// <summary>
        /// 数据操作状态
        /// </summary>
        protected UpdateType _updateType = UpdateType.None;

        protected virtual string GetStateName()
        {
            if (UpdateType.Add == _updateType) return "(新增模式)";
            else if (UpdateType.Modify == _updateType) return "(修改模式)";
            else return "(查看模式)";
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        protected bool _AllowDataOperate = true;
               

        /// <summary>
        /// 自定义初始化窗体操作, 窗体的Load事件必须调用此方法
        /// </summary>
        protected virtual void InitializeForm() //此方法由基类的Load事件调用
        {
            this.InitButtons();//初始化本窗体的按钮
            this.SetViewMode();//预设为数据查看模式
            this.SetButtonAuthority();//设置按钮权限
            //无操作状态下不可输入数据
            SetDetailEditorsAccessable(_DetailGroupControl, false);
        }



        /// <summary>
        /// 是否数据发生改变
        /// </summary>
        public bool DataChanged
        {
            get { return this.IsAddOrEditMode; }
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        public bool AllowDataOperate
        {
            get { return _AllowDataOperate; }
            set
            {
                _AllowDataOperate = value;
                this.SetViewMode();
            }
        }

        /// <summary>
        /// 是否修改了数据
        /// </summary>
        public bool IsDataChanged
        {
            get { return this.IsAddOrEditMode; }
        }

        /// <summary>
        /// 是否新增/修改模式
        /// </summary>
        public bool IsAddOrEditMode
        {
            get { return (_updateType == UpdateType.Add) || (_updateType == UpdateType.Modify); }
        }

        /// <summary>
        /// 数据操作状态
        /// </summary>
        public UpdateType UpdateType { get { return _updateType; } }

        public virtual string UpdateTypeName
        {
            get
            {
                if (UpdateType.Add == _updateType) return "(新增模式)";
                else if (UpdateType.Modify == _updateType) return "(修改模式)";
                else return "(查看模式)";
            }
        }

        /// <summary>
        /// 初始化数据窗体的按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();

            List<IButtonInfo> dataButton = this.GetDataOperatableButtons();
            List<IButtonInfo> printButton = this.GetPrintableButtons();
            foreach (var item in dataButton)
            {
                this.Buttons.Add(item);
            }
            foreach (var item in printButton)
            {
                this.Buttons.Add(item);
            }
        }

        /// <summary>        
        ///设置为编辑模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetEditMode()
        {
            foreach (IButtonInfo button in Buttons)
            {

            }
            //_buttons.FirstOrDefault(b=>b.Name=="btnView").IsEnabled = false;
            //_buttons.FirstOrDefault(b => b.Name == "btnAdd").IsEnabled = false;
            //_buttons.FirstOrDefault(b=>b.Name=="btnDelete").IsEnabled = false;
            //_buttons.FirstOrDefault(b=>b.Name=="btnEdit").IsEnabled = false;
            //_buttons.FirstOrDefault(b=>b.Name=="btnPrint").IsEnabled = false;
            //_buttons.FirstOrDefault(b=>b.Name=="btnPreview").IsEnabled = false;
            //_buttons.FirstOrDefault(b=>b.Name=="btnSave").IsEnabled = true;
            //_buttons.FirstOrDefault(b=>b.Name=="btnCancel").IsEnabled = true;
        }

        /// <summary>        
        ///设置为查看模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetViewMode()
        {
            //_buttons.FirstOrDefault(b=>b.Name=="btnView").IsEnabled = _AllowDataOperate;
            //_buttons.FirstOrDefault(b=>b.Name=="btnAdd").IsEnabled = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.ADD);
            //_buttons.FirstOrDefault(b=>b.Name=="btnDelete").IsEnabled = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.DELETE);
            //_buttons.FirstOrDefault(b=>b.Name=="btnEdit").IsEnabled = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.EDIT);
            //_buttons.FirstOrDefault(b=>b.Name=="btnPrint").IsEnabled = ButtonAuthorized(ButtonAuthority.PRINT);
            //_buttons.FirstOrDefault(b=>b.Name=="btnPreview").IsEnabled = ButtonAuthorized(ButtonAuthority.PREVIEW);
            //_buttons.FirstOrDefault(b=>b.Name=="btnSave").IsEnabled = false;
            //_buttons.FirstOrDefault(b => b.Name == "btnCancel").IsEnabled = false;
        }

        /// <summary>
        /// 检查按钮的权限
        /// </summary>
        /// <param name="authorityValue">权限值</param>
        /// <returns></returns>
        public override bool ButtonAuthorized(int authorityValue)
        {
            //超级用户拥有所有权限
            //窗体可用权限=2^n= 1+2+4=7
            //比如新增功能点是2,那么检查新增按钮的方法是：  2 & 7 = 2，表示有权限。
            //
            bool isAuth = true;// Loginer.CurrentUser.IsAdmin() || (authorityValue & this.FormAuthorities) == authorityValue;
            return isAuth;
        }

        /// <summary>
        /// 按钮状态发生变化
        /// </summary>        
        protected virtual void ButtonStateChanged(UpdateType currentState)
        {
            //PackIconMaterial FileFind;  // PackIconControl<PackIconMaterialKind>
            //PackIconMaterialLight Kind; //PackIconControl<PackIconMaterialLightKind>
            //PackIconFontAwesome EyeSlas; //PackIconControl<PackIconFontAwesomeKind>
            //PackIconOcticons Alert;  //PackIconControl<PackIconOcticonsKind>
            //PackIconModern _3dCollada;  //PackIconControl<PackIconModernKind>
            //PackIconEntypo AircraftLand;  //PackIconControl<PackIconEntypoKind>
            //PackIconSimpleIcons Amazon;  // PackIconControl<PackIconSimpleIconsKind>

        }

        #region IPrintableForm 成员

        /// <summary>
        /// 打印操作按钮
        /// </summary>
        /// <returns></returns>
        public List<IButtonInfo> GetPrintableButtons()
        {
            List<IButtonInfo> btns = new List<IButtonInfo>();
            //if (this.ButtonAuthorized(ButtonAuthority.PRINT))
            //    btns.Add(this.ToolbarRegister.CreateButton("btnPrint", "打印", PackIconModernKind.Printer, new Size(57, 28), this.DoPrint));
            return btns;
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="button"></param>
        public virtual void DoPrint(IButtonInfo button) { }

        #endregion

        #region IDataOperatable接口的方法

        /// <summary>
        /// 数据操作按钮
        /// </summary>
        /// <returns></returns>
        public List<IButtonInfo> GetDataOperatableButtons()
        {

            List<IButtonInfo> list = new List<IButtonInfo>();
            //list.Add(this.ToolbarRegister.CreateButton("btnView", "查看", PackIconModernKind.SocialReadability, new Size(57, 57), this.DoViewContent));
            //list.Add(this.ToolbarRegister.CreateButton("btnAdd", "新增(F4)", PackIconModernKind.EditAdd, new Size(57, 57), this.DoAdd));
            //list.Add(this.ToolbarRegister.CreateButton("btnDelete", "删除(F6)", PackIconModernKind.Delete, new Size(57, 57), (sender) => { this.DoDelete(sender); }));
            //list.Add(this.ToolbarRegister.CreateButton("btnEdit", "修改(F5)", PackIconModernKind.Edit, new Size(57, 57), this.DoEdit));
            //list.Add(this.ToolbarRegister.CreateButton("btnSave", "保存(F2)", PackIconModernKind.Save, new Size(57, 57), (sender) => { this.DoSave(sender); } ));
            //list.Add(this.ToolbarRegister.CreateButton("btnCancel", "取消(F3)", PackIconModernKind.Cancel, new Size(57, 57), this.DoCancel));
            return list;
        }

        /// <summary>
        /// 查看选中记录的数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoViewContent(T row)
        {
            this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoAdd(T row)
        {
            this._updateType = UpdateType.Add;
            this.SetEditMode();
            this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoEdit(T row)
        {
            this._updateType = UpdateType.Modify;
            this.SetEditMode();
            this.ButtonStateChanged(_updateType);
        }

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoCancel(T row)
        {
            try
            {
                this._updateType = UpdateType.None;
                this.SetViewMode();
                this.ButtonStateChanged(_updateType);

                if (_updateType == UpdateType.Add)
                    this.ShowSummaryPage(true);
                else if (RowCount > 0)
                    this.DoViewContent(row);
            }
            catch (Exception e)
            {
                // Msg.ShowException(e);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="IsRefreshCache">是否同时刷新缓存</param>
        //public virtual void DoSave(PackIconButton sender,bool IsRefreshCache)
        //{
        //    DoSave(sender);
        //}

        public virtual bool DoSave(T row)
        {
            this._updateType = UpdateType.None;
            this.SetViewMode();
            this.ShowDetailPage(false);
            this.ButtonStateChanged(_updateType);
            return true;
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual bool DoDelete(T row)
        {
            return true;
        }

        #endregion

        #region Set Editors Accessable

        /// <summary>
        /// 控制明细页面上的控件可被编辑.
        /// </summary>
        protected virtual void SetDetailEditorsAccessable(Control panel, bool value)
        {
            if (panel == null) return;
            //for (int i = 0; i < panel.Controls.Count; i++)
            //{
            //    SetControlAccessable(panel.Controls[i], value);
            //}
            //controlNavigatorSummary.Enabled = !value;
        }

        /// <summary>
        /// 设置控件状态.ReadOnly or Enable = false/true
        /// </summary>
        protected void SetControlAccessable(Control control, bool value)
        {
            try
            {
                if (control is Label) return;
                //if (control is ControlNavigator) return;
                //if (control is UserControl) return;

                //if (control.Controls.Count > 0)
                //{
                //    foreach (Control c in control.Controls)
                //        SetControlAccessable(c, value);
                //}
                //if (control is ListBox)//2015.7.9 陈刚 对ListBox控件作禁用设置
                //{
                //    ListBox lstBox = control as ListBox;
                //    lstBox.Enabled = value;
                //    return;
                //}
                //System.Type type = control.GetType();
                //PropertyInfo[] infos = type.GetProperties();
                //foreach (PropertyInfo info in infos)
                //{
                //    if (info.Name == "ReadOnly")//ReadOnly
                //    {
                //        info.SetValue(control, !value, null);
                //        return;
                //    }
                //    if (info.Name == "Properties")//Properties.ReadOnly
                //    {
                //        object o = info.GetValue(control, null);
                //        if (o is RepositoryItem)
                //        {
                //            ((RepositoryItem)o).ReadOnly = !value;
                //        }
                //        //解决日期控件和ButtonEdit在浏览状态下也能按button的问题
                //        if ((o is RepositoryItemButtonEdit) && (((RepositoryItemButtonEdit)o).Buttons.Count > 0))
                //            ((RepositoryItemButtonEdit)o).Buttons[0].Enabled = value;
                //        if ((o is RepositoryItemDateEdit) && (((RepositoryItemDateEdit)o).Buttons.Count > 0))
                //            ((RepositoryItemDateEdit)o).Buttons[0].Enabled = value;
                //        return;
                //    }
                //    if (info.Name == "Views")//OptionsBehavior.Editable
                //    {
                //        object o = info.GetValue(control, null);
                //        if (null == o) return;
                //        foreach (object view in (GridControlViewCollection)o)
                //        {
                //            if (view is ColumnView)
                //                ((ColumnView)view).OptionsBehavior.Editable = value;
                //        }
                //        return;
                //    }

                //}
            }
            catch (Exception ex)
            {
                // Msg.ShowException(ex);
            }
        }

        /// <summary>
        /// 设置Grid自定义按钮(Add,Insert,Delete)状态
        /// </summary>
        protected void SetGridCustomButtonAccessable(DataGrid gridControl, bool value)
        {
            //NavigatorCustomButtons custom = gridControl.EmbeddedNavigator.Buttons.CustomButtons;
            //if (custom != null && custom.Count == 3)
            //{
            //    custom[DetailButtons.Add].Enabled = value; //add
            //    custom[DetailButtons.Insert].Enabled = value;//insert
            //    custom[DetailButtons.Delete].Enabled = value;//del
            //}
        }

        /// <summary>
        /// 设置某个编辑控件状态.ReadOnly or Enable . (递归)循环控制
        /// </summary>
        protected void SetControlAccessableCycle(Control control, bool value)
        {
            //if (control.HasChildren)
            //{
            //    foreach (Control ctrl in control.Controls)
            //    {
            //        //DevExpress的内部(Inner)控件
            //        if (ctrl.Name == string.Empty)
            //            SetControlAccessable(control, value);
            //        else
            //            SetControlAccessableCycle(ctrl, value);
            //    }
            //}
            //else SetControlAccessable(control, value);
        }

        /// <summary>
        /// 双击表格事件
        /// </summary>
        protected virtual void OnGridViewDoubleClick(object sender, EventArgs e)
        {
            try
            {
                //if (SystemConfig.CurrentConfig == null) return;
                //if (!this.HasData()) return;
                //PackIconButton btn = _buttons.GetButtonByName("btnEdit");
                //双击表格进入修改状态
                //if (SystemConfig.CurrentConfig.DoubleClickIntoEditMode)
                //{
                //    if (this.ButtonAuthorized(ButtonAuthority.EDIT)) //当前用户有修改权限
                //    {
                //        this.DoEdit(btn); //调用修改方法
                //        return;
                //    }
                //}
                //else //只能查看
                //{
                //this.DoViewContent(btn);
                //  SetDetailEditorsAccessable(_DetailGroupControl, false); //2015.6.15 注释 陈刚 2015.6.15
                //}
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.StackTrace);
            }
        }

        #endregion

        /// <summary>
        /// 获取Summary表的数据源.         
        /// </summary>
        //protected DataTable SummaryTable
        //{
        //    get
        //    {
        //        if (View == null) return null;
        //        return (DataTable)DataSource;
        //    }
        //}

        // UpdateType UpdateType { get; }

        public int RowCount
        {
            get
            {
                return DataSource == null ? 0 : DataSource.Count;
            }
        }

        public int FocusedRowHandle { get; set; }
        public ObservableCollection<T> DataSource { get; set; }

        public ListCollectionView View
        {
            get
            {
                if (null == DataSource)
                {
                    return null;
                }
                else
                {
                    return CollectionViewSource.GetDefaultView(DataSource) as ListCollectionView;
                }
            }
        }
            
     
        /// <summary>
        ///获取指定的资料行
        /// </summary>
        public T GetDataRow(int rowIndex)
        {
            if (rowIndex < 0) return default(T);
            if (View != null)
            {
                return View.GetItemAt(rowIndex) as T;
            }
            return null;
        }

        #region Summary数据导航功能

        /// <summary>
        /// 移到第一条记录
        /// </summary>
        protected virtual void DoMoveFirst()
        {
            if (View == null) return;
            MoveFirst();
            // if (tcBusiness.SelectedTabPage != tpSummary)
            DoViewContent(null);
        }

        /// <summary>
        /// 移到上一条记录
        /// </summary>
        protected virtual void DoMovePrevious()
        {
            if (View == null) return;
            MovePrior();
            //if (tcBusiness.SelectedTabPage != tpSummary)
            DoViewContent(null);
        }

        /// <summary>
        /// 移到下一条记录
        /// </summary>
        protected virtual void DoMoveNext()
        {
            if (View == null) return;
            MoveNext();
            // if (tcBusiness.SelectedTabPage != tpSummary)
            DoViewContent(null);
        }

        /// <summary>
        /// 移到最后一条记录
        /// </summary>
        protected virtual void DoMoveLast()
        {
            if (View == null) return;
            MoveLast();
            //if (tcBusiness.SelectedTabPage != tpSummary)
            DoViewContent(null);
        }

        #endregion

        /// <summary>
        /// 第一个编辑控件设置焦点.
        /// </summary>
        protected void FocusEditor()
        {
            if (_ActiveEditor != null)
            {
                if (_ActiveEditor.IsFocused)
                    _ActiveEditor.Focus();
                //else
                //    this.SelectNextControl(_ActiveEditor, true, false, true, true);
            }
        }

        /// <summary>
        /// 显示明细页
        /// </summary>
        protected virtual void ShowDetailPage(bool disableSummaryPage)
        {
            try
            {
                //this.tpDetail.PageEnabled = true; //2015.6.15 陈刚 不再对Page作禁用
                //tcBusiness.SelectedTabPage = this.tpDetail;
                //tpSummary.PageEnabled = !disableSummaryPage;//2015.6.15 陈刚 不再对Page作禁用
                //FocusEditor(); //第一个编辑框获得焦点.
                //this.ResumeLayout();
            }
            catch (Exception ex)
            {
                //Msg.ShowException(ex);
            }
        }

        /// <summary>
        /// 显示主表页
        /// </summary>
        protected void ShowSummaryPage(bool disableDetailPage)
        {
            //try
            //{
            //    this.tpSummary.PageEnabled = true;//2015.6.15 陈刚 不再对Page作禁用
            //    tcBusiness.SelectedTabPage = this.tpSummary;
            //    // tpDetail.PageEnabled = !disableDetailPage;//2015.6.15 陈刚 不再对Page作禁用
            //    if (View != null) SetFocus();
            //}
            //catch (Exception ex)
            //{ Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示当前操作消息
        /// </summary>
        protected void ShowTip(string tip)
        {
            //lblPrompt.Text = tip;
            //lblPrompt.Update();
        }

        /// <summary>
        ///获取当前光标所在的资料行. 
        /// </summary>
        protected T GetFocusedRow()
        {
            if (FocusedRowHandle < 0)
            {
                return default(T);
            }
            else
            {
                return GetDataRow(FocusedRowHandle);
            }
        }

        /// <summary>
        /// 关窗体中...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void FrmBaseDataForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (this.DataChanged)
        //        e.Cancel = !Msg.AskQuestion("您修改了数据没有保存，确定要退出吗?");
        //}

        /// <summary>
        /// 清空容器内输入框.
        /// </summary>
        public void ClearContainerEditorText(Control container)
        {
            //for (int i = 0; i < container.child.Count; i++)
            //{
            //    if (container.Controls[i] is TextEdit)
            //        ((TextEdit)container.Controls[i]).EditValue = null;
            //    else if (container.Controls[i] is TextBoxBase)
            //        ((TextBoxBase)container.Controls[i]).Clear();
            //}
        }


        /// <summary>
        /// 绑定Summary的导航按钮.
        /// </summary>        
        //protected void BindingSummaryNavigator(ControlNavigator navigator, DataGrid gc)
        //{
        //    navigator.NavigatableControl = gc;
        //    navigator.ButtonClick += new NavigatorButtonClickEventHandler(OnSummaryNavigatorButtonClick);
        //}

        /// <summary>
        /// 主表格导航按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OnSummaryNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    try
        //    {
        //        CCursor.ShowWaitCursor();
        //        NavigatorButton btn = (NavigatorButton)e.Button;
        //        ControlNavigatorButtons buttons = ((ControlNavigator)sender).Buttons;
        //        if (e.Button == buttons.First) DoMoveFirst();
        //        if (e.Button == buttons.Prev) DoMovePrior();
        //        if (e.Button == buttons.Next) DoMoveNext();
        //        if (e.Button == buttons.Last) DoMoveLast();
        //    }
        //    finally
        //    {
        //        e.Handled = true;
        //        CCursor.ShowDefaultCursor();
        //    }
        //}

      


        /// <summary>
        /// 删除表格内指定行号的记录
        /// </summary>
        /// <param name="rowHandle"></param>
        protected virtual void DeleteSummaryRow(int rowHandle)
        {
            if (rowHandle >= 0)
            {
                View.RemoveAt(rowHandle);
            }
        }

        /// <summary>
        /// 在保存时有此情况发生: 不会更新最后一个编辑框里的数据!
        /// 当移除焦点后会更新输入框的数据. 2015.7.15 陈刚 确保最后录入的数据能绑定到对应的数据源中
        /// </summary>
        protected void UpdateLastControl()
        {
            try
            {
                //if (ActiveControl == null) return;
                //Control ctl = ActiveControl;
                //txtFocusForSave.Focus();
                //ActiveControl = ctl;
            }
            catch (Exception ex)
            {
                // Msg.ShowException(ex);
            }
        }

        /// <summary>
        /// 替换记录对应字段的数据。
        /// </summary>
        /// <param name="sourceRow">数据源</param>
        /// <param name="destRow">需要替换的记录</param>
        protected void ReplaceDataRowChanges(T sourceRow, T destRow)
        {
            destRow = sourceRow.CloneModel();
        }

        /// <summary>
        /// 更新当前操作的缓存记录
        /// 保存数据后更新Summary当前记录.
        /// 如果是修改后保存,将最新数据替换当前记录的数据.
        /// 如果是新增后保存,在表格内插入一条记录.
        /// </summary>
        protected virtual void UpdateSummaryRow(T summary)
        {
            if (DataSource == null) return;
            if (summary == null) return;
            bool isSave = false;
            try
            {
                //如果是新增后保存,在表格内插入一条记录.
                if (_updateType == UpdateType.Add)
                {
                    T newrow = new T();//表格的数据源增加一条记录
                    this.ReplaceDataRowChanges(summary, newrow);//替换数据
                    DataSource.Add(newrow);
                    RefreshDataSource();
                }

                //如果是修改后保存,将最新数据替换当前记录的数据.
                if (_updateType == UpdateType.Modify || _updateType == UpdateType.None)
                {
                    var dr = GetDataRow(FocusedRowHandle);
                    this.ReplaceDataRowChanges(summary, dr);//替换数据
                    //dr.Table.AcceptChanges();
                    RefreshRow(FocusedRowHandle);//修改或新增要刷新Grid数据          
                }
                isSave = true;
            }
            catch (Exception ex)
            {
                //Msg.ShowException(ex);
                isSave = false;
            }
            finally
            {
                if (isSave)
                {
                    _updateType = UpdateType.None;
                }
            }
        }





        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshDataSource()
        {
            throw new NotImplementedException();
        }

        public void BindingDoubleClick(EventHandler eventHandler)
        {
            throw new NotImplementedException();
        }

        public void SetFocus()
        {
            throw new NotImplementedException();
        }

        public void MoveFirst()
        {
            if (View == null) return;
            //if (tcBusiness.SelectedTabPage != tpSummary)
            DoViewContent(null);
        }

        public void MovePrior()
        {
            throw new NotImplementedException();
        }

        public void MoveNext()
        {
            throw new NotImplementedException();
        }

        public void MoveLast()
        {
            throw new NotImplementedException();
        }

        public bool IsValidRowHandle(int rowHandle)
        {
            throw new NotImplementedException();
        }

        public void RefreshRow(int rowHandle)
        {
            throw new NotImplementedException();
        }

        public void DoViewContent()
        {
            throw new NotImplementedException();
        }
        /*分割线*/


    }
}
