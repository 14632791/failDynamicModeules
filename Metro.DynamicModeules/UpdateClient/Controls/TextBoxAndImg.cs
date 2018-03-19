/*----------------------------------------------------------------
* Copyright (C) 2017 星火 版权所有。
*
* 文件名：TextBoxAndImg.cs
* 功能描述：
*
* Author：陈刚 Time：2016-06-29 12:10:39 
*
* 修改标识：
* 修改描述：
*
* 修改标识：
* 修改描述：
*
*----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace XHClient.UpdateClient.Controls
{
    [TemplatePart(Name = "PART_TxtMsg", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_Img", Type = typeof(ImageSource))]
    public class TextBoxAndImg : Control
    {
        static TextBoxAndImg()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxAndImg), new FrameworkPropertyMetadata(typeof(TextBoxAndImg)));
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBoxAndImg), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContextChanged)));
            ImgProperty = DependencyProperty.Register("Img", typeof(ImageSource), typeof(TextBoxAndImg), new PropertyMetadata(null));
            ContextOnEmptyProperty = DependencyProperty.Register("ContextOnEmpty", typeof(string), typeof(TextBoxAndImg),  new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContextOnEmptyChanged)));

        }
        public TextBoxAndImg()
        {
            Text = ContextOnEmpty;
        }

        
        public static readonly DependencyProperty ContextOnEmptyProperty;
        /// <summary>
        /// 当输入框为空时显示的默认值 
        /// </summary>
        public string ContextOnEmpty
        {
            get { return (string)GetValue(ContextOnEmptyProperty); }
            set { SetValue(ContextOnEmptyProperty, value); }
        }
       


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// 输入框的内容
        /// </summary>
        public static readonly DependencyProperty TextProperty;

        public ImageSource Img
        {
            get { return (ImageSource)GetValue(ImgProperty); }
            set { SetValue(ImgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Img.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgProperty;
        private static void OnContextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextBoxAndImg txtAndImg = (TextBoxAndImg)sender;
            string txtOnEmpty = txtAndImg.ContextOnEmpty;
            string txt = e.NewValue.ToString();
            if (string.IsNullOrEmpty(txt))
            {
                txtAndImg.Text = txtOnEmpty;
                return;
            }
        }
        private static void OnContextOnEmptyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextBoxAndImg txtAndImg = (TextBoxAndImg)sender;
            string txt = e.NewValue.ToString();
            if (!string.IsNullOrEmpty(txt) && string.IsNullOrEmpty(txtAndImg.Text))
            {
                txtAndImg.Text = txt;
                return;
            }
        }
        /// <summary>
        /// 可直接在这里绑定元素
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TextBox _txtInput = GetTemplateChild("PART_TxtMsg") as TextBox;
            _txtInput.FocusableChanged += _txtInput_FocusableChanged;
        }

        void _txtInput_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox input = sender as TextBox;
            if (input.IsFocused)
            {
                string tag = input.Tag.ToString();
                if (input.Text == tag)
                {
                    input.Text = "";
                }
            }
            else
            {
                
            }
        }
    }

}
