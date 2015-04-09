using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Onecloud.Video.RestfulApi.Demo
{
    class Program
    {
        private static Client Client = new Client("*请在这里填写你的appKey*", "*请在这里填写你的appSecret*");

        static void Main(string[] args)
        {
            CreateCatalog();
            GetVideo();
            UploadVideo();
        }

        /**
         * 创建一个目录，该例子演示如何调用 Client 的 HttpPost 方法。
         */
        private static String CreateCatalog()
        {
            QueryString qs = new QueryString();
            qs.Add("name", "教育视频");
            return Client.HttpPost("/catalog/create.api", qs);
        }

        /**
         * 获得一个视频的信息，该例子演示如何调用 Client 的 HttpGet 方法
         */
        private static String GetVideo()
        {
            QueryString qs = new QueryString();
            qs.Add("videoId", 1 + "");
            return Client.HttpGet("/video/get.api", qs);
        }

        /**
         * 上传一个文件，该例子演示如何调用 Client 的 HttpUpload 方法
         */
        private static String UploadVideo()
        {
            QueryString qs = new QueryString();
            qs.Add("name", "aaa.mp3");
            qs.Add("catalogId", 10 + "");
            using (var fs = File.OpenRead(@"d:\a.mp3"))
            {
                Console.WriteLine(fs.Length);
                Console.WriteLine(Path.GetFileName(fs.Name));
                return Client.HttpUpload("/video/upload.api", qs, fs);
            }
        }

    }
}
