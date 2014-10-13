using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace wxManager.Views
{
    public partial class LoginWin : ChildWindow
    {
        loginToken token;
        public LoginWin()
        {
            InitializeComponent();
            token = new loginToken() { shopId = string.Empty, userId = string.Empty, pwd = string.Empty };
            this.LayoutRoot.DataContext = token;
        }

        protected override void OnOpened()
        {
            base.OnOpened();
            if (!App.Current.IsRunningOutOfBrowser)
            {
                System.Windows.Browser.HtmlPage.Plugin.Focus();
            }
            tb_userId.Focus();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //if ((this.tb_shopId.GetBindingExpression(TextBox.TextProperty).DataItem as loginToken).Error == null &&
            //    (this.tb_userId.GetBindingExpression(TextBox.TextProperty).DataItem as loginToken).Error == null)
            //{
            //    LoginParameters lp = new LoginParameters(tb_userId.Text, tb_pwd.Password, true, null);
            //    WebContext.Current.Authentication.Login(lp, (lo) =>
            //    {
            //        if (lo.HasError)
            //        {
            //            tbk_display.Text = lo.Error.ToString();
            //        }
            //        else if (lo.LoginSuccess == false)
            //        {
            //            tbk_display.Text = "验证失败";
            //        }
            //        else if (lo.LoginSuccess == true)
            //        {
            //            tbk_display.Text = string.Format("登录成功，当前用户：{0}，所属角色：{1}",
            //                WebContext.Current.User.Name,
            //                string.Join(",", WebContext.Current.User.Roles));
            //            this.DialogResult = true;
            //        }
            //    }, null);
            //}
        }

        public void GetUserInfo(string userId)
        {
            //WebContext.Current.Authentication.LoadUser(delegate
            //{
            //    if (WebContext.Current.User.IsAuthenticated)
            //    {
            //        tbk_display.Text = string.Format("登录成功，当前用户：{0}，所属角色：{1}",
            //            WebContext.Current.User.Name,
            //            string.Join(",", WebContext.Current.User.Roles));
            //    }
            //}, null);
        }

        public void logout()
        {
            //WebContext.Current.Authentication.Logout((lo) =>
            //{
            //    if (lo.HasError)
            //        tbk_display.Text = lo.Error.ToString();
            //    else
            //        tbk_display.Text = "登出成功";
            //}, null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }

    public class loginToken : IDataErrorInfo
    {
        public string shopId { get; set; }
        public string userId { get; set; }
        public string pwd { get; set; }

        public string Error
        {
            get
            {
                if (shopId == string.Empty || shopId.Contains("#") || userId == string.Empty || userId.Contains("#")
                    || pwd == string.Empty)
                {
                    return "error";
                }
                else { return null; }
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "shopId":
                        if (shopId == string.Empty)
                        {
                            return "店铺编号不能空";
                        }
                        else if (shopId.Contains("#"))
                        {
                            return "店铺编号不能使用#字符";
                        }
                        else
                        {
                            goto default;
                        }
                    case "userId":
                        if (userId == string.Empty)
                        {
                            return "账号不能空";
                        }
                        else if (userId.Contains("#"))
                        {
                            return "账号不能使用#字符";
                        }
                        else
                        {
                            goto default;
                        }
                    case "pwd":
                        if (pwd == string.Empty)
                        {
                            return "密码不能空";
                        }
                        else
                        {
                            goto default;
                        }
                    default:
                        return null;
                }
            }
        }
    }
}

