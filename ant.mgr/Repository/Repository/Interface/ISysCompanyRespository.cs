using DbModel;
using ViewModels.Reuqest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    
    /// <summary>
    /// 接口
    /// </summary>
    public interface ISysCompanyRespository : IRepository<SysCompany>
    {
        Task<Tuple<long, List<SysCompany>>> GetSysCompanyList(SysCompanyVm model);
        string AddSysCompany(SysCompany model);
        Task<string> DelSysCompany(long tid);
    }
}