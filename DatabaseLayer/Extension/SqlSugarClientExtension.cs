using SqlSugar;

namespace DatabaseLayer.Extension
{
    public static class SqlSugarClientExtension
    {
        public static ISugarQueryable<T> QueryableActive<T>(this ISqlSugarClient db)
        {
            return db.Queryable<T>();
        }
    }
}