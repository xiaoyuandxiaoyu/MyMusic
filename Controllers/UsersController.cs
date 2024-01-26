using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Entityclasses;
using MyMusic.SqlSugar;

namespace MyMusic.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            List<User> users = SqlSugarHelper.Db.Queryable<User>().Where(it => it.Name == user.Name).ToList();
            if (users != null)
            {
               int count =await SqlSugarHelper.Db.Insertable(user).ExecuteCommandAsync();
               if (count > 0)
               {
                    return Ok("创建成功");
               }
               else 
               {
                    return BadRequest("创建失败");
               }
            }
            else
            {
                return BadRequest("用户名已存在");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Login(string username,string password)
        {
           User user= (User)SqlSugarHelper.Db.Queryable<User>().Where(it => it.Name == username);
           if (user == null||user.Password!=password)
           {
                return BadRequest("账户名或密码错误");
           }
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> RevisePassword( User user,string oldpw,string newpw)
        {
            User users =(User)SqlSugarHelper.Db.Queryable<User>().Where(it => it.Id == user.Id);
            if (users.Password != oldpw)
            {
                return BadRequest("修改失败");
            }
            users.Password = newpw;
            var result = SqlSugarHelper.Db.Updateable(users).UpdateColumns(it => new { it.Password }).ExecuteCommand();
            if (result != 0) { return Ok(result);  }
            return BadRequest();
        }
    }
}
