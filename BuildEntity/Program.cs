using System;
using System.Linq;
using SqlSugar;

namespace BuildEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据库对象 SqlSugarClient   
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=124.222.9.173;Database=antd_pro_shop_admin;Uid=root;Pwd=123456;",//连接符字串
                DbType = DbType.MySql, //数据库类型
                IsAutoCloseConnection = true //不设成true要手动close
            });

            foreach (var item in db.DbMaintenance.GetTableInfoList())
            {
                string entityName = String.Empty;
                foreach (var itemInfo in item.Name.Split('_'))
                {
                    entityName += itemInfo.Substring(0, 1).ToUpper() + itemInfo.Substring(1, itemInfo.Length - 1);
                }
                // string entityName = item.Name.Substring(0, 1).ToUpper() + item.Name.Substring(1, item.Name.Length - 1);/*实体名大写*/
                db.MappingTables.Add(entityName.Replace("Sys", ""), item.Name);
                foreach (var col in db.DbMaintenance.GetColumnInfosByTableName(item.Name))
                {
                    db.MappingColumns.Add(col.DbColumnName.Substring(0, 1).ToUpper() +
                                          col.DbColumnName.Substring(1, col.DbColumnName.Length - 1)
                        /*类的属性大写*/, col.DbColumnName, entityName.Replace("Sys", ""));
                }
            }
            // foreach (var item in db.DbMaintenance.GetTableInfoList())
            // {
            //     string entityName = item.Name.ToUpper();/*实体名大写*/
            //     db.MappingTables.Add(entityName , item.Name);
            //     foreach (var col in db.DbMaintenance.GetColumnInfosByTableName(item.Name))
            //     {
            //         db.MappingColumns.Add(col.DbColumnName.ToUpper() /*类的属性大写*/, col.DbColumnName, entityName);
            //     }
            // }
            db.DbFirst.IsCreateAttribute().CreateClassFile(AppDomain.CurrentDomain.BaseDirectory + "/Entity", "Entity");
        }
    }
}