using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.MP.Sample.CommonService.JuHeAPI.Model;
using System.IO;

namespace Senparc.Weixin.MP.Sample.CommonService.JuHeAPI
{
    public class JuHe
    {
       public  static string GetXiaohua(string ptype)
        {
            string appkey = "158af5886125ed42820e14a4212bb378"; //配置您申请的appkey


            //2.随机笑话
            string url2 = "http://v.juhe.cn/joke/randJoke.php";

            var parameters2 = new Dictionary<string, string>();
            if (ptype == "趣图")
            {
                parameters2.Add("type", ptype);
            }
            parameters2.Add("key", appkey);//你申请的key

            string result2 = sendPost(url2, parameters2, "get");

            var msgJson = JsonConvert.DeserializeObject<XiaoHuaResponse>(result2);

            if (msgJson != null && msgJson.Result != null &&  msgJson.Result.Length > 0)
            {
                if (ptype == "趣图")
                {
                    return msgJson.Result[0].Url;

                }
                else
                {
                    return msgJson.Result[0].Content;
                }
            }
            else
            {
                return "暂无笑话";
            }



            ////3.按更新时间查询趣图
            //string url3 = "http://japi.juhe.cn/joke/img/list.from";

            //var parameters3 = new Dictionary<string, string>();

            //parameters3.Add("sort", ""); //类型，desc:指定时间之前发布的，asc:指定时间之后发布的
            //parameters3.Add("page", ""); //当前页数,默认1
            //parameters3.Add("pagesize", ""); //每次返回条数,默认1,最大20
            //parameters3.Add("time", ""); //时间戳（10位），如：1418816972
            //parameters3.Add("key", appkey);//你申请的key

            //string result3 = sendPost(url3, parameters3, "get");

            //JsonObject newObj3 = new JsonObject(result3);
            //String errorCode3 = newObj3["error_code"].Value;

            //if (errorCode3 == "0")
            //{
            //    Debug.WriteLine("成功");
            //    Debug.WriteLine(newObj3);
            //}
            //else
            //{
            //    //Debug.WriteLine("失败");
            //    Debug.WriteLine(newObj3["error_code"].Value + ":" + newObj3["reason"].Value);
            //}


            ////4.最新趣图
            //string url4 = "http://japi.juhe.cn/joke/img/text.from";

            //var parameters4 = new Dictionary<string, string>();

            //parameters4.Add("page", ""); //当前页数,默认1
            //parameters4.Add("pagesize", ""); //每次返回条数,默认1,最大20
            //parameters4.Add("key", appkey);//你申请的key

            //string result4 = sendPost(url4, parameters4, "get");

            //JsonObject newObj4 = new JsonObject(result4);
            //String errorCode4 = newObj4["error_code"].Value;

            //if (errorCode4 == "0")
            //{
            //    Debug.WriteLine("成功");
            //    Debug.WriteLine(newObj4);
            //}
            //else
            //{
            //    //Debug.WriteLine("失败");
            //    Debug.WriteLine(newObj4["error_code"].Value + ":" + newObj4["reason"].Value);
            //}


        }

        /// <summary>
        /// Http (GET/POST)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <returns>响应内容</returns>
        static string sendPost(string url, IDictionary<string, string> parameters, string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            else
            {
                //创建请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

                //GET请求
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

                //返回内容
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(System.Web.HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(System.Web.HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }



        public static string GetJiqiren(string message)
        {
            //http://api.qingyunke.com/api.php?key=free&appid=0&msg=

            string url = "http://api.qingyunke.com/api.php";

            var parameters = new Dictionary<string, string>();


            parameters.Add("key", "free");//你申请的key
            parameters.Add("appid", "0");
            parameters.Add("msg", message);

            string result2 = sendPost(url, parameters, "get");

            var msgJson = JsonConvert.DeserializeObject<JiqirenResponse>(result2);

            if (msgJson != null)
            {
                var msg=  msgJson.content.Replace("菲菲","唐唐");
                if (msg.Contains("唐唐在想") || msg.Contains("唐唐喜欢") || msg.Contains("唐唐爱"))
                {
                    return "唐唐在想楠芷";
                }
                return msg;
            }
            else
            {
                return "机器人宕机了";
            }
        }


    }

}
