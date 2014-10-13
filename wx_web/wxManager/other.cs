using System;
using System.Net;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using wxManager.Views;

namespace wxManager
{
    public class other
    {
        static other ot;
        internal static other GetOther()
        {
            if (ot == null)
            {
                ot = new other();
            }
            return ot;
        }

        internal void GoUrl(Uri url)
        {
            if (!App.Current.IsRunningOutOfBrowser)
            {
                HtmlPage.Window.Navigate(url, "_blank");
            }
            else
            {
                HyperlinkButton link = new HyperlinkButton();
                link.NavigateUri = url;
                HyperlinkButtonAutomationPeer hyperlinkButtonAutomationPeer
                  = new HyperlinkButtonAutomationPeer(link);
                hyperlinkButtonAutomationPeer.RaiseAutomationEvent
                (AutomationEvents.InvokePatternOnInvoked);
                IInvokeProvider iprovider = (IInvokeProvider)hyperlinkButtonAutomationPeer;
                if (iprovider != null)
                    iprovider.Invoke();
            }
        }

        static cwin_Question cwin;
        internal static cwin_Question GetMessageBox()
        {
            if (cwin == null)
            {
                cwin = new cwin_Question();
                return cwin;
            }
            return cwin;
        }

    }
}
