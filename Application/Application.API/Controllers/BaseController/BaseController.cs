using Application.Util;
using Application.Util.Extention;
using Application.Util.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public abstract class BaseController : ControllerBase//, Controller
    {
        //private Log _logger;
       


        private Guid UserId = Guid.Empty;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseController()
        {

            IHttpContextAccessor ih = new HttpContextAccessor();
            var Claims = ih.HttpContext.User.Claims;
            string userId = "";
            if (Claims.Count() > 0)
            {
                userId = Claims.FirstOrDefault(s => s?.Type == "UserId").Value;
            }
        }
        // / <summary>
        // / 格式化日志信息
        // / </summary>
        // / <param name="logMessage"></param>
        // / <param name="rawUrl"></param>
        // / <returns></returns>
        //public string LogMessageFormat(string logMessage, string rawUrl)
        //{
        //    string userName = null;
        //    //if (null != Code.OperatorProvider.Provider.Current())
        //    //    userName = Code.OperatorProvider.Provider.Current().UserName;
        //    //else
        //    //    userName = "未登录";

        //    StringBuilder strInfo = new StringBuilder();
        //    strInfo.Append("1. 调试: >> 操作时间: " + System.DateTime.Now.ToString() + "   操作人: " + userName + " \r\n");
        //    strInfo.Append("2. 地址: " + rawUrl + "    \r\n");
        //    strInfo.Append("3. 类名: " + this.ToString() + " \r\n");
        //    //strInfo.Append("4. 主机: " + Net.Host + "   Ip  : " + Net.Ip + "   浏览器: " + Net.Browser + "    \r\n");
        //    strInfo.Append("5. 异常: " + logMessage + "\r\n");
        //    strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
        //    return strInfo.ToString();
        //}

        // /<summary>
        // / 日志操作
        // / </summary>
        //public Log Logger
        //{
        //    get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        //}
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult Success()
        {
            return Ok(new Result { type = ResultType.success, message = "操作成功", resultdata = null });
        }
        protected virtual ActionResult Success(object data)
        {
            return Ok(new Result { type = ResultType.success, message = "操作成功", resultdata = data });
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {
            return Ok(new Result { type = ResultType.success, message = message, resultdata = data });
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Error(message);
        }
    }

    #region 访问设备
    //Add:Dzy[150720]
    public class VisitorTerminal
    {
        /// <summary>
        /// 终端类型
        /// </summary>
        public EnumVisitorTerminal Terminal { get; set; }
        /// <summary>
        /// 浏览器内核[暂不启用]
        /// </summary>
        public EnumVisitorBrowserCore BrowserCore { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public EnumVisitorOperaSystem OperaSystem { get; set; }
    }
    /// <summary>
    /// 浏览器内核
    /// </summary>
    public enum EnumVisitorBrowserCore
    {
        /// <summary>
        /// IE系内核
        /// <para>包括大部国产浏览器</para>
        /// </summary>
        Trident = 0,
        /// <summary>
        /// WebKit系
        /// <para>Chrome、Safari及大部份国产浏览器</para>
        /// </summary>
        WebKit = 1,
        /// <summary>
        /// Firefox
        /// </summary>
        Gecko = 2,
        /// <summary>
        /// Google新版
        /// <para>Chrome、Opera及大部份国产浏览器新版本</para>
        /// </summary>
        Blink = 3,
        /// <summary>
        /// Opera老版本
        /// </summary>
        Presto = 4,
        /// <summary>
        /// 微信
        /// </summary>
        WeiXin = 5,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 99
    }
    /// <summary>
    /// 访问终端
    /// <para>判定打开页面的设备与浏览器</para>
    /// </summary>
    public enum EnumVisitorTerminal
    {
        /// <summary>
        /// 电脑端
        /// </summary>
        PC = 0,
        /// <summary>
        /// 手机端
        /// </summary>
        Moblie = 1,
        /// <summary>
        /// 平板
        /// </summary>
        PAD = 2,
        /// <summary>
        /// 微信
        /// <para>独立出微信特征</para>
        /// </summary>
        WeiXin = 3,
        /// <summary>
        /// IOSApp
        /// </summary>
        IOS = 4,
        /// <summary>
        /// 安卓App
        /// </summary>
        Android = 5,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 99
    }
    /// <summary>
    /// 操作系统
    /// </summary>
    public enum EnumVisitorOperaSystem
    {
        /// <summary>
        /// MS出品
        /// </summary>
        Windows = 0,
        /// <summary>
        /// 安卓
        /// </summary>
        Android = 1,
        /// <summary>
        /// 苹果移动
        /// </summary>
        IOS = 2,
        /// <summary>
        /// Linux
        /// <para>Red Hat等</para>
        /// </summary>
        Linux = 3,
        /// <summary>
        /// UNIX
        /// <para>如BSD一类</para>
        /// </summary>
        UNIX = 4,
        /// <summary>
        /// 苹果桌面
        /// </summary>
        MacOS = 5,
        /// <summary>
        /// MS移动
        /// </summary>
        WindowsPhone = 6,
        /// <summary>
        /// Windows CE 嵌入式
        /// </summary>
        WindowsCE = 7,
        /// <summary>
        /// Windows Mobile
        /// </summary>
        WindowsMobile = 8,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 99
    }
    #endregion

    public interface IHttpActionResult
    {
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
    public class TextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public TextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}
