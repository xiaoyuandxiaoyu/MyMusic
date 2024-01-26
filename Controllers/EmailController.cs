using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MyMusic.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
        [HttpPost]
        ///toAddress收件人，Captcha验证码
        public async Task<ActionResult<bool>> SendEmail(string toAddress)
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("3417286833@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(toAddress));
            //抄送人邮箱地址。
            //message.CC.Add(sender);
            //邮件标题。
            mailMessage.Subject = "欢迎注册";
            string Captcha=GenerateRandomString(6);
            //邮件内容。
            mailMessage.Body = $"您的验证码为{Captcha}！";
            //是否支持内容为HTML。
            //mailMessage.IsBodyHtml = true;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            //在这里使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            //client.Host = "smtp.163.com";
            client.Host = "smtp.qq.com";
            //使用安全加密连接（是否启用SSL）
            client.EnableSsl = true;
            //设置超时时间
            //client.Timeout = 10000;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("3417286833@qq.com", "panacfqirarxdbfa");//szcodirtgvjgbfii
            //网易邮箱客户端授权码DJURBEKTXEWXQATX
            //client.Credentials = new NetworkCredential("liulijun3236@163.com", "ZAJDNCKWHUBHQIMY");
            try
            {
                //发送
                client.Send(mailMessage);
                return Ok();
                //发送成功
            }
            catch (Exception ex)//发送异常
            {
                return BadRequest(ex);
                //发送失败
                //System.IO.File.WriteAllText(@"C:\test.txt", e.ToString(), Encoding.UTF8);
            }
        }
        
    }
}
