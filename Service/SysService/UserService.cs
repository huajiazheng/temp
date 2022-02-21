using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using SqlSugar;

namespace Service.SysService
{
    public class UserService
    {
        private readonly ISqlSugarClient _db;

        public UserService(ISqlSugarClient db)
        {
            _db = db;
        }
        
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<IList<User>> GetUserList()
        {
            return await _db.Queryable<User>().ToListAsync();
        }
    }
}