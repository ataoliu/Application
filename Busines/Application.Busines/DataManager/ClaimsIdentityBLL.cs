using System;
using Application.IBusines.DataManager;
using Application.IService.DataManager;
using Application.Service.DataManager;
using Application.Util.Model;

namespace Application.Busines.DataManager
{
	public class ClaimsIdentityBLL: ClaimsIdentityIBLL
	{
        private readonly ClaimsIdentityIService _service;
		public ClaimsIdentityBLL(ClaimsIdentityService service)
		{
            _service = service;
		}

        public TokenMode CreateToken(UserTokenModel  model)
        {
            return _service.CreateToken(model);
        }
    }
}

