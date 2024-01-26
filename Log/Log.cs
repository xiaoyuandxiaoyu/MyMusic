namespace MyMusic.Log
{
    //日志服务
    public class Log
    {
        ServiceCollection services=new ServiceCollection(); 
        //Error错误已经发生
        public void ErrorLog(string ex)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            using(var log = services.BuildServiceProvider())
            {
                var logger=log.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex);
            }
        }
        //Warn比如响应速度慢、连接断开、内存吃紧等等
        public void WarnLog(string ex)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            using (var log = services.BuildServiceProvider())
            {
                var logger = log.GetRequiredService<ILogger<Program>>();
                logger.LogWarning(ex);
            }
        }
        //Info一个操作或状态发生了变化
        public void InfoLog(string ex)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            using (var log = services.BuildServiceProvider())
            {
                var logger = log.GetRequiredService<ILogger<Program>>();
                logger.LogInformation(ex);
            }
        }
        //Debug
        public void DebugLog(string ex)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            using (var log = services.BuildServiceProvider())
            {
                var logger = log.GetRequiredService<ILogger<Program>>();
                logger.LogDebug(ex);
            }
        }
        //Trace调用了什么
        public void TraceLog(string ex)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            using (var log = services.BuildServiceProvider())
            {
                var logger = log.GetRequiredService<ILogger<Program>>();
                logger.LogTrace(ex);
            }
        }
    }
}
