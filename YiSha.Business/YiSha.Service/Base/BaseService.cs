using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YiSha.Data.Repository;
using YiSha.Entity;
using YiSha.Util.Extension;

namespace YiSha.Service.Base
{
    public class BaseService : RepositoryFactory
    {


        public async Task<List<R>> GetEntitys<T, R>(T param)
           where T : class, new()
           where R : class, new()
        {
            var expression = ListFilter<T, R>(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }


        protected Expression<Func<R, bool>> ListFilter<T, R>(T param)
            where T : class, new()
            where R : class, new()
        {
            var expression = LinqExtensions.True<R>();
            if (param != null)
            {
                foreach (PropertyInfo item in param.GetType().GetProperties())
                {
                    var val = item.GetValue(param);
                    if (val != null && !val.IsEmpty())
                    {
                        PropertyInfo pro = typeof(R).GetProperty(item.Name);
                        if (pro == null) { continue; }
                        expression = expression.And(t => item.Name == val.ToString());
                    }
                }
            }
            return expression;
        }
    }
}
