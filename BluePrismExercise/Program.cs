using BluePrismExercise;
using BluePrismExercise.Interfaces;
using BluePrismExercise.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace BluePrism
{
    public class Program
    {
        private static IOptions<Configurations> configs;
        private static  IConfigurationRoot Configuration { get; set; }

        private static IWorkerService _inputHandler;

        private static ITextWriter _writer;

        static Program()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            configs = serviceProvider.GetService<IOptions<Configurations>>();
            _inputHandler = serviceProvider.GetService<IWorkerService>();
            _writer = serviceProvider.GetService<ITextWriter>();
        }
        static async Task Main(string[] args)
        {
            var startWord = args[0];
            var endWord = args[1];

           var result =  await _inputHandler.Run(startWord.ToUpperInvariant(), endWord.ToUpperInvariant());
            _writer.WriteLine(result);
            _writer.ReadLine();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            services.AddOptions();

            Configuration = builder.Build();
            var section = Configuration.GetSection("Configurations");

            services.Configure<Configurations>(section);
            services
                .AddScoped<IWordService, WordService>()
                .AddScoped<IFileService, FileService>()
                .AddScoped<IWorkerService, WorkerService>()
                .AddScoped<ITextWriter, BluePrismExercise.Helpers.TextWriter>();
        }
    }
}
