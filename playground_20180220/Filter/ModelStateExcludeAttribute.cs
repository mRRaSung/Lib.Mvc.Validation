using System;
using System.Web.Mvc;

namespace playground_20180220.Filter
{
    public class ModelStateExcludeAttribute : ActionFilterAttribute
    {
        public string[] Exclude { get; set; }

        public ModelStateExcludeAttribute()
        {
            Exclude = new string[]
            {
                "ID",
                "CreateTime",
                "CreateUser"
            };
        }

        public ModelStateExcludeAttribute(string exclude)
        {
            if(exclude != null)
            {
                if (exclude.Contains(",")){
                    Exclude = exclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                }
                else{
                    Exclude = new string[] { exclude };
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var item in Exclude)
            {
                //將排除欄位一一設定
                filterContext.Controller.ViewData.ModelState.Remove(item);
            }
            //設定完畢後將他利用 ViewData 傳到 Action 內
            filterContext.Controller.ViewData["Exclude"] = Exclude;
        }
    }
}