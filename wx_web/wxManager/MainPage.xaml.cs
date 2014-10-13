using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wxManager.Views;

namespace wxManager
{
    public partial class MainPage : UserControl
    {
        LoginWin lw;
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            hlb_sell.Click += new RoutedEventHandler(hlb_sell_Click);
            hlb_total.Click += new RoutedEventHandler(hlb_sell_Click);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!WebContext.Current.User.IsAuthenticated)
            //{
            //lw = new LoginWin();
            //lw.Closed += new EventHandler(lw_Closed);
            //lw.Show();
            //}
        }

        void lw_Closed(object sender, EventArgs e)
        {
            lw.Closed -= new EventHandler(lw_Closed);
            if (lw.DialogResult.Value)
            {
                //List<Operator> ops = new List<Operator>();
                //for (int i = 0; i < 50000; i++)
                //{
                //    Operator op = new Operator();
                //    op.ot_密码 = "密码";
                //    op.ot_权限组 = "权限组";
                //    op.ot_用户名 = "用户名";
                //    ops.Add(op);
                //}
                //dm.getDS().bulkInsert(ops, "Operators", lo =>
                //{
                //    MessageBox.Show(new TimeSpan(lo.Value).ToString());
                //}, null);
            }
        }

        void hlb_sell_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null)
                {
                    if (hb.Equals((HyperlinkButton)sender))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                    }
                }
            }
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {

        }

    }
}
