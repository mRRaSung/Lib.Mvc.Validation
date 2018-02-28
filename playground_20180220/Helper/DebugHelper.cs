using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace playground_20180220.Helper
{
    public static class DebugHelper
    {
        public static bool DoCheckRuntimeIsDebug()
        {
            #if DEBUG
                return true;
            #else
                return false;
            #endif
        }

        public static MvcHtmlString HiddenTest(this HtmlHelper helper, string name, object value = null)
        {
            if(DoCheckRuntimeIsDebug())
            {
                return helper.TextBox(name, value);
            }

            return helper.Hidden(name, value);
        }
    }
}