using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dy_weixin
{
    public class xmlWriter
    {
        public string textXml(string FromUserName, string ToUserName, int unixTime, string message)
        {
            return "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + unixTime + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + message + "]]></Content><FuncFlag>1</FuncFlag></xml>";
        }

        public string musicXml(string FromUserName, string ToUserName, int unixTime, string title, string des, string musicUrl, string hqMusicUrl)
        {
            return "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA["+ ToUserName +"]]></FromUserName><CreateTime>"+ unixTime+"</CreateTime><MsgType><![CDATA[music]]></MsgType><Music><Title><![CDATA["+ title +"]]></Title><Description><![CDATA["+ des +"]]></Description><MusicUrl><![CDATA["+musicUrl+"]]></MusicUrl><HQMusicUrl><![CDATA["+hqMusicUrl+"]]></HQMusicUrl></Music></xml>";
        }

        public string newsXml(string FromUserName, string ToUserName, int unixTime, List<news> items)
        {
            string xml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + unixTime + "</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>" + items.Count + "</ArticleCount><Articles>";
            foreach (var item in items)
            {
                xml += createItem(item.Title, item.Description, item.PicUrl, item.Url);
            }
            xml +="</Articles></xml>";
            return xml;
        }

        public string createItem(string title, string des, string picUrl, string url)
        {
            return @"<item><Title><![CDATA["+title+"]]></Title><Description><![CDATA["+des+"]]></Description><PicUrl><![CDATA["+picUrl+"]]></PicUrl><Url><![CDATA["+url+"]]></Url></item>";
        }

        public string VoiceXml(string FromUserName, string ToUserName, int unixTime, string MediaId)
        {
            return @"<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + unixTime + "</CreateTime><MsgType><![CDATA[voice]]></MsgType><Voice><MediaId><![CDATA[" + MediaId + "]]></MediaId></Voice></xml>";
        }

        public string VideoXml(string FromUserName, string ToUserName, int unixTime, string MediaId, string title, string des)
        {
            return @"<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + unixTime + "</CreateTime><MsgType><![CDATA[video]]></MsgType><Video><MediaId><![CDATA[" + MediaId + "]]></MediaId><Title><![CDATA["+ title+"]]></Title><Description><![CDATA["+ des+"]]></Description></Video></xml>";
        }

    }

    public class news
    {
      public string Title{get;set;}
      public string Description{get;set;}
      public string PicUrl{get;set;}
      public string Url{get;set;}
    }
}
