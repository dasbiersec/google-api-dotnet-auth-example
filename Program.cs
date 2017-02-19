using System.IO;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Compute.v1;

namespace ConsoleApplication
{
    /// This is just a collection of code snippets for this. It's confusing and maybe this will help somebody
    public class Program
    {
        public static void Main(string[] args) {} 

        /// <summary>
        /// How to Authenticate and use the Google API Client Library. NOT THE GOOGLE CLOUD LIBRARY. They are different
        /// </summary>
        public void HowToAuthenticate(string[] args)
        {
            // These next two sections of code took me forever... It's so fuckin fragmented, there
            // are examples everywhere and they all vary... So annoying
            var credential = GoogleCredential.FromJson(File.ReadAllText("credentials.json"))
                                             .CreateScoped(new [] { ComputeService.Scope.CloudPlatform, ComputeService.Scope.Compute });

            var service = new ComputeService(new BaseClientService.Initializer {
                HttpClientInitializer = credential, 
                ApplicationName = "example"
            });

            // Example of now running a command
            service.Instances.Stop("project", "zone", "instance-name").Execute();
        }
    }
}
