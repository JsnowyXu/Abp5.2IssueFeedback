using Abp.Web.Mvc.Views;

namespace Fun2RepairMVC.Web.Views
{
    public abstract class Fun2RepairMVCWebViewPageBase : Fun2RepairMVCWebViewPageBase<dynamic>
    {

    }

    public abstract class Fun2RepairMVCWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected Fun2RepairMVCWebViewPageBase()
        {
            LocalizationSourceName = Fun2RepairMVCConsts.LocalizationSourceName;
        }
    }
}