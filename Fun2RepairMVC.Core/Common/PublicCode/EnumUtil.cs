
namespace Fun2RepairMVC.Common.PublicCode
{
    public class EnumUtil
    {
        #region 公共
        public enum BannerType
        {
            Carousel =0,
            Single = 1
        }
        //獲取數據依據
        public enum GetDataOrderType
        {
            Top = 0,//置頂
            Create= 1,//創建最新
            Recomment =2,//推薦
            Update = 3,//更新最新
            Order=4//用排序字段
        }

        public enum AlertType
        {
            success = 1,
            info = 2,
            warning = 3,
            error = 4
        }

        public enum DropDownlistType
        {
            All = 0,
            Blank = 1,
            Null = 2
        }

        /// <summary>
        /// 表單編輯模式
        /// </summary>
        public enum EditMode
        {
            Create = 1,//新增
            Edit = 2,//編輯
            View = 3,//查看
        }

        public enum RegisterType
        {
            None=0,//不驗證
            Phone=1,//手機驗證
            Admin= 2,//後台審核
            Email=3,//郵箱驗證
        }

        public enum LinkType
        {
            Text=0,
            Image=1
        }
        #endregion

    }
}
