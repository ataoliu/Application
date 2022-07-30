using System;
using Application.Entity.DataManager;
using Application.Util.Model;

namespace Application.IService.DataManager
{
	public interface ClaimsIdentityIService
	{
		public ClaimsIdentityEntity GetEntity(Guid? id);
		public ClaimsIdentityEntity GetEntity(string paramsJson);

		public IEnumerable<ClaimsIdentityEntity> GetList(string paramsJson);
		public IEnumerable<ClaimsIdentityEntity> GetList();

		public TokenMode CreateToken(UserTokenModel userId);
		/// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="id">userid</param>
        /// <returns> 过期 true  </returns>
		public bool Expired(Guid? refreshToken);

		public void SaveForm(ClaimsIdentityEntity entity);
		public void SaveForm(IEnumerable<ClaimsIdentityEntity> entities);

		public void Delete(Guid? id);
		public void Delete(string paramsJson);

		public void Modify(ClaimsIdentityEntity entity);
		public void Modify(IEnumerable<ClaimsIdentityEntity> entities);

		public void Remove(Guid? id);
		public void Remove(ClaimsIdentityEntity entity);
		public void Remove(IEnumerable<ClaimsIdentityEntity> entities);
	}
}

