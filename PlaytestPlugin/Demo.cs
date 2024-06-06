using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaytestPlugin
{
    public partial class PlaytestPlugin
    {
        public bool isDemoRecording = false;
        private string demoPath = string.Empty;
        private static readonly HttpClient httpClient = new HttpClient();

        public void StartDemo()
        {
            string demoDirectoryPath = Path.Combine(Server.GameDirectory, "csgo", "PlaytestPlugin");
            if (!Directory.Exists(demoDirectoryPath))
            {
                Directory.CreateDirectory(demoDirectoryPath);
            }

            string demoFileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss").Replace(":", "-").Replace(" ", "-") + "_" + Server.MapName + ".dem";
            demoPath = Path.Combine(demoDirectoryPath, demoFileName);

            Logger.LogInformation(demoDirectoryPath);
            Logger.LogInformation(demoPath);

            Server.ExecuteCommand($"tv_record {demoPath}");
            isDemoRecording = true;

            Logger.LogInformation("[PlaytestPlugin] Demo recording started!");
        }

        public async Task EndDemo()
        {

            if (!isDemoRecording)
            {
                return;
            }

            Server.ExecuteCommand("tv_stoprecord");
            isDemoRecording = false;

            Logger.LogInformation("[PlaytestPlugin] Demo recording ended!");

            await WaitForDemo(demoPath);
            await UploadDemo(demoPath);
        }

        public async Task WaitForDemo(string demoPath)
        {
            const int checkInterval = 5000; // 5 seconds
            const int maxRetries = 15; // Check up to 15 times

            bool IsFileReady(string filePath)
            {
                try
                {
                    using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        return true;
                    }
                }
                catch (IOException)
                {
                    return false;
                }
            }

            int retryCount = 0;
            while (retryCount < maxRetries)
            {
                if (File.Exists(demoPath) && IsFileReady(demoPath))
                {
                    Logger.LogInformation("[PlaytestPlugin] Demo file is ready for upload.");
                    break;
                }

                Logger.LogInformation($"[PlaytestPlugin] Demo file not found or in use. Retrying {retryCount + 1}/{maxRetries}...");
                await Task.Delay(checkInterval);
                retryCount++;
            }

            if (retryCount == maxRetries)
            {
                Logger.LogInformation("[PlaytestPlugin] Demo file does not exist or is in use after multiple retries!");
                return;
            }
        }

        public async Task UploadDemo(string demoPath)
        {
            if (!File.Exists(demoPath))
            {
                Logger.LogInformation("[PlaytestPlugin] Demo file not found for upload.");
                return;
            }

            Logger.LogInformation("[PlaytestPlugin] Uploading demo...");

            try
            {
                using var fileStream = new FileStream(demoPath, FileMode.Open, FileAccess.Read);
                using var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                var request = new HttpRequestMessage(HttpMethod.Post, "TEST")
                {
                    Content = fileContent
                };

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInformation("[PlaytestPlugin] Demo upload succeeded.");
                }
                else
                {
                    Logger.LogError($"[PlaytestPlugin] Demo upload failed. Status code: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Logger.LogError($"[PlaytestPlugin] Demo upload failed. Exception: {e.Message}");
            }
        }

    }
}

