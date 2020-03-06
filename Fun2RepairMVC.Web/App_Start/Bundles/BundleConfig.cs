using System.Web.Optimization;

namespace Fun2RepairMVC.Web.Bundles
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            BundleTable.EnableOptimizations = false;
            #region 前台
            //VENDOR RESOURCES
            bundles.Add(
            new StyleBundle("~/Bundles/frontend/css")
            .Include(StylePaths.Bootstrap3, new CssRewriteUrlTransform())
            .Include(StylePaths.Toastr, new CssRewriteUrlTransform())
            .Include(StylePaths.SweetAlert, new CssRewriteUrlTransform())
            .Include(StylePaths.CommonCSS, new CssRewriteUrlTransform())
            );

            bundles.Add(
               new ScriptBundle("~/Bundles/fontend/js/bottom")
                               .Include(
                           ScriptPaths.Json2,
                           ScriptPaths.JQuery2,
                           ScriptPaths.Bootstrap,
                           ScriptPaths.MomentJs_Local,
                           ScriptPaths.JQuery_Validation,
                           ScriptPaths.JQuery_ValidationUno,
                           ScriptPaths.JQuery_BlockUi,
                           ScriptPaths.JQuery_Ajax_Form,
                           ScriptPaths.SpinJs,
                           ScriptPaths.SpinJs_JQuery,
                           ScriptPaths.Toastr,
                           ScriptPaths.SweetAlert,
                           ScriptPaths.MomentJs,
                           ScriptPaths.Abp,
                           ScriptPaths.JQuery_SignalR,
                           ScriptPaths.Abp_JQuery,
                           ScriptPaths.Abp_Toastr,
                           ScriptPaths.Abp_BlockUi,
                           ScriptPaths.Abp_SpinJs,
                           ScriptPaths.Abp_SweetAlert,
                           ScriptPaths.appJs,
                           ScriptPaths.mainJs
                       ).ForceOrdered()
               );
            #endregion

            #region 後台登錄
            bundles.Add(
                new StyleBundle("~/Bundles/account-vendor/css")
                    .Include(StylePaths.Bootstrap3, new CssRewriteUrlTransform())
                    .Include(StylePaths.adminLTE, new CssRewriteUrlTransform())
                    .Include(StylePaths.Toastr, new CssRewriteUrlTransform())
                    .Include(StylePaths.SweetAlert, new CssRewriteUrlTransform())
                    .Include(StylePaths.FamFamFamFlags, new CssRewriteUrlTransform())
                    .Include(StylePaths.FontAwesome, new CssRewriteUrlTransform())
            );

            bundles.Add(
                new ScriptBundle("~/Bundles/account-vendor/js/bottom")
                    .Include(
                            ScriptPaths.Json2,
                            ScriptPaths.JQuery2,
                            ScriptPaths.Bootstrap,
                            ScriptPaths.MomentJs_Local,
                            ScriptPaths.JQuery_Validation,
                            ScriptPaths.JQuery_ValidationUno,
                            ScriptPaths.JQuery_BlockUi,
                            ScriptPaths.JQuery_Ajax_Form,
                            ScriptPaths.Toastr,
                            ScriptPaths.SweetAlert,
                            ScriptPaths.MomentJs,
                            ScriptPaths.Abp,
                            ScriptPaths.Abp_JQuery,
                            ScriptPaths.Abp_Toastr,
                            ScriptPaths.Abp_BlockUi,
                            ScriptPaths.Abp_SpinJs,
                            ScriptPaths.Abp_SweetAlert,
                            ScriptPaths.appJs,
                            ScriptPaths.mainJs
                    ).ForceOrdered()
            );
            #endregion

            #region 後台管理
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                .Include(StylePaths.Bootstrap3, new CssRewriteUrlTransform())
                .Include(StylePaths.adminLTE, new CssRewriteUrlTransform())
                .Include(StylePaths.Bootstrap_Select, new CssRewriteUrlTransform())
                .Include(StylePaths.Toastr, new CssRewriteUrlTransform())
                .Include(StylePaths.SweetAlert, new CssRewriteUrlTransform())
                .Include(StylePaths.FamFamFamFlags, new CssRewriteUrlTransform())
                .Include(StylePaths.FontAwesome, new CssRewriteUrlTransform())
                //.Include(StylePaths.LayoutCSS, new CssRewriteUrlTransform())
                .Include(StylePaths.CommonCSS, new CssRewriteUrlTransform())
                .Include(StylePaths.DataRangepicker, new CssRewriteUrlTransform())
                .Include(StylePaths.iCheck, new CssRewriteUrlTransform())
                .Include(StylePaths.JQuery_jTable_Theme, new CssRewriteUrlTransform())
            );
            bundles.Add(
                     new ScriptBundle("~/Bundles/vendor/js/bottom")
                        .Include(
                            ScriptPaths.Json2,
                            ScriptPaths.JQuery2,
                            ScriptPaths.Bootstrap,
                            ScriptPaths.MomentJs_Local,
                            ScriptPaths.JQuery_Validation,
                            ScriptPaths.JQuery_ValidationUno,
                            ScriptPaths.JQuery_BlockUi,
                            ScriptPaths.JQuery_Ajax_Form,
                            ScriptPaths.Toastr,
                            ScriptPaths.SweetAlert,
                            ScriptPaths.SpinJs,
                            ScriptPaths.SpinJs_JQuery,
                            ScriptPaths.MomentJs,
                            ScriptPaths.Bootstrap_Select,
                            ScriptPaths.JsTree,
                            ScriptPaths.Abp,
                            //ScriptPaths.Abp_JQuery,
                            ScriptPaths.Abp_Toastr,
                            ScriptPaths.Abp_BlockUi,
                            ScriptPaths.Abp_SpinJs,
                            ScriptPaths.Abp_SweetAlert,
                            //ScriptPaths.appJs,
                            //ScriptPaths.mainJs,
                            ScriptPaths.upload,
                            ScriptPaths.adminTLEJS,
                            ScriptPaths.iCheck
                        ).ForceOrdered()
            );
            #endregion

            #region  APPLICATION RESOURCES
            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/main.css")
                );
            #endregion 
        }
    }
}