using System.Web;
using System.Web.Mvc;

namespace MVCwithMongodbCRUD
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
