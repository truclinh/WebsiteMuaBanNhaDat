using System.Web;
using System.Web.Mvc;

namespace WebsiteMuaBanNhaDat1 {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

    }
}