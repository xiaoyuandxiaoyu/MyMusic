using SqlSugar;

namespace MyMusic.SqlSugar
{
    public class SqlSugarHelper
    {
        public static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Music;Trusted_Connection=True;",//连接符字串
            DbType = DbType.SqlServer,//数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        });
    }
}
