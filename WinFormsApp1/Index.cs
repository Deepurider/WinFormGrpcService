using Microsoft.Extensions.Options;
using WinFormsApp1.Config;

namespace WinFormsApp1
{
    public partial class Index : Form
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public Index(HttpClient httpClient, IOptions<Configuration> config)
        {
            _httpClient = httpClient;
            _config = config.Value;
            InitializeComponent();
            CreateDynamicButton();  
        }

        private void Index_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
        }
    }
}
