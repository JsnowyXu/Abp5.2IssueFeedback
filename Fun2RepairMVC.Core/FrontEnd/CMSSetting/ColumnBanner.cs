using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsColumnBanners")]
    public class ColumnBanner : Entity
    {
        public int BannerId { get; set; }
        public int ColumnId { get; set; }
        [ForeignKey("BannerId")]
        public virtual Banner Banner { get; set; }
        [ForeignKey("ColumnId")]
        public virtual Column Column { get; set; }
    }
}
