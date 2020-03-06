using System.IO;
using System.Threading;
using System.Web;
using Abp.Extensions;
namespace Fun2RepairMVC.Web
{
    public class ScriptPaths
    {


            public const string Json2 = "~/lib/json2/json2.js";
            public const string upload = "~/lib/upload/upload.js";
            public const string JQuery2 = "~/lib/jquery/jquery.min.js";//V2.2
            public const string JQuerySlim = "~/lib/bootstrap4/Jquery-3.3.1.slim.min.js";
            public const string JQuery_BlockUi = "~/lib/blockUI/jquery.blockUI.js";
            public const string JQuery_Slimscroll = "~/lib/jquery-slimscroll/jquery.slimscroll.js";
            public const string JQuery_SignalR = "~/lib/signalr/jquery.signalR.min.js";
            public const string JQuery_Ajax_Form = "~/lib/jquery-ajax-form/jquery.form.js";
            public const string JQuery_Validation = "~/Scripts/jquery.validate.min.js";
            public const string JQuery_ValidationUno = "~/Scripts/jquery.validate.unobtrusive.js";
            public const string JQuery_AjaxUno = "~/Scripts/jquery.unobtrusive-ajax.min.js";


            public const string Bootstrap = "~/lib/bootstrap/js/bootstrap.min.js";
            public const string Bootstrap4 = "~/lib/bootstrap4/js/bootstrap.min.js";
            public const string Bootstrap_Select = "~/lib/bootstrap-select/dist/js/bootstrap-select.js";           
            public const string SweetAlert = "~/lib/sweetalert/dist/sweetalert-dev.js";
            public const string Toastr = "~/lib/toastr/toastr.min.js";

            public const string Bootstrap_DateRangePicker = "~/lib/daterangepicker/daterangepicker.js";
       

            public const string JsTree = "~/lib/jstree/jstree.js";
            public const string SpinJs = "~/lib/spin.js/spin.js";
            public const string SpinJs_JQuery = "~/lib/spin.js/jquery.spin.js";

            public const string MomentJs_Local = "~/lib/moment/min/moment-with-locales.js";
            public const string MomentJs = "~/Scripts/moment.min.js";

            public const string Abp = "~/lib/abp-web-resources/Abp/Framework/scripts/abp.js";
            public const string Abp_JQuery = "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js";
            public const string Abp_Toastr = "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.toastr.js";
            public const string Abp_BlockUi = "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.blockUI.js";
            public const string Abp_SpinJs = "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.spin.js";
            public const string Abp_SweetAlert = "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.sweet-alert.js";

   
            public const string adminTLEJS = "~/lib/AdminLTE/js/app.min.js";
            public const string mainJs = "~/js/main.js";
            public const string appJs = "~/js/script.js";
            public const string LayoutJs = "~/Views/Shared/_Layout.js";
            public const string LoginJS = "~/Areas/sysAdmin/Views/Account/Login.js";

            public const string iCheck = "~/lib/iCheck/iCheck.min.js";



        public static string JQuery_Validation_Localization
            {
                get
                {
                    return GetLocalizationFileForjQueryValidationOrNull(Thread.CurrentThread.CurrentUICulture.Name.ToLower().Replace("-", "_"))
                           ?? GetLocalizationFileForjQueryValidationOrNull(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                           ?? "~/lib/jquery-validation/js/localization/_messages_empty.js";
                }
            }

            private static string GetLocalizationFileForjQueryValidationOrNull(string cultureCode)
            {
                try
                {
                    var relativeFilePath = "~/lib/jquery-validation/js/localization/messages_" + cultureCode + ".min.js";
                    var physicalFilePath = HttpContext.Current.Server.MapPath(relativeFilePath);
                    if (File.Exists(physicalFilePath))
                    {
                        return relativeFilePath;
                    }
                }
                catch { }

                return null;
            }

            public static string JQuery_JTable_Localization
            {
                get
                {
                    return GetLocalizationFileForJTableOrNull(Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                           ?? GetLocalizationFileForJTableOrNull(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                           ?? "~/lib/jquery-jtable/localization/_jquery.jtable.empty.js";
                }
            }

            private static string GetLocalizationFileForJTableOrNull(string cultureCode)
            {
                try
                {
                    var relativeFilePath = "~/lib/jquery-jtable/localization/jquery.jtable." + cultureCode + ".js";
                    var physicalFilePath = HttpContext.Current.Server.MapPath(relativeFilePath);
                    if (File.Exists(physicalFilePath))
                    {
                        return relativeFilePath;
                    }
                }
                catch { }

                return null;
            }

            public static string Bootstrap_Select_Localization
            {
                get
                {
                    return GetLocalizationFileForBootstrapSelect(Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                           ?? GetLocalizationFileForBootstrapSelect(Thread.CurrentThread.CurrentUICulture.Name.Left(2).ToLower())
                           ?? "~/lib/bootstrap-select/i18n/defaults-en_US.js";
                }
            }

            private static string GetLocalizationFileForBootstrapSelect(string cultureCode)
            {
                var localizationFileList = new[]
                {
                "ar_AR",
                "bg_BG",
                "cs_CZ",
                "da_DK",
                "de_DE",
                "en_US",
                "es_CL",
                "eu",
                "fa_IR",
                "fi_FI",
                "fr_FR",
                "hu_HU",
                "id_ID",
                "it_IT",
                "ko_KR",
                "nb_NO",
                "nl_NL",
                "pl_PL",
                "pt_BR",
                "pt_PT",
                "ro_RO",
                "ru_RU",
                "sk_SK",
                "sl_SL",
                "sv_SE",
                "tr_TR",
                "ua_UA",
                "zh_CN",
                "zh_TW"
            };

                try
                {
                    cultureCode = cultureCode.Replace("-", "_");

                    foreach (var localizationFile in localizationFileList)
                    {
                        if (localizationFile.StartsWith(cultureCode))
                        {
                            return "~/lib/bootstrap-select/i18n/defaults-" + localizationFile + ".js";
                        }
                    }
                }
                catch { }

                return null;
            }
        }
    }