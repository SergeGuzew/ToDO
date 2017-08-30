using System.Web;
using System.Web.Mvc;

namespace Ru.KpXX.Tests.Test02.ToDoApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
