using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wx_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<object> bts = new List<object>();
            var bt = new view();
            bt.type = "view";
            bt.name = "香港代购";
            bt.url = "http://3g.dyok.net/";
            bts.Add(bt);

            var bt1 = new button();
            bt1.name = "自助服务";
            bt1.type = "click";
            bt1.key = "v01";
            bts.Add(bt1);

            var sbt = new subbutton();
            sbt.name = "生活服务";

            var bt2 = new button();
            bt2.name = "天气预报";
            bt2.type = "click";
            bt2.key = "V1001_TIANQI";
            sbt.sub_button.Add(bt2);

            var bt3 = new button();
            bt3.name = "赞一下我们";
            bt3.type = "click";
            bt3.key = "V1001_GOOD";
            sbt.sub_button.Add(bt3);

            bts.Add(sbt);

            var result = serializer.Serialize(bts);
            var json = @"{""button"":" + result + "}";
        }
    }

    public class view
    {
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
    public class button
    {
        public string type { get; set; }
        public string name { get; set; }
        public string key { get; set; }
    }

    public class subbutton
    {
        public subbutton()
        {
            sub_button = new List<object>();
        }
        public string name { get; set; }
        public List<object> sub_button { get; set; }
    }
}