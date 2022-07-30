using System;
using System.Net;
using System.Net.Sockets;
using Application.Util.Extention;
using Microsoft.AspNetCore.Http;

namespace Application.Util.IP
{
    // <summary>
    /// 网络操作
    /// </summary>
    public class Net
    {
       private static IHttpContextAccessor ih = new HttpContextAccessor();
        #region Ip(获取Ip)

        /// <summary>
        /// 获取Ip
        /// </summary>
        public static string Ip
        {
            get
            {
                var result = string.Empty;
               
                if (ih.HttpContext != null)
                    result = GetWebClientIp();
                if (result.IsEmpty())
                    result = GetLanIp();
                return result;
            }
        }

        /// <summary>
        /// 获取Web客户端的Ip
        /// </summary>
        private static string GetWebClientIp()
        {
            var ip = GetWebRemoteIp();
            foreach (var hostAddress in Dns.GetHostAddresses(ip))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Web远程Ip
        /// </summary>
        private static string GetWebRemoteIp()
        {

            //return ih.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return "";
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region Host(获取主机名)

        /// <summary>
        /// 获取主机名
        /// </summary>
        public static string Host
        {
            get
            {
                return "";
               // return HttpContext.Current == null ? Dns.GetHostName() : GetWebClientHostName();
            }
        }

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetWebClientHostName()
        {
            if (!ih.HttpContext.Request.IsEmpty())
                return string.Empty;
            var ip = GetWebRemoteIp();
            var result = Dns.GetHostEntry(IPAddress.Parse(ip)).HostName;
            if (result == "localhost.localdomain")
                result = Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获得顶级域名
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string GetBaseDomain(string host)
        {
            List<string> list = new List<string>(".com|.co|.info|.net|.org|.me|.mobi|.us|.biz|.xxx|.ca|.co.jp|.com.cn|.net.cn|.org.cn|.mx|.tv|.ws|.ag|.com.ag|.net.ag|.org.ag|.am|.asia|.at|.be|.com.br|.net.br|.bz|.com.bz|.net.bz|.cc|.com.co|.net.co|.nom.co|.de|.es|.com.es|.nom.es|.org.es|.eu|.fm|.fr|.gs|.in|.co.in|.firm.in|.gen.in|.ind.in|.net.in|.org.in|.it|.jobs|.jp|.ms|.com.mx|.nl|.nu|.co.nz|.net.nz|.org.nz|.se|.tc|.tk|.tw|.com.tw|.idv.tw|.org.tw|.hk|.co.uk|.me.uk|.org.uk|.vg".Split('|'));
            string[] hs = host.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (hs.Length > 2)
            {
                //传入的host地址至少有三段
                int p2 = host.LastIndexOf('.');                 //最后一次“.”出现的位置
                int p1 = host.Substring(0, p2).LastIndexOf('.');//倒数第二个“.”出现的位置
                string s1 = host.Substring(p1);
                if (!list.Contains(s1))
                    return s1.TrimStart('.');

                //域名后缀为两段（有用“.”分隔）
                if (hs.Length > 3)
                    return host.Substring(host.Substring(0, p1).LastIndexOf('.'));
                else
                    return host.TrimStart('.');
            }
            else if (hs.Length == 2)
            {
                return host.TrimStart('.');
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Browser(获取浏览器信息)

        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        public static string Browser
        {
            get
            {
                //if (HttpContext.Current == null)
                //    return string.Empty;
                //var browser = ih.HttpContext.Request.Browser;
                //return string.Format("{0} {1}", browser.Browser, browser.Version);
                return "";
            }
        }

        #endregion
    }
}

