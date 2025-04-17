namespace BasicControlFlow.Web.DependencyInjection.Singleton
{
    public class LogService : ILogService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
