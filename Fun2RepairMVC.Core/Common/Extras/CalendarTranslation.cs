using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    public class CalendarTranslation:Entity,IEntityTranslation<Calendar>
    {
        public string MonthName { get; set; }

        public string WeekkName { get; set; }

        public Calendar Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
