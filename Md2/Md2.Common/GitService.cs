using System.Net;

namespace Md2.Common
{
    public class GitService
    {
        public void DownloadRepo(string uri, string folder, string subFolder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, uri);
            req.Headers.Add("User-Agent", "Mozilla/5.0");

            var response = client.Send(req);
            response.EnsureSuccessStatusCode();

            var filename = response.Content.Headers?.ContentDisposition?.FileName ?? "repo.zip";
            var downloadFileName = Path.Combine(folder, filename);
            if (File.Exists(downloadFileName))
                File.Delete(downloadFileName);

            using var ms = response.Content.ReadAsStream();
            using var fs = File.Create(downloadFileName);
            ms.Seek(0, SeekOrigin.Begin);
            ms.CopyTo(fs);
            fs.Close();

            var zipFolderName = filename.Replace(".zip", "");
            var unzipFolderName = Path.Combine(folder, zipFolderName);
            if (Directory.Exists(unzipFolderName))
                Directory.Delete(unzipFolderName, true);

            new ZipService().Unzip(downloadFileName, folder);
            File.Delete(downloadFileName);
            
            Directory.Move(unzipFolderName, Path.Combine(folder, subFolder));
        }
    }
}