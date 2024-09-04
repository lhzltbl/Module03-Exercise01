using Module02Exercise01.View;
using System.Diagnostics;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        //for offline page: reqbinz
        //for online page: facebook
        private const string TestUrl = "https://facebook.com/";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = new LoginPage();
                Debug.WriteLine("Application Started");
            }
            else
            {
                MainPage = new OfflinePage();
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
