using Example;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PictureCaiji
{
    public class HuaBanCaiji2
    {

        private int groupId = 0;
        private string savePath = string.Empty;

        private int picId = 0;

        public HuaBanCaiji2(int groupId, string savePath, int picId)
        {

            this.groupId = groupId;
            this.savePath = savePath;
            this.picId = picId;
        }


        bool isEnd = false;
        public string GroupTitle { get; set; }
        public void Start()
        {
            isEnd = false;
            imgList = new List<string>();
            baseUrl = string.Format(baseUrl, groupId);


            string htmlContent = YM(baseUrl);

            var startIndex = htmlContent.IndexOf("app.page[\"board\"] = ");

            var endIndex = htmlContent.IndexOf("app._csr = true");

            var jsonStr = htmlContent.Substring(startIndex, endIndex - startIndex).Replace("app.page[\"board\"] = ", "").Trim().Trim(';');


            PicturesInfo pinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<PicturesInfo>(jsonStr);
            if (pinfo != null && pinfo.Pins.Length > 0)
            {
                GroupTitle = pinfo.Title;
                int maxId = pinfo.Pins[0].PinId.Value;
                Caiji(groupId, maxId + 1);
            }




            DownloadImgs();


        }




        string baseUrl = "http://huaban.com/boards/{0}/";
        public List<string> imgList = new List<string>();
        string caijiUrl = "http://huaban.com/boards/{0}/?irhi47bf&max={1}&limit=50&wfl=1";

        private void Caiji(int groupId, int maxId)
        {
            string htmlContent = YM(string.Format(caijiUrl, groupId, maxId));

            var startIndex = htmlContent.IndexOf("app.page[\"board\"] = ");

            var endIndex = htmlContent.IndexOf("app._csr = true");

            var jsonStr = htmlContent.Substring(startIndex, endIndex - startIndex).Replace("app.page[\"board\"] = ", "").Trim().Trim(';');


            PicturesInfo pinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<PicturesInfo>(jsonStr);


            if (pinfo != null && pinfo.Pins.Length > 0)
            {
                foreach (var item in pinfo.Pins)
                {
                    string imgUrl = "http://" + item.File.Bucket + ".b0.upaiyun.com/" + item.File.Key;

                    imgList.Add(imgUrl);

                }

                Caiji(groupId, pinfo.Pins[pinfo.Pins.Length - 1].PinId.Value);

            }
            else
            {
                isEnd = true;
            }

        }









        //获得网址原代码
        private string YM(string Url)
        {
            string strResult = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
            }
            catch { }

            return strResult;
        }

        List<Task> taskList = new List<Task>();
        private void DownloadImgs()
        {
            taskList = new List<Task>();
            if (Directory.Exists(savePath + "\\" + GroupTitle) == false)
            {
                Directory.CreateDirectory(savePath + "\\" + GroupTitle);
            }

            int i = 0;
            foreach (var item in imgList)
            {


                i += 1;

                if (i == picId)
                {



                    string filepath = savePath + "\\" + GroupTitle + "\\" + i.ToString() + ".jpg";
                    WebClient mywebclient = new WebClient();
                    var t = Task.Factory.StartNew(() => mywebclient.DownloadFile(item, filepath));
                    taskList.Add(t);
                    break;

                }
            }



            Task.Factory.StartNew(() => CheckDownState());


        }


        public Action ShowInfo { get; set; }
        //public delegate void ShowInfoHandler();
        //public event ShowInfoHandler ShowInfo;

        private void CheckDownState()
        {
            while (true)
            {
                taskList.RemoveAll(t => t.IsCompleted);

                if (taskList.Count == 0)
                {
                    ShowInfo();
                    break;
                }
            }
        }
    }
}
