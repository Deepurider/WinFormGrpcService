namespace WinFormsApp1.Config
{
    public interface IConfiguration
    { 
        string ServiceUrl { get; set; }  
    }

    public class Configuration : IConfiguration
    {
        public string? ServiceUrl { get; set;}
    }
}
