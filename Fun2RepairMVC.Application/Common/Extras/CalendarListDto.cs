
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
namespace Fun2RepairMVC.Common.Extras
{
    [AutoMap(typeof(Calendar))]
    public class CalendarListDto:EntityDto
    {
        public virtual string FullDateAlternateKey { get; set; }
        public virtual int DayNumberOfWeek { get; set; }
        public virtual int DayNumberOfMonth { get; set; }
        public virtual int DayNumberOfYear { get; set; }
        public virtual int WeekyNumberOfYear { get; set; }
        public virtual int MonthNumberOfYear { get; set; }
        public virtual int CalendarQuarter { get; set; }
        public virtual int CalendarSemester { get; set; }
        public virtual int CalendarYear { get; set; }
    }
}
