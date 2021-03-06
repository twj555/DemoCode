﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：CustomMessageHandler.cs
    文件功能描述：微信公众号自定义MessageHandler


    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.Helpers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.Sample.CommonService.Utilities;
using System.Xml.Linq;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Threading.Tasks;
using Senparc.Weixin.Entities.Request;

namespace Senparc.Weixin.MP.Sample.CommonService.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        /*
         * 重要提示：v1.5起，MessageHandler提供了一个DefaultResponseMessage的抽象方法，
         * DefaultResponseMessage必须在子类中重写，用于返回没有处理过的消息类型（也可以用于默认消息，如帮助信息等）；
         * 其中所有原OnXX的抽象方法已经都改为虚方法，可以不必每个都重写。若不重写，默认返回DefaultResponseMessage方法中的结果。
         */


#if DEBUG
        string agentUrl = "http://localhost:12222/App/Weixin/4";
        string agentToken = "27C455F496044A87";
        string wiweihiKey = "CNadjJuWzyX5bz5Gn+/XoyqiqMa5DjXQ";
#else
        //下面的Url和Token可以用其他平台的消息，或者到www.weiweihi.com注册微信用户，将自动在“微信营销工具”下得到
        private string agentUrl = WebConfigurationManager.AppSettings["WeixinAgentUrl"];//这里使用了www.weiweihi.com微信自动托管平台
        private string agentToken = WebConfigurationManager.AppSettings["WeixinAgentToken"];//Token
        private string wiweihiKey = WebConfigurationManager.AppSettings["WeixinAgentWeiweihiKey"];//WeiweihiKey专门用于对接www.Weiweihi.com平台，获取方式见：http://www.weiweihi.com/ApiDocuments/Item/25#51
#endif

        private string appId = WebConfigurationManager.AppSettings["WeixinAppId"];
        private string appSecret = WebConfigurationManager.AppSettings["WeixinAppSecret"];

        /// <summary>
        /// 模板消息集合（Key：checkCode，Value：OpenId）
        /// </summary>
        public static Dictionary<string, string> TemplateMessageCollection = new Dictionary<string, string>();

        public CustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 3;

            if (!string.IsNullOrEmpty(postModel.AppId))
            {
                appId = postModel.AppId;//通过第三方开放平台发送过来的请求
            }

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }
                return true;
            };
        }

        public CustomMessageHandler(RequestMessageBase requestMessage)
            : base(requestMessage)
        {
        }

        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            //说明：实际项目中这里的逻辑可以交给Service处理具体信息，参考OnLocationRequest方法或/Service/LocationSercice.cs

            #region 书中例子
            //if (requestMessage.Content == "你好")
            //{
            //    var responseMessage = base.CreateResponseMessage<ResponseMessageNews>();
            //    var title = "Title";
            //    var description = "Description";
            //    var picUrl = "PicUrl";
            //    var url = "Url";
            //    responseMessage.Articles.Add(new Article()
            //    {
            //        Title = title,
            //        Description = description,
            //        PicUrl = picUrl,
            //        Url = url
            //    });
            //    return responseMessage;
            //}
            //else if (requestMessage.Content == "Senparc")
            //{
            //    //相似处理逻辑
            //}
            //else
            //{
            //    //...
            //}

            #endregion

            #region 历史方法

            //方法一（v0.1），此方法调用太过繁琐，已过时（但仍是所有方法的核心基础），建议使用方法二到四
            //var responseMessage =
            //    ResponseMessageBase.CreateFromRequestMessage(RequestMessage, ResponseMsgType.Text) as
            //    ResponseMessageText;

            //方法二（v0.4）
            //var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(RequestMessage);

            //方法三（v0.4），扩展方法，需要using Senparc.Weixin.MP.Helpers;
            //var responseMessage = RequestMessage.CreateResponseMessage<ResponseMessageText>();

            //方法四（v0.6+），仅适合在HandlerMessage内部使用，本质上是对方法三的封装
            //注意：下面泛型ResponseMessageText即返回给客户端的类型，可以根据自己的需要填写ResponseMessageNews等不同类型。

            #endregion

            var defaultResponseMessage = base.CreateResponseMessage<ResponseMessageText>();

            var requestHandler =
                requestMessage.StartHandler()
                //关键字不区分大小写，按照顺序匹配成功后将不再运行下面的逻辑                
                .Keyword("笑话", () =>
                {
<<<<<<< HEAD
                  defaultResponseMessage.Content = Senparc.Weixin.MP.Sample.CommonService.JuHeAPI.JuHe.GetXiaohua("笑话");                    
                  return defaultResponseMessage;
                }).LikeKeyword("图", () =>
                {
                    var imgUrl = Senparc.Weixin.MP.Sample.CommonService.JuHeAPI.JuHe.GetXiaohua("趣图");
                    //var imgResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                    ////imgResponseMessage.Image = "";
                    //using (System.Net.WebClient wc = new System.Net.WebClient())
                    //{
                    //    wc.Headers.Add("User-Agent", "Chrome");
                    //    var imgData = wc.DownloadData(imgUrl);
                    //    var accessToken = Containers.AccessTokenContainer.TryGetAccessToken(appId, appSecret);
                    //    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(accessToken, UploadMediaFileType.image,);
                    //}

                    var responseMessage = CreateResponseMessage<ResponseMessageNews>();
                    responseMessage.Articles.Add(new Article()
                    {
                        Title = "趣图",
                        Description = "趣图",
                        PicUrl = imgUrl,
                        Url = imgUrl,
                    });


                    return responseMessage;
                }).LikeKeyword("关键词设定=", () =>
                {
                    defaultResponseMessage.Content = Senparc.Weixin.MP.Sample.CommonService.DynamicMessage.ReadAndWriteKeyword.Write(requestMessage.Content.Replace("关键词设定=", ""));
                    return defaultResponseMessage;
=======
                  defaultResponseMessage.Content = Senparc.Weixin.MP.Sample.CommonService.JuHeAPI.JuHe.GetXiaohua();                    
                  return defaultResponseMessage;
>>>>>>> 32c0e0dc2daf18518a88d23ac338c13b4cdde380
                })
                .Keyword("AsyncTest", () =>
                {
                    //异步并发测试（提供给单元测试使用）
                    DateTime begin = DateTime.Now;
                    int t1, t2, t3;
                    System.Threading.ThreadPool.GetAvailableThreads(out t1, out t3);
                    System.Threading.ThreadPool.GetMaxThreads(out t2, out t3);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(4));
                    DateTime end = DateTime.Now;
                    var thread = System.Threading.Thread.CurrentThread;
                    defaultResponseMessage.Content = string.Format("TId:{0}\tApp:{1}\tBegin:{2:mm:ss,ffff}\tEnd:{3:mm:ss,ffff}\tTPool：{4}",
                            thread.ManagedThreadId,
                            HttpContext.Current != null ? HttpContext.Current.ApplicationInstance.GetHashCode() : -1,
                            begin,
                            end,
                            t2 - t1
                            );
                    return defaultResponseMessage;
                })
                .Keyword("OPEN", () =>
                {
                    var openResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageNews>();
                    openResponseMessage.Articles.Add(new Article()
                    {
                        Title = "开放平台微信授权测试",
                        Description = @"点击进入Open授权页面。

授权之后，您的微信所收到的消息将转发到第三方（盛派网络小助手）的服务器上，并获得对应的回复。

测试完成后，您可以登陆公众号后台取消授权。",
                        Url = "http://sdk.weixin.senparc.com/OpenOAuth/JumpToMpOAuth"
                    });
                    return openResponseMessage;
                })
                .Keyword("错误", () =>
                {
                    var errorResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
                    //因为没有设置errorResponseMessage.Content，所以这小消息将无法正确返回。
                    return errorResponseMessage;
                })
                .Keyword("容错", () =>
                {
                    Thread.Sleep(1500);//故意延时1.5秒，让微信多次发送消息过来，观察返回结果
                    var faultTolerantResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
                    faultTolerantResponseMessage.Content = string.Format("测试容错，MsgId：{0}，Ticks：{1}", requestMessage.MsgId,
                        DateTime.Now.Ticks);
                    return faultTolerantResponseMessage;
                })
                .Keyword("TM", () =>
                {
                    var openId = requestMessage.FromUserName;
                    var checkCode = Guid.NewGuid().ToString("n").Substring(0, 3);//为了防止openId泄露造成骚扰，这里启用验证码
                    TemplateMessageCollection[checkCode] = openId;
                    defaultResponseMessage.Content = string.Format(@"新的验证码为：{0}，请在网页上输入。网址：http://sdk.weixin.senparc.com/AsyncMethods", checkCode);
                    return defaultResponseMessage;
                })
                .Keyword("OPENID", () =>
                {
                    var openId = requestMessage.FromUserName;//获取OpenId
                    var userInfo = AdvancedAPIs.UserApi.Info(appId, openId, Language.zh_CN);

                    defaultResponseMessage.Content = string.Format(
                        "您的OpenID为：{0}\r\n昵称：{1}\r\n性别：{2}\r\n地区（国家/省/市）：{3}/{4}/{5}\r\n关注时间：{6}\r\n关注状态：{7}",
                        requestMessage.FromUserName, userInfo.nickname, (Sex)userInfo.sex, userInfo.country, userInfo.province, userInfo.city, DateTimeHelper.GetDateTimeFromXml(userInfo.subscribe_time), userInfo.subscribe);
                    return defaultResponseMessage;
                })
                .Keyword("EX", () =>
                {
                    var ex = new WeixinException("openid:" + requestMessage.FromUserName + ":这是一条测试异常信息");//回调过程在global的ConfigWeixinTraceLog()方法中
                    defaultResponseMessage.Content = "请等待异步模板消息发送到此界面上（自动延时数秒）。\r\n当前时间：" + DateTime.Now.ToString();
                    return defaultResponseMessage;
                })
                .Keyword("MUTE", () =>
                {
                    return new SuccessResponseMessage();
                    base.TextResponseMessage = "success";
                    return null;
                })
                .Keyword("JSSDK", () =>
                {
                    defaultResponseMessage.Content = "点击打开：http://sdk.weixin.senparc.com/WeixinJsSdk";
                    return defaultResponseMessage;
                })
                //Default不一定要在最后一个
                .Default(() =>
                {
<<<<<<< HEAD

                    // Senparc.Weixin.MP.Sample.CommonService.DynamicMessage.ReadAndWriteKeyword.Write(requestMessage.Content.Replace("关键词设定=", ""));
                    defaultResponseMessage.Content = Senparc.Weixin.MP.Sample.CommonService.DynamicMessage.ReadAndWriteKeyword.Read(requestMessage.FromUserName,requestMessage.Content);
                    if (defaultResponseMessage.Content.Contains("未找到关键字"))
                    {
                        defaultResponseMessage.Content = Senparc.Weixin.MP.Sample.CommonService.JuHeAPI.JuHe.GetJiqiren(requestMessage.Content);
                    }
=======
                    var result = new StringBuilder();
                    result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content);
                  
                    defaultResponseMessage.Content = result.ToString();
>>>>>>> 32c0e0dc2daf18518a88d23ac338c13b4cdde380
                    return defaultResponseMessage;
                })
                //正则表达式
                .Regex(@"^\d+#\d+$", () =>
                {
                    defaultResponseMessage.Content = string.Format("您输入了：{0}，符合正则表达式：^\\d+#\\d+$", requestMessage.Content);
                    return defaultResponseMessage;
                });

            return requestHandler.GetResponseMessage() as IResponseMessageBase;
        }

        /// <summary>
        /// 处理位置请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            var locationService = new LocationService();
            var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);
            return responseMessage;
        }

        public override IResponseMessageBase OnShortVideoRequest(RequestMessageShortVideo requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您刚才发送的是小视频";
            return responseMessage;
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            responseMessage.Articles.Add(new Article()
            {
                Title = "您刚才发送了图片信息",
                Description = "您发送的图片将会显示在边上",
                PicUrl = requestMessage.PicUrl,
                Url = "http://sdk.weixin.senparc.com"
            });
            responseMessage.Articles.Add(new Article()
            {
                Title = "第二条",
                Description = "第二条带连接的内容",
                PicUrl = requestMessage.PicUrl,
                Url = "http://sdk.weixin.senparc.com"
            });

            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageMusic>();
            //上传缩略图
            //var accessToken = Containers.AccessTokenContainer.TryGetAccessToken(appId, appSecret);
            var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(appId, UploadMediaFileType.image,
                                                         Server.GetMapPath("~/Images/Logo.jpg"));

            //设置音乐信息
            responseMessage.Music.Title = "天籁之音";
            responseMessage.Music.Description = "播放您上传的语音";
            responseMessage.Music.MusicUrl = "http://sdk.weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            responseMessage.Music.HQMusicUrl = "http://sdk.weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            responseMessage.Music.ThumbMediaId = uploadResult.media_id;

            //推送一条客服消息
            try
            {
                CustomApi.SendText(appId, WeixinOpenId, "本次上传的音频MediaId：" + requestMessage.MediaId);

            }
            catch {
            }

            return responseMessage;
        }
        /// <summary>
        /// 处理视频请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您发送了一条视频信息，ID：" + requestMessage.MediaId;

            #region 上传素材并推送到客户端

            Task.Factory.StartNew(async () =>
             {
                 //上传素材
                 var dir = Server.GetMapPath("~/App_Data/TempVideo/");
                 var file = await MediaApi.GetAsync(appId, requestMessage.MediaId, dir);
                 var uploadResult = await MediaApi.UploadTemporaryMediaAsync(appId, UploadMediaFileType.video, file, 50000);
                 await CustomApi.SendVideoAsync(appId, base.WeixinOpenId, uploadResult.media_id, "这是您刚才发送的视频", "这是一条视频消息");
             }).ContinueWith(async task =>
             {
                 if (task.Exception != null)
                 {
                     WeixinTrace.Log("OnVideoRequest()储存Video过程发生错误：", task.Exception.Message);

                     var msg = string.Format("上传素材出错：{0}\r\n{1}",
                                task.Exception.Message,
                                task.Exception.InnerException != null
                                    ? task.Exception.InnerException.Message
                                    : null);
                     await CustomApi.SendTextAsync(appId, base.WeixinOpenId, msg);
                 }
             });

            #endregion

            return responseMessage;
        }


        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = string.Format(@"您发送了一条连接信息：
Title：{0}
Description:{1}
Url:{2}", requestMessage.Title, requestMessage.Description, requestMessage.Url);
            return responseMessage;
        }

        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            //TODO: 对Event信息进行统一操作
            return eventResponseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            /* 所有没有被处理的消息会默认返回这里的结果，
            * 因此，如果想把整个微信请求委托出去（例如需要使用分布式或从其他服务器获取请求），
            * 只需要在这里统一发出委托请求，如：
            * var responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
            * return responseMessage;
            */

            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这条消息来自DefaultResponseMessage。";
            return responseMessage;
        }
    }
}
