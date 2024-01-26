using SqlSugar;

namespace MyMusic.Entityclasses
{
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Email { get; set; }
        [SugarColumn(IsNullable = true)]
        public int PhoneNumber {  get; set; }
    }
}
