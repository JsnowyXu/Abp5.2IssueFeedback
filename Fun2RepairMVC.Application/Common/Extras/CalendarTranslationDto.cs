using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.Extras
{
    [AutoMap(typeof(CalendarTranslation))]
    public class CalendarTranslationDto
    {
        public string MonthName { get; set; }
        public string WeekkName { get; set; }
        public string Language { get; set; }
    }
}
