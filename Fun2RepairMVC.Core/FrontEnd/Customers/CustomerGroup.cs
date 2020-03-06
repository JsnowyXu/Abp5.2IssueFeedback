using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.Customers
{
    [Table("AbpCustomerGroups")]
    public class CustomerGroup: FullAuditedEntity,IMultiLingualEntity<CustomerGroupTranslation>
    {
        /// <summary>
        /// 是否是默認：用戶自動歸類此會員組
        /// </summary>
        public virtual bool IsDefault { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 是否是系統默認：無法刪除，數據庫設定
        /// </summary>
        public virtual bool IsStatic { get; set; }
        /// <summary>
        /// 會員組功能備註
        /// </summary>
        [StringLength(500)]
        public virtual string Description { get; set; }
        public ICollection<CustomerGroupTranslation> Translations { get; set; }

    }
}
