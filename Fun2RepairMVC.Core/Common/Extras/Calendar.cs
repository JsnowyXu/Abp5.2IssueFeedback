using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    [Table("extCalendars")]
    public class Calendar : Entity,IMultiLingualEntity<CalendarTranslation>
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]//不自动增长
        public override int Id { get; set; }
        public virtual string FullDateAlternateKey { get; set; }
        public virtual int DayNumberOfWeek { get; set; }
        public virtual int DayNumberOfMonth { get; set; }
        public virtual int DayNumberOfYear { get; set; }
        public virtual int WeekyNumberOfYear { get; set; }
        public virtual int MonthNumberOfYear { get; set; }
        public virtual int CalendarQuarter { get; set; }
        public virtual int CalendarSemester { get; set; }
        public virtual int CalendarYear { get; set; }

        public ICollection<CalendarTranslation> Translations { get; set; }
    }
}
