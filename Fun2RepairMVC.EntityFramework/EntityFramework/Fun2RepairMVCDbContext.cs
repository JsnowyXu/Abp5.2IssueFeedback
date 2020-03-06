using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Fun2RepairMVC.Authorization.Roles;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Common.Extras;
using Fun2RepairMVC.Common.PublicCode;
using Fun2RepairMVC.FrontEnd.CMS;
using Fun2RepairMVC.FrontEnd.Customers;
using Fun2RepairMVC.MultiTenancy;

namespace Fun2RepairMVC.EntityFramework
{
    public class Fun2RepairMVCDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        #region BackEnd
        #region PublicCode
        public virtual IDbSet<Parameter> Parameters { get; set; }
        public virtual IDbSet<ParameterTranslation> ParameterTranslations { get; set; }
        public virtual IDbSet<Nation> Nations { get; set; }
        public virtual IDbSet<NationTranslation> NationTranslations { get; set; }
        public virtual IDbSet<Province> Provinces { get; set; }
        public virtual IDbSet<ProvinceTranslation> ProvinceTranslations { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<CityTranslation> CityTranslations { get; set; }
        public virtual IDbSet<Town> Towns { get; set; }
        #endregion

        #region Extras
        public virtual IDbSet<Announce> Announces { get; set; }
        public virtual IDbSet<AnnounceAttachment> AnnounceAttachments { get; set; }
        public virtual IDbSet<Attachment> Attachements { get; set; }
        public virtual IDbSet<Calendar> Calendars { get; set; }
        public virtual IDbSet<CalendarTranslation> CalendarTranslations { get; set; }
        public virtual IDbSet<MailLog> MailLogs { get; set; }
        public virtual IDbSet<MailTemplate> MailTemplates { get; set; }
        public virtual IDbSet<SMSLog> SMSLogs { get; set; }
        public virtual IDbSet<SMSTemplate> SMSTemplates { get; set; }
       
        #endregion

        #endregion

        #region Frontend
        public virtual IDbSet<Article> Articles { get; set; }
        public virtual IDbSet<Banner> Banners { get; set; }
        public virtual IDbSet<Column> Columns { get; set; }
        public virtual IDbSet<ColumnBanner> ColumnBanners { get; set; }
        public virtual IDbSet<Module> Modules { get; set; }
        public virtual IDbSet<ModuleTranslation> ModuleTranslations { get; set; }
        public virtual IDbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual IDbSet<CustomerGroupTranslation> CustomerGroupTranslations { get; set; }
        public virtual IDbSet<FriendLink> FriendLinks { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<OnlineService> OnlineServices { get; set; }
        public virtual IDbSet<Visitor> Visitors { get; set; }
        public virtual IDbSet<CmsParameter> CmsParameters { get; set; }
        public virtual IDbSet<CmsParameterTranslation> CmsParameterTranslations { get; set; }
        public virtual IDbSet<CmsParameterList> CmsParameterLists { get; set; }
        public virtual IDbSet<CmsOption> CmsOptions { get; set; }
        public virtual IDbSet<CmsOptionTranslation> CmsOptionTranslations { get; set; }
        #endregion

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public Fun2RepairMVCDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in Fun2RepairMVCDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of Fun2RepairMVCDbContext since ABP automatically handles it.
         */
        public Fun2RepairMVCDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public Fun2RepairMVCDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public Fun2RepairMVCDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
