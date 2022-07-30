using Microsoft.AspNetCore.Http;

namespace Application.Util.Extention
{
	public static partial class Extention
	{
        public static string GetClientIP(this HttpContext context)
        {
            var ip = context.Request.Headers["Cdn-Src-Ip"].FirstOrDefault();
            if (!string.IsNullOrEmpty(ip))
                return IpReplace(ip);

            ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(ip))
                return IpReplace(ip);

            ip = context.Connection.RemoteIpAddress.ToString();

            return IpReplace(ip);
        }

        static string IpReplace(string inip)
        {
            //::ffff:
            //::ffff:192.168.2.131 这种IP处理
            if (inip.Contains("::ffff:"))
            {
                inip = inip.Replace("::ffff:", "");
            }
            return inip;
        }
    }
}

