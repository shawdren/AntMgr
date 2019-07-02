using AntData.ORM;
using AntData.ORM.Linq;
using Autofac.Annotation;
using Castle.DynamicProxy;
using Configuration;
using DbModel;
using Infrastructure.Logging;
using Infrastructure.StaticExt;
using Infrastructure.Web;
using Repository.Interface;
using ServicesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Reuqest;


namespace Repository
{
    [Bean(typeof(ISysCompanyRespository), Interceptor = typeof(AsyncInterceptor))]
    public class SysCompanyRespository : BaseRepository<SysCompany>, ISysCompanyRespository
    {

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="model">-VM对象</param>
        /// <returns></returns>
        public async Task<Tuple<long, List<SysCompany>>> GetSysCompanyList(SysCompanyVm model)
        {
            if (model == null) { return new Tuple<long, List<SysCompany>>(0, new List<SysCompany>()); }

            var totalQuery = this.Entity;
            var listQuery = this.Entity;

            //这里开始写条件
            
            var total = totalQuery.CountAsync();
            var list = await listQuery.DynamicOrderBy(string.IsNullOrEmpty(model.OrderBy) ? "DataChangeLastTime" : model.OrderBy,
                           model.OrderSequence)
                           .Skip((model.PageIndex - 1) * model.PageSize)
                           .Take(model.PageSize)
                           .ToListAsync();

            return new Tuple<long, List<SysCompany>>(await total, list);
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="model">-对象</param>
        /// <returns></returns>
        public string AddSysCompany(SysCompany model)
        {
            if (model == null)
            {
                return Tip.BadRequest;
            }

            if (model.Tid > 0)
            {
                
                model.DataChangeLastTime = DateTime.Now;
                //修改
                var update = this.DB.Update(model) > 0;
                if (!update)
                {
                    return Tip.UpdateError;
                }
            }
            else
            {
                var result = this.DB.Insert(model) > 0;
                if (!result)
                {
                    return Tip.InserError;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tid">的主键</param>
        /// <returns></returns>
        public async Task<string> DelSysCompany(long tid)
        {
            var result = await this.Entitys.Get<SysCompany>().Where(r => r.Tid.Equals(tid)).DeleteAsync() > 0;
            return !result ? Tip.DeleteError : string.Empty;
        }



    }
}
