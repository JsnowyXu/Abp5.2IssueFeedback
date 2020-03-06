using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Fun2RepairMVC.FrontEnd.Customers;
using System.ComponentModel.DataAnnotations;
using Fun2RepairMVC.Common.PublicCode;

namespace Fun2RepairMVC.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";
        public const int MaxDescLength = 500;
        public const int MaxInputLength = 200;

        //自定義字段
        public virtual bool IsCustomer { get; set; }//是否是會員
        public virtual int CustomerLevel { get; set; }//用戶等級，備用
        public virtual int CustomerCoin { get; set; }//用戶金幣，備用
        public virtual int? GroupId { get; set; }//會員組
        [StringLength(MaxInputLength)]
        public virtual string PersonalImage { get; set; }//頭像

        [StringLength(MaxInputLength)]
        public virtual string SocialLink { get; set; }//其他社交聯繫方式

        [StringLength(MaxDescLength)]
        public virtual string Remark { get; set; }//個人備註

        public virtual int? ProvinceId { get; set; }
        public virtual int? CityId { get; set; }
        public virtual int? TownId { get; set; }
        [StringLength(MaxInputLength)]
        public virtual string DetailAddress { get; set; }//地址
        public virtual string PostCode { get; set; }//郵編

        [ForeignKey("GroupId")]
        public virtual CustomerGroup Group { get; set; }
        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public virtual bool IsAllowDeleted { get; set; }//是否允許刪除

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}