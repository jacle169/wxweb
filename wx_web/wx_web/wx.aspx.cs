using dy_weixin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wx_web
{
    public partial class wx : System.Web.UI.Page
    {
        weixin wxin;
        xmlWriter writer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (wxin == null)
                {
                    wxin = new weixin();
                    writer = new xmlWriter();
                    wxin.OnDataEvent += wxin_OnDataEvent;
                }
                //参数1为Token值和您公众平台上的token值一致即可
                //参数2为http内容，保持不变即可
                wxin.start(string.Empty, Request);
            } 
        }

        void wxin_OnDataEvent(RequestXML requestXML)
        {
            try
            {
                string resxml = "";
                if (requestXML.MsgType == "text")
                {
                    //List<news> newss = new List<news>();
                    //var n = new news();
                    //n.Description = "小静香港代购欢迎您的关注";
                    //n.PicUrl = "http://api.dyok.net/Slice1.jpg";
                    //n.Title = "击点进入小静商城";
                    //n.Url = "http://3g.dyok.net";
                    //newss.Add(n);


                    //resxml = writer.newsXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), newss);

                    //if (requestXML.Content == "1")
                    //{
                    //    //resxml = writer.musicXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "智音", "生命就是一次奇遇", "http://zhangmenshiting.baidu.com/data2/music/35510636/105542291381809661128.mp3?xcode=10388e6b54415114ffb67243ba34ef7af6764a243b47d37c", "http://zhangmenshiting.baidu.com/data2/music/35510636/105542291381809661128.mp3?xcode=10388e6b54415114ffb67243ba34ef7af6764a243b47d37c");
                    //}
                    //else
                    //{
                    //    //在这里执行一系列操作，从而实现自动回复内容. 
                    //    resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "你说的是：" + requestXML.Content);
                    //}
                }
                else if (requestXML.MsgType == "location")
                {
                    string city = wxin.GetMapInfo(requestXML.Location_X, requestXML.Location_Y);
                    resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "好啦，我们知道您的位置啦。" + city);
                }
                else if (requestXML.MsgType == "image")
                {
                    resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "亲,你的图片地址是：" + requestXML.PicUrl);
                }
                else if (requestXML.MsgType == "event")
                {
                    if (requestXML.Content.Equals("subscribe"))
                    {
                        List<news> newss = new List<news>();
                        var n = new news();
                        n.Description = "小静香港代购欢迎您的关注";
                        n.PicUrl = "http://api.dyok.net/Slice1.jpg";
                        n.Title = "小静香港代购欢迎您的关注";
                        n.Url = "http://3g.dyok.net";
                        newss.Add(n);

                        var n1 = new news();
                        n1.Description = "由小静本人亲自到各香港门店代购进货";
                        n1.PicUrl = "http://api.dyok.net/Slice2.jpg";
                        n1.Title = "100%香港优质货源,由小静本人亲自到各香港门店代购进货";
                        n1.Url = "http://3g.dyok.net/";
                        newss.Add(n1);

                        //var n2 = new news();
                        //n2.Description = "Coolpy是一个低成本稳定高效的硬件设备，其核心运行的是Coolpy系统";
                        //n2.PicUrl = "http://api.dyok.net/Untitled3.jpg";
                        //n2.Title = "智能家居首选";
                        //n2.Url = "http://shop.dyok.net/";
                        //newss.Add(n2);

                        resxml = writer.newsXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), newss);
                    }
                    else if (requestXML.Content.Equals("unsubscribe"))
                    {
                        //退订阅
                    }
                    else if (requestXML.Content.Equals("CLICK"))
                    {
                        resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "亲,事件EK：" + requestXML.EventKey);
                    }
                }
                else if (requestXML.MsgType == "voice")
                {
                    resxml = writer.VoiceXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), requestXML.MediaId);
                }
                else if (requestXML.MsgType == "video")
                {
                    resxml = writer.VideoXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), requestXML.MediaId, "title", "des");
                }
                else if (requestXML.MsgType == "link")
                {
                    resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "亲,你的连接地址是：" + requestXML.PUrl);
                }
                else
                {
                    resxml = writer.textXml(requestXML.FromUserName, requestXML.ToUserName, wxin.ConvertDateTimeInt(DateTime.Now), "亲, 没搞懂你是什么意思喔,回复1即进入核心智能控制客户端。");

                }
                HttpContext.Current.Response.Write(resxml);
            }
            catch (Exception ex)
            {

            }
        }
    }
}