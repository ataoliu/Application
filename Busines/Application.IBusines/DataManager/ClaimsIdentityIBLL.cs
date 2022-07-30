using Application.Util.Model;
namespace Application.IBusines.DataManager
{
	public interface ClaimsIdentityIBLL
	{
		public TokenMode CreateToken(UserTokenModel  model);
		
		}
}

