using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Service.OrganizationManage;
using YiSha.Model.Result;

namespace YiSha.Business.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-23 22:28
    /// 描 述：业务类
    /// </summary>
    public class DepartmentTypeBLL
    {
        private DepartmentTypeService departmentTypeService = new DepartmentTypeService();

        #region 获取数据
        public async Task<TData<List<DepartmentTypeEntity>>> GetList(DepartmentTypeListParam param)
        {
            TData<List<DepartmentTypeEntity>> obj = new TData<List<DepartmentTypeEntity>>();
            obj.Result = await departmentTypeService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<DepartmentTypeEntity>>> GetPageList(DepartmentTypeListParam param, Pagination pagination)
        {
            TData<List<DepartmentTypeEntity>> obj = new TData<List<DepartmentTypeEntity>>();
            obj.Result = await departmentTypeService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<DepartmentTypeEntity>> GetEntity(long id)
        {
            TData<DepartmentTypeEntity> obj = new TData<DepartmentTypeEntity>();
            obj.Result = await departmentTypeService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<List<ZtreeInfo>>> GetDepartmentTypeSelectList(DepartmentTypeListParam param)
        {
            List<DepartmentTypeEntity> departmentTypeList = await departmentTypeService.GetList(param);
            TData<List<ZtreeInfo>> resultList = new TData<List<ZtreeInfo>>() { Result = new List<ZtreeInfo>(), Tag = 1 };
            departmentTypeList.ForEach(item =>
            {
                resultList.Result.Add(new ZtreeInfo()
                {
                    id = item.Id,
                    name = item.TypeName
                });
            });
            return resultList;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(DepartmentTypeEntity entity)
        {
            TData<string> obj = new TData<string>();
            await departmentTypeService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await departmentTypeService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
