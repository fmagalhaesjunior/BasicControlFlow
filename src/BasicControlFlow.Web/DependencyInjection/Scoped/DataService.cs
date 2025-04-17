namespace BasicControlFlow.Web.DependencyInjection.Scoped
{
    public class DataService : IDataService
    {
        public string GetData()
        {
            return "Dados simulados.";
        }
    }
}
