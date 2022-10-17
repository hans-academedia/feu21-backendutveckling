namespace _01_WebApi_Sql.Services
{
    public interface IFileManager
    {
        public Task SaveAsync(string filePath, string content);
        public Task<string> ReadAsync(string filePath);
    }


    public class FileManager : IFileManager
    {
        public async Task<string> ReadAsync(string filePath)
        {
            using var sr = new StreamReader(filePath);
            return await sr.ReadToEndAsync();
        }

        public async Task SaveAsync(string filePath, string content)
        {
            using var sw = new StreamWriter(filePath);
            await sw.WriteLineAsync(content);
        }


        public string Read(string filePath)
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }

        public void Save(string filePath, string content)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }
    }
}
