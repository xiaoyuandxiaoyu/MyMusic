using MyMusic.Entityclasses;

namespace MyMusic.SqlSugar
{
    public class SqlSugarCreateDatabase
    {
        public void CreateDatabase()
        {
            ///建库：如果不存在创建数据库存在不会重复创
            SqlSugarHelper.Db.DbMaintenance.CreateDatabase();
            //创建表：根据实体类CodeFirstTable1  (所有数据库都支持)    
            SqlSugarHelper.Db.CodeFirst.InitTables(typeof(User));//这样一个表就能成功创建了
        }
    }
}
