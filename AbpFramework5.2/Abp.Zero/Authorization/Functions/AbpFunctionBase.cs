using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNet.Identity;

namespace Abp.Authorization.Functions
{
    public class AbpFunctionBase : FullAuditedEntity<int>
    {
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MaxNameLength = 100;
        /// <summary>
        /// Unique name of this role.
        /// </summary>
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
    }
}
