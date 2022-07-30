using System;
using Application.Busines.DataManager;
using Application.Entity.DataManager;
using Application.IBusines.DataManager;
using Application.Model;
using Application.Util.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers.DataManager
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CorsController : BaseController
    {
        private readonly CorsIBLL _corsIBLL;
        public CorsController(CorsBLL corsBLL)
        {
            _corsIBLL = corsBLL;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<Pagination<CorsEntity>> GetList()
        {
            try
            {
                var list = _corsIBLL.GetList();
                Pagination<CorsEntity> ts = new(list);
                return Success("操作成功", ts);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
             
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListAsync")]
        [AllowAnonymous]
        public async Task< IHttpActionResult> GetListAsync()
        {
            //try
            //{
            HttpRequestMessage request = new HttpRequestMessage();
                var list = await _corsIBLL.GetListAsync();
                Pagination<CorsEntity> ts = new(list);
            string s = list.ToJson();
                return new  TextResult(s, request);
            //}
            //catch (Exception ex)
            //{
            //    return Error(ex.Message);
            //}

        }

    }
}

