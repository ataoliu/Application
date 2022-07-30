using System;
namespace Application.Cache
{
    /// <summary>
    /// 缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// 定义通用的Repository
        /// </summary>
        /// <returns></returns>
        public static ICache Cache()
        {
            var type = (CacheType)1;//Redis SystemCache
            if (type == CacheType.RedisCache)
                return new RedisCache();
            if (type == CacheType.SystemCache)
                return new SystemCache();
            return new SystemCache();
        }
    }
}

