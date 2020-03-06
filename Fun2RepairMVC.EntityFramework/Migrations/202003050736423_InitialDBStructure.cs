namespace Fun2RepairMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.extAnnounceAttachements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AnnounceId = c.Long(nullable: false),
                        AttachmentId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.extAttachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.extAnnounces", t => t.AnnounceId, cascadeDelete: true)
                .Index(t => t.AnnounceId)
                .Index(t => t.AttachmentId);
            
            CreateTable(
                "dbo.extAttachments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OriginName = c.String(),
                        UniqueName = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        FilePath = c.String(nullable: false, maxLength: 200),
                        FileSize = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.extAnnounces",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsImportant = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Announce_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Announce_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.pubCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubProvinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.pubProvinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        NationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProvinceTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubProvinces", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.CityTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubCities", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.AbpCustomerGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDefault = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsStatic = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerGroup_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.CustomerGroupTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerGroupTranslation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpCustomerGroups", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubCities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.cmsArticles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Brief = c.String(maxLength: 200),
                        Content = c.String(storeType: "ntext"),
                        CTitle = c.String(maxLength: 200),
                        Keywords = c.String(maxLength: 200),
                        Description = c.String(maxLength: 80),
                        ColumnId1 = c.Int(),
                        ColumnId2 = c.Int(),
                        ColumnId3 = c.Int(),
                        OrderNo = c.Int(nullable: false),
                        ThumbUrl = c.String(maxLength: 200),
                        ImgUrl = c.String(maxLength: 200),
                        IsRecommed = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        BrowserNo = c.Int(nullable: false),
                        HitNo = c.Int(nullable: false),
                        ColectionNo = c.Int(nullable: false),
                        HtmlPage = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        Language = c.String(),
                        Tag = c.String(maxLength: 500),
                        ExternalLink = c.String(maxLength: 200),
                        SiteMemo = c.String(),
                        OtherMemo = c.String(),
                        OtherMemo1 = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Article_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId1)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId2)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId3)
                .Index(t => t.ColumnId1)
                .Index(t => t.ColumnId2)
                .Index(t => t.ColumnId3)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DisplayName = c.String(maxLength: 100),
                        ModuleId = c.Int(nullable: false),
                        OrderNo = c.Int(nullable: false),
                        IsExternal = c.Boolean(nullable: false),
                        ShowTypeId = c.Int(nullable: false),
                        BigClassId = c.Int(),
                        ClassType = c.Int(nullable: false),
                        StaticName = c.String(maxLength: 100),
                        TargetUrl = c.String(maxLength: 100),
                        TargetWindow = c.String(maxLength: 100),
                        SEOTitle = c.String(maxLength: 100),
                        SEOKeywords = c.String(maxLength: 100),
                        SEODescription = c.String(maxLength: 500),
                        OrderType = c.Int(nullable: false),
                        OutUrl = c.String(maxLength: 100),
                        RequiresAuthentication = c.Boolean(nullable: false),
                        ColumnImg = c.String(maxLength: 100),
                        IndexImg = c.String(maxLength: 100),
                        IsContent = c.Boolean(nullable: false),
                        IsDisplay = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Icon = c.String(maxLength: 50),
                        MultiTenancySides = c.Int(nullable: false),
                        BannerTypeId = c.Int(),
                        Height = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Column_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.BannerTypeId)
                .ForeignKey("dbo.cmsColumns", t => t.BigClassId)
                .ForeignKey("dbo.cmsModules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.pubParameters", t => t.ShowTypeId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.ShowTypeId)
                .Index(t => t.BigClassId)
                .Index(t => t.BannerTypeId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsColumnBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BannerId = c.Int(nullable: false),
                        ColumnId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsBanners", t => t.BannerId, cascadeDelete: true)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId, cascadeDelete: true)
                .Index(t => t.BannerId)
                .Index(t => t.ColumnId);
            
            CreateTable(
                "dbo.cmsBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgTitle = c.String(maxLength: 200),
                        ImgUrl = c.String(maxLength: 200),
                        ImgLink = c.String(maxLength: 200),
                        FlashPath = c.String(maxLength: 200),
                        FlashBack = c.String(maxLength: 200),
                        OrderNo = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Banner_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.pubParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        IsInput = c.Boolean(nullable: false),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Parameter_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.ParameterTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.cmsModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Icon = c.String(maxLength: 50),
                        TargetUrl = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        IsContent = c.Boolean(nullable: false),
                        IsShowInManage = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsModulesTranslation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsModules", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.extCalendars",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullDateAlternateKey = c.String(),
                        DayNumberOfWeek = c.Int(nullable: false),
                        DayNumberOfMonth = c.Int(nullable: false),
                        DayNumberOfYear = c.Int(nullable: false),
                        WeekyNumberOfYear = c.Int(nullable: false),
                        MonthNumberOfYear = c.Int(nullable: false),
                        CalendarQuarter = c.Int(nullable: false),
                        CalendarSemester = c.Int(nullable: false),
                        CalendarYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CalendarTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthName = c.String(),
                        WeekkName = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.extCalendars", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.cmsOptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParaId = c.Long(nullable: false),
                        OptionValue = c.String(storeType: "ntext"),
                        OrderNo = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CmsOption_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsParameters", t => t.ParaId, cascadeDelete: true)
                .Index(t => t.ParaId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsParameters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColumnId1 = c.Int(),
                        ColumnId2 = c.Int(),
                        ColumnId3 = c.Int(),
                        DisplayName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 200),
                        ParaTypeId = c.Int(nullable: false),
                        IsMandatory = c.Boolean(nullable: false),
                        ModuleId = c.Int(),
                        OrderNo = c.Int(nullable: false),
                        IsDisplay = c.Boolean(nullable: false),
                        OptionValues = c.String(storeType: "ntext"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CmsParameter_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId1)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId2)
                .ForeignKey("dbo.cmsColumns", t => t.ColumnId3)
                .ForeignKey("dbo.cmsModules", t => t.ModuleId)
                .ForeignKey("dbo.pubParameters", t => t.ParaTypeId, cascadeDelete: true)
                .Index(t => t.ColumnId1)
                .Index(t => t.ColumnId2)
                .Index(t => t.ColumnId3)
                .Index(t => t.ParaTypeId)
                .Index(t => t.ModuleId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.CmsParameterTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                        Core_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsParameters", t => t.Core_Id)
                .Index(t => t.Core_Id);
            
            CreateTable(
                "dbo.cmsOptionTranslation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                        Core_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsOptions", t => t.Core_Id)
                .Index(t => t.Core_Id);
            
            CreateTable(
                "dbo.cmsParametersList",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParaId = c.Long(nullable: false),
                        ListId = c.Long(),
                        ParaValue = c.String(storeType: "ntext"),
                        AttachmentName = c.String(maxLength: 100),
                        ModuleId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cmsModules", t => t.ModuleId)
                .ForeignKey("dbo.cmsParameters", t => t.ParaId, cascadeDelete: true)
                .Index(t => t.ParaId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.cmsFriendLink",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        LinkTypeId = c.Int(nullable: false),
                        TargetUrl = c.String(maxLength: 200),
                        TargetLogo = c.String(maxLength: 200),
                        Kerwords = c.String(maxLength: 500),
                        OrderNo = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LinkContact = c.String(maxLength: 200),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FriendLink_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.LinkTypeId, cascadeDelete: true)
                .Index(t => t.LinkTypeId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpFunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsMenu = c.Boolean(nullable: false),
                        IsWebPage = c.Boolean(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        Icon = c.String(maxLength: 32),
                        Url = c.String(maxLength: 64),
                        RequiresAuthentication = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        MultiTenancySides = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AbpFunction_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpFunctions", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.extMailLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MailTypeId = c.Int(nullable: false),
                        MailAddress = c.String(nullable: false, maxLength: 200),
                        Subject = c.String(nullable: false, maxLength: 200),
                        MailBody = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        LanguageCode = c.String(maxLength: 20),
                        TenantId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MailLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.MailTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId)
                .Index(t => t.MailTypeId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.extMailTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MailTypeId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        TenantId = c.Int(),
                        Subject = c.String(nullable: false, maxLength: 200),
                        MailBody = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MailTemplate_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MailTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpLanguages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.pubParameters", t => t.MailTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId)
                .Index(t => t.MailTypeId)
                .Index(t => t.LanguageId)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsMessages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ttile = c.String(maxLength: 200),
                        Content = c.String(maxLength: 1000),
                        AddTime = c.DateTime(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 50),
                        EmailAddress = c.String(maxLength: 200),
                        IPAdress = c.String(maxLength: 50),
                        OtherContact = c.String(maxLength: 200),
                        CustomerId = c.Long(),
                        ReplyStatusId = c.Int(),
                        MessageTypeId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Message_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.MessageTypeId)
                .ForeignKey("dbo.pubParameters", t => t.ReplyStatusId)
                .Index(t => t.ReplyStatusId)
                .Index(t => t.MessageTypeId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.pubNations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Nation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.NationTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoreId = c.Int(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubNations", t => t.CoreId, cascadeDelete: true)
                .Index(t => t.CoreId);
            
            CreateTable(
                "dbo.cmsOnlineServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Guid(nullable: false),
                        DisplayName = c.String(maxLength: 100),
                        TypeId = c.Int(nullable: false),
                        TargetURL = c.String(maxLength: 500),
                        LogoSrc = c.String(maxLength: 500),
                        OrderNo = c.Int(nullable: false),
                        QQ1 = c.String(maxLength: 100),
                        QQ2 = c.String(maxLength: 100),
                        QQ3 = c.String(maxLength: 100),
                        MSN = c.String(maxLength: 100),
                        Wechat1 = c.String(maxLength: 100),
                        Wechat2 = c.String(maxLength: 100),
                        QrCode1 = c.String(maxLength: 100),
                        QrCode2 = c.String(maxLength: 100),
                        Skype = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OnlineService_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.extSMSLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        SMSTypeId = c.Int(nullable: false),
                        PhoneNo = c.String(nullable: false, maxLength: 20),
                        SMSText = c.String(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        LanguageCode = c.String(maxLength: 20),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SMSLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pubParameters", t => t.SMSTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.SMSTypeId);
            
            CreateTable(
                "dbo.extSMSTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SMSTemplateId = c.Int(nullable: false),
                        SMSTypeId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        TenantId = c.Int(),
                        SMSText = c.String(nullable: false, maxLength: 1000),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SMSTemplate_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SMSTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpLanguages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.pubParameters", t => t.SMSTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AbpTenants", t => t.TenantId)
                .Index(t => t.SMSTypeId)
                .Index(t => t.LanguageId)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.cmsVisitors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IpAdress = c.String(maxLength: 50),
                        AccessTime = c.DateTime(nullable: false),
                        VisitPage = c.String(maxLength: 200),
                        AntePage = c.String(maxLength: 200),
                        ColumeId = c.Int(),
                        Browser = c.String(maxLength: 50),
                        NetWork = c.String(maxLength: 50),
                        Lang = c.String(maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AbpUsers", "IsCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "CustomerLevel", c => c.Int(nullable: false));
            AddColumn("dbo.AbpUsers", "CustomerCoin", c => c.Int(nullable: false));
            AddColumn("dbo.AbpUsers", "GroupId", c => c.Int());
            AddColumn("dbo.AbpUsers", "PersonalImage", c => c.String(maxLength: 200));
            AddColumn("dbo.AbpUsers", "SocialLink", c => c.String(maxLength: 200));
            AddColumn("dbo.AbpUsers", "Remark", c => c.String(maxLength: 500));
            AddColumn("dbo.AbpUsers", "ProvinceId", c => c.Int());
            AddColumn("dbo.AbpUsers", "CityId", c => c.Int());
            AddColumn("dbo.AbpUsers", "TownId", c => c.Int());
            AddColumn("dbo.AbpUsers", "DetailAddress", c => c.String(maxLength: 200));
            AddColumn("dbo.AbpUsers", "PostCode", c => c.String());
            AddColumn("dbo.AbpUsers", "IsAllowDeleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AbpUsers", "GroupId");
            CreateIndex("dbo.AbpUsers", "ProvinceId");
            CreateIndex("dbo.AbpUsers", "CityId");
            CreateIndex("dbo.AbpUsers", "TownId");
            AddForeignKey("dbo.AbpUsers", "CityId", "dbo.pubCities", "Id");
            AddForeignKey("dbo.AbpUsers", "GroupId", "dbo.AbpCustomerGroups", "Id");
            AddForeignKey("dbo.AbpUsers", "ProvinceId", "dbo.pubProvinces", "Id");
            AddForeignKey("dbo.AbpUsers", "TownId", "dbo.Towns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.extSMSTemplates", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.extSMSTemplates", "SMSTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.extSMSTemplates", "LanguageId", "dbo.AbpLanguages");
            DropForeignKey("dbo.extSMSLogs", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.extSMSLogs", "SMSTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.NationTranslations", "CoreId", "dbo.pubNations");
            DropForeignKey("dbo.cmsMessages", "ReplyStatusId", "dbo.pubParameters");
            DropForeignKey("dbo.cmsMessages", "MessageTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.extMailTemplates", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.extMailTemplates", "MailTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.extMailTemplates", "LanguageId", "dbo.AbpLanguages");
            DropForeignKey("dbo.extMailLogs", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.extMailLogs", "MailTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.AbpFunctions", "ParentId", "dbo.AbpFunctions");
            DropForeignKey("dbo.cmsFriendLink", "LinkTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.cmsParametersList", "ParaId", "dbo.cmsParameters");
            DropForeignKey("dbo.cmsParametersList", "ModuleId", "dbo.cmsModules");
            DropForeignKey("dbo.cmsOptionTranslation", "Core_Id", "dbo.cmsOptions");
            DropForeignKey("dbo.cmsOptions", "ParaId", "dbo.cmsParameters");
            DropForeignKey("dbo.CmsParameterTranslations", "Core_Id", "dbo.cmsParameters");
            DropForeignKey("dbo.cmsParameters", "ParaTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.cmsParameters", "ModuleId", "dbo.cmsModules");
            DropForeignKey("dbo.cmsParameters", "ColumnId3", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsParameters", "ColumnId2", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsParameters", "ColumnId1", "dbo.cmsColumns");
            DropForeignKey("dbo.CalendarTranslations", "CoreId", "dbo.extCalendars");
            DropForeignKey("dbo.cmsArticles", "ColumnId3", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsArticles", "ColumnId2", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsArticles", "ColumnId1", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsColumns", "ShowTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.cmsColumns", "ModuleId", "dbo.cmsModules");
            DropForeignKey("dbo.cmsModulesTranslation", "CoreId", "dbo.cmsModules");
            DropForeignKey("dbo.cmsColumns", "BigClassId", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsColumns", "BannerTypeId", "dbo.pubParameters");
            DropForeignKey("dbo.ParameterTranslations", "CoreId", "dbo.pubParameters");
            DropForeignKey("dbo.cmsColumnBanners", "ColumnId", "dbo.cmsColumns");
            DropForeignKey("dbo.cmsColumnBanners", "BannerId", "dbo.cmsBanners");
            DropForeignKey("dbo.extAnnounceAttachements", "AnnounceId", "dbo.extAnnounces");
            DropForeignKey("dbo.extAnnounces", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.AbpUsers", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Towns", "CityId", "dbo.pubCities");
            DropForeignKey("dbo.AbpUsers", "ProvinceId", "dbo.pubProvinces");
            DropForeignKey("dbo.AbpUsers", "GroupId", "dbo.AbpCustomerGroups");
            DropForeignKey("dbo.CustomerGroupTranslations", "CoreId", "dbo.AbpCustomerGroups");
            DropForeignKey("dbo.AbpUsers", "CityId", "dbo.pubCities");
            DropForeignKey("dbo.CityTranslations", "CoreId", "dbo.pubCities");
            DropForeignKey("dbo.pubCities", "ProvinceId", "dbo.pubProvinces");
            DropForeignKey("dbo.ProvinceTranslations", "CoreId", "dbo.pubProvinces");
            DropForeignKey("dbo.extAnnounceAttachements", "AttachmentId", "dbo.extAttachments");
            DropIndex("dbo.extSMSTemplates", new[] { "IsDeleted" });
            DropIndex("dbo.extSMSTemplates", new[] { "TenantId" });
            DropIndex("dbo.extSMSTemplates", new[] { "LanguageId" });
            DropIndex("dbo.extSMSTemplates", new[] { "SMSTypeId" });
            DropIndex("dbo.extSMSLogs", new[] { "SMSTypeId" });
            DropIndex("dbo.extSMSLogs", new[] { "TenantId" });
            DropIndex("dbo.cmsOnlineServices", new[] { "IsDeleted" });
            DropIndex("dbo.NationTranslations", new[] { "CoreId" });
            DropIndex("dbo.pubNations", new[] { "IsDeleted" });
            DropIndex("dbo.cmsMessages", new[] { "IsDeleted" });
            DropIndex("dbo.cmsMessages", new[] { "MessageTypeId" });
            DropIndex("dbo.cmsMessages", new[] { "ReplyStatusId" });
            DropIndex("dbo.extMailTemplates", new[] { "IsDeleted" });
            DropIndex("dbo.extMailTemplates", new[] { "TenantId" });
            DropIndex("dbo.extMailTemplates", new[] { "LanguageId" });
            DropIndex("dbo.extMailTemplates", new[] { "MailTypeId" });
            DropIndex("dbo.extMailLogs", new[] { "TenantId" });
            DropIndex("dbo.extMailLogs", new[] { "MailTypeId" });
            DropIndex("dbo.AbpFunctions", new[] { "IsDeleted" });
            DropIndex("dbo.AbpFunctions", new[] { "ParentId" });
            DropIndex("dbo.cmsFriendLink", new[] { "IsDeleted" });
            DropIndex("dbo.cmsFriendLink", new[] { "LinkTypeId" });
            DropIndex("dbo.cmsParametersList", new[] { "ModuleId" });
            DropIndex("dbo.cmsParametersList", new[] { "ParaId" });
            DropIndex("dbo.cmsOptionTranslation", new[] { "Core_Id" });
            DropIndex("dbo.CmsParameterTranslations", new[] { "Core_Id" });
            DropIndex("dbo.cmsParameters", new[] { "IsDeleted" });
            DropIndex("dbo.cmsParameters", new[] { "ModuleId" });
            DropIndex("dbo.cmsParameters", new[] { "ParaTypeId" });
            DropIndex("dbo.cmsParameters", new[] { "ColumnId3" });
            DropIndex("dbo.cmsParameters", new[] { "ColumnId2" });
            DropIndex("dbo.cmsParameters", new[] { "ColumnId1" });
            DropIndex("dbo.cmsOptions", new[] { "IsDeleted" });
            DropIndex("dbo.cmsOptions", new[] { "ParaId" });
            DropIndex("dbo.CalendarTranslations", new[] { "CoreId" });
            DropIndex("dbo.cmsModulesTranslation", new[] { "CoreId" });
            DropIndex("dbo.cmsModules", new[] { "IsDeleted" });
            DropIndex("dbo.ParameterTranslations", new[] { "CoreId" });
            DropIndex("dbo.pubParameters", new[] { "IsDeleted" });
            DropIndex("dbo.cmsBanners", new[] { "IsDeleted" });
            DropIndex("dbo.cmsColumnBanners", new[] { "ColumnId" });
            DropIndex("dbo.cmsColumnBanners", new[] { "BannerId" });
            DropIndex("dbo.cmsColumns", new[] { "IsDeleted" });
            DropIndex("dbo.cmsColumns", new[] { "BannerTypeId" });
            DropIndex("dbo.cmsColumns", new[] { "BigClassId" });
            DropIndex("dbo.cmsColumns", new[] { "ShowTypeId" });
            DropIndex("dbo.cmsColumns", new[] { "ModuleId" });
            DropIndex("dbo.cmsArticles", new[] { "IsDeleted" });
            DropIndex("dbo.cmsArticles", new[] { "ColumnId3" });
            DropIndex("dbo.cmsArticles", new[] { "ColumnId2" });
            DropIndex("dbo.cmsArticles", new[] { "ColumnId1" });
            DropIndex("dbo.Towns", new[] { "CityId" });
            DropIndex("dbo.CustomerGroupTranslations", new[] { "IsDeleted" });
            DropIndex("dbo.CustomerGroupTranslations", new[] { "CoreId" });
            DropIndex("dbo.AbpCustomerGroups", new[] { "IsDeleted" });
            DropIndex("dbo.CityTranslations", new[] { "CoreId" });
            DropIndex("dbo.ProvinceTranslations", new[] { "CoreId" });
            DropIndex("dbo.pubCities", new[] { "ProvinceId" });
            DropIndex("dbo.AbpUsers", new[] { "TownId" });
            DropIndex("dbo.AbpUsers", new[] { "CityId" });
            DropIndex("dbo.AbpUsers", new[] { "ProvinceId" });
            DropIndex("dbo.AbpUsers", new[] { "GroupId" });
            DropIndex("dbo.extAnnounces", new[] { "IsDeleted" });
            DropIndex("dbo.extAnnounces", new[] { "TenantId" });
            DropIndex("dbo.extAnnounceAttachements", new[] { "AttachmentId" });
            DropIndex("dbo.extAnnounceAttachements", new[] { "AnnounceId" });
            DropColumn("dbo.AbpUsers", "IsAllowDeleted");
            DropColumn("dbo.AbpUsers", "PostCode");
            DropColumn("dbo.AbpUsers", "DetailAddress");
            DropColumn("dbo.AbpUsers", "TownId");
            DropColumn("dbo.AbpUsers", "CityId");
            DropColumn("dbo.AbpUsers", "ProvinceId");
            DropColumn("dbo.AbpUsers", "Remark");
            DropColumn("dbo.AbpUsers", "SocialLink");
            DropColumn("dbo.AbpUsers", "PersonalImage");
            DropColumn("dbo.AbpUsers", "GroupId");
            DropColumn("dbo.AbpUsers", "CustomerCoin");
            DropColumn("dbo.AbpUsers", "CustomerLevel");
            DropColumn("dbo.AbpUsers", "IsCustomer");
            DropTable("dbo.cmsVisitors");
            DropTable("dbo.extSMSTemplates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SMSTemplate_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SMSTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.extSMSLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SMSLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsOnlineServices",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OnlineService_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.NationTranslations");
            DropTable("dbo.pubNations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Nation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsMessages",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Message_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.extMailTemplates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MailTemplate_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MailTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.extMailLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MailLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpFunctions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AbpFunction_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsFriendLink",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FriendLink_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsParametersList");
            DropTable("dbo.cmsOptionTranslation");
            DropTable("dbo.CmsParameterTranslations");
            DropTable("dbo.cmsParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CmsParameter_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsOptions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CmsOption_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CalendarTranslations");
            DropTable("dbo.extCalendars");
            DropTable("dbo.cmsModulesTranslation");
            DropTable("dbo.cmsModules",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Module_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ParameterTranslations");
            DropTable("dbo.pubParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Parameter_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsBanners",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Banner_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsColumnBanners");
            DropTable("dbo.cmsColumns",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Column_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.cmsArticles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Article_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Towns");
            DropTable("dbo.CustomerGroupTranslations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerGroupTranslation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpCustomerGroups",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerGroup_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CityTranslations");
            DropTable("dbo.ProvinceTranslations");
            DropTable("dbo.pubProvinces");
            DropTable("dbo.pubCities");
            DropTable("dbo.extAnnounces",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Announce_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Announce_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.extAttachments");
            DropTable("dbo.extAnnounceAttachements");
        }
    }
}
