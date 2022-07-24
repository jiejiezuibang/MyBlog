using MyBlog.IResposeitory;
using MyBlogMod;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Reposeitory
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>,IBaseRepository<TEntity> where TEntity : class, new()
    {
        // di注入
        public BaseRepository(ISqlSugarClient context):base(context)
        {
            base.Context = DbScoped.Sugar;

            //如果不存在创建数据库存在不会重复创建 
            base.Context.DbMaintenance.CreateDatabase();
            // 创建表
            base.Context.CodeFirst.SetStringDefaultLength(200)
.InitTables(typeof(BlogNews), typeof(TypeInfo),typeof(WriterInfo));
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().Where(func).ToPageListAsync(page,size, total);
        }
    }
}
