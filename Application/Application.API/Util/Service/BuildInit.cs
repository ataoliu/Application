using Microsoft.AspNetCore.Builder;

namespace Application.API.Util
{

    public static class BuildInit
    {
        /// <summary>
        /// 注册application需要注入的容器
        /// </summary>
        /// <param name="builder"></param>
        public static void AddApplicationInit(this WebApplicationBuilder builder)
        {
            //注入其他服务
            builder.AddApplicationOtherService();
            // 注入业务逻辑示例
            builder.AddApplicationBusines();
            //注入基础服务实例
            builder.AddApplicationService();
         
            


        }



    }
}

