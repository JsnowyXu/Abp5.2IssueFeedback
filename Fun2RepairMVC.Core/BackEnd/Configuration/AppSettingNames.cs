namespace Fun2RepairMVC.Configuration
{
    public static class AppSettingNames
    {
        #region 個人設置
        public const string UiTheme = "User.UiTheme";
        public const string SidebarClosed = "User.SidebarClosed";
        public const string HeaderFixed = "User.HeaderFixed";
        public const string MenuLayout = "User.MenuLayout";
        public const string DefaultPageSize = "User.PageSize";
        #endregion

        #region 網站設置
        public const string WebSiteName = "App.Basic.WebSiteName";
        public const string WebSiteLogo = "App.Basic.WebSiteLogo";
        public const string AddressIcon = "App.Basic.AddressIcon";
        public const string WebSiteAddress = "App.Basic.WebSiteAddress";
        public const string WebSiteKeywords = "App.Basic.WebSiteKeywords";
        public const string WebSiteDecription = "App.Basic.WebSiteDecription";
        public const string LogoPositionDown = "App.Basic.LogoPositionDown";
        public const string LogoPositionRight = "App.Basic.LogoPositionRight";
        public const string WebSiteTitle = "App.Basic.WebSiteTitle";
        public const string EmailSender = "App.Basic.EmailSender";
        public const string EmailAccount = "App.Basic.EmailAccount";
        public const string TopCode = "App.Basic.TopCode";
        public const string BottomCode = "App.Basic.BottomCode";
        public const string LinkSetting = "App.Basic.LinkSetting";
        public const string ApiInterface = "App.Basic.ApiInterfaceSetting";
        public const string CopyrightInformation = "App.Footer.CopyrightInformation";
        #endregion

        //註冊設置
        public const string SMSIntervalTime = "App.SMSIntervalTime";//獲取驗證碼間隔
        public const string SMSCodeLength = "App.SMSCodeLength";//驗證碼長度，隨機數據碼長度
        public const string SMSCodeValidTime = "App.SMSCodeValidTime";//驗證碼有效時間
        public const string EmailCodeValidTime = "App.EmailCodeValidTime";//邮箱驗證碼有效時間

        //banner設置 App.Banner.*
        public const string DefaultBannerTypeCode = "App.Banner.DefaultTypeCode";
        public const string DefaultBannerHeight = "App.Banner.DefaultHeight";
        public const string DefaultBanner = "App.Banner.DefaultBanner";
        //Index 設置 App.Index.*
        public const string IndexSearchTop = "App.Index.SearchTop";
        public const string IndexSearchLeft = "App.Index.SearchLeft";



    }
}
