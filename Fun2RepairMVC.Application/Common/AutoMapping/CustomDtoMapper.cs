using Abp.AutoMapper;
using AutoMapper;
using Fun2RepairMVC.Common.Extras;
using Fun2RepairMVC.Common.PublicCode;
using Fun2RepairMVC.FrontEnd.CMS;
using Fun2RepairMVC.FrontEnd.Customers;

namespace Fun2RepairMVC.Common.AutoMapping
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
        {
            configuration.CreateMultiLingualMap<CmsParameter, CmsParameterTranslation, CmsParameterDto>(context);
            configuration.CreateMultiLingualMap<Calendar, CalendarTranslation, CalendarDto>(context);
            configuration.CreateMultiLingualMap<Nation, NationTranslation, NationDto>(context);
            configuration.CreateMultiLingualMap<Province, ProvinceTranslation, ProvinceDto>(context);
            configuration.CreateMultiLingualMap<City, CityTranslation, CityDto>(context);
            configuration.CreateMultiLingualMap<CustomerGroup, CustomerGroupTranslation, CustomerGroupDto>(context);
            configuration.CreateMultiLingualMap<Parameter, ParameterTranslation, ParameterDto>(context);
            configuration.CreateMultiLingualMap<CmsOption, CmsOptionTranslation, CmsOptionDto>(context);
            configuration.CreateMultiLingualMap<CmsParameter, CmsParameterTranslation, CmsParameterDto>(context);
            configuration.CreateMultiLingualMap<Module, ModuleTranslation, ModuleDto>(context);







        }
    }
}
