using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using System.Globalization;

namespace Fun2RepairMVC.Common.PublicCode
{
    public class ParametersManager:DomainService
    {

        private readonly IRepository<Parameter> _parameterRepository;

        public ParametersManager(IRepository<Parameter> parameterRepository)
        {
    
            _parameterRepository = parameterRepository;
        }

      
        /// <summary>
        ///新增時判斷是否存在參數代碼
        /// </summary>
        /// <param name="rollcall"></param>
        /// <returns></returns>
        public bool IsParaExists(Parameter para)
        {
            var exists = _parameterRepository.GetAll().Where(x => x.Code == para.Code&& x.Type==para.Type).FirstOrDefault();
            return exists != null;
        }
        /// <summary>
        /// 創建基本參數
        /// </summary>
        /// <param name="para"></param>
        /// <param name="TextValue"></param>
        /// <param name="LanguageCode"></param>
        /// <returns></returns>
        public async Task CreateParameterAsync(Parameter para,string TextValue,string LanguageCode)
        {
            
            await _parameterRepository.InsertAsync(para);
        }

      
        
    }
}
