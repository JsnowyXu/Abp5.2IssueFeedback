using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;


namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Town))]
    public class TownDto:EntityDto
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int CityId { get; set; }

    }
}
