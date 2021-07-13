namespace Test.Implementation
{
    using Test.Logger.Services.Model;
    using Test.Interface;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class FileService : IFileService
    {
        private readonly IOptions<Config> config;
        public FileService(IOptions<Config> config)
        {
            this.config = config;
        }
        public async Task WriteLineAsync(Message message)
        {        
            using (var writer = File.AppendText(GetFilePath()))
            {
               await writer.WriteLineAsync(string.Format("{0}--{1}--{2}", message.Id, message.CreatedAt, message.Messages));                
            };                
        }       

        #region private
      
        private string GetFilePath() => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + this.config.Value.FileName;

        #endregion
    }
}
