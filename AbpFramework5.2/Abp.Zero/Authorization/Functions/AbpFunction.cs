using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abp.Authorization.Functions
{
    [Table("AbpFunctions")]
    public class AbpFunction:AbpFunctionBase
    {

            [Required]
            [StringLength(64)]
            public virtual string DisplayName { get; set; }
            /// <summary>
            /// 是否是菜單
            /// </summary>
            public virtual bool IsMenu { get; set; }
            /// <summary>
            /// 是否是前台頁面
            /// </summary>
            public virtual bool IsWebPage { get; set; }
            /// <summary>
            /// 是否有效
            /// </summary>
            public virtual bool IsEnable { get; set; }
            /// <summary>
            /// 是否可見
            /// </summary>
            public virtual bool IsVisible { get; set; }

            [StringLength(32)]
            public virtual string Icon { get; set; }
            [StringLength(64)]
            public virtual string Url { get; set; }

            public virtual bool RequiresAuthentication { get; set; }
            /// <summary>
            /// 排序
            /// </summary>
            public virtual int Sequence { get; set; }

            public Abp.MultiTenancy.MultiTenancySides MultiTenancySides { get; set; }
            public int? ParentId { get; set; }

            [ForeignKey("ParentId")]
            public virtual AbpFunction Parent { get; set; }

            public virtual ICollection<AbpFunction> Children { get; set; }
        }
    
}
