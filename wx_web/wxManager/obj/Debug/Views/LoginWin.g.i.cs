﻿#pragma checksum "C:\Users\jac\Documents\Visual Studio 2012\Projects\wx_web\wxManager\Views\LoginWin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "92E9B292BCEB8CBC30AA86F673069D16"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace wxManager.Views {
    
    
    public partial class LoginWin : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.TextBox tb_shopId;
        
        internal System.Windows.Controls.TextBox tb_userId;
        
        internal System.Windows.Controls.PasswordBox tb_pwd;
        
        internal System.Windows.Controls.TextBlock tbk_display;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/wxManager;component/Views/LoginWin.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.tb_shopId = ((System.Windows.Controls.TextBox)(this.FindName("tb_shopId")));
            this.tb_userId = ((System.Windows.Controls.TextBox)(this.FindName("tb_userId")));
            this.tb_pwd = ((System.Windows.Controls.PasswordBox)(this.FindName("tb_pwd")));
            this.tbk_display = ((System.Windows.Controls.TextBlock)(this.FindName("tbk_display")));
        }
    }
}

