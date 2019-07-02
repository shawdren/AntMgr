using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Configuration;
using DbModel;
using ant.mgr.core.Filter;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using ServicesModel;
using ViewModels.Result;
using ViewModels.Reuqest;

namespace ant.mgr.core.Controllers
{
    [AuthorizeFilter]
    [API("公司管理")]
    public class SysCompanyController : BaseController
    {
        private readonly ISysCompanyRespository SysCompanyRespository;
        public SysCompanyController(ISysCompanyRespository _SysCompanyRespository)
        {
            SysCompanyRespository = _SysCompanyRespository;
        }

        /// <summary>
        /// 进入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SysCompany()
        {
            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [API("获取列表")]
        public async Task<JsonResult> GetSysCompanyList(SysCompanyVm model)
        {
            var result = new SearchResult<List<SysCompany>>();
            var respositoryResult = await SysCompanyRespository.GetSysCompanyList(model);
            result.Status = ResultConfig.Ok;
            result.Info = ResultConfig.SuccessfulMessage;
            result.Rows = respositoryResult.Item2;
            result.Total = respositoryResult.Item1;
            return Json(result);
        }

        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <returns></returns>
        [API("添加或修改")]
        public JsonResult AddSysCompany([FromForm] SysCompany model)
        {
            var result = new ResultJsonNoDataInfo();
            var respositoryResult = SysCompanyRespository.AddSysCompany(model);
            if (string.IsNullOrEmpty(respositoryResult))
            {
                result.Status = ResultConfig.Ok;
                result.Info = ResultConfig.SuccessfulMessage;
            }
            else
            {
                result.Status = ResultConfig.Fail;
                result.Info = string.IsNullOrEmpty(respositoryResult) ? ResultConfig.FailMessage : respositoryResult;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [API("删除")]
        public async Task<JsonResult> DelSysCompany([FromForm] long tid)
        {
            var result = new ResultJsonNoDataInfo();
            var respositoryResult = await SysCompanyRespository.DelSysCompany(tid);
            if (string.IsNullOrEmpty(respositoryResult))
            {
                result.Status = ResultConfig.Ok;
                result.Info = ResultConfig.SuccessfulMessage;
            }
            else
            {
                result.Status = ResultConfig.Fail;
                result.Info = string.IsNullOrEmpty(respositoryResult) ? ResultConfig.FailMessage : respositoryResult;
            }
            return Json(result);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <returns></returns>
        [API("下载")]
        public async Task<JsonResult> DownloadData([FromForm] long tid)
        {
            var result = new ResultJsonNoDataInfo();
             await Task.FromResult(1);
            return Json(result);
            
        }


    }

}