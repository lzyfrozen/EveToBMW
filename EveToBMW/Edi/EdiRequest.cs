﻿//using log4net;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class EdiRequest : IEdiRequest
    {
        private readonly IHttpClient _httpClient = new HttpClientDefault();
        //private readonly ILog _log;
        public EdiRequest()
        {

        }
        //public EdiRequest(IHttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //    //_log = LogManager.GetLogger(typeof(EdiRequest));
        //}

        public TResult Feedback<TResult>(FeedbackDto dto) where TResult : class
        {
            var result = AsyncContext.Run<TResult>(() => FeedbackToAdapter<TResult>(dto));
            return result;
        }


        public TResult Oauth<TResult>(FeedbackDto dto) where TResult : class
        {
            var result = AsyncContext.Run<TResult>(() => OauthToAdapter<TResult>(dto));
            return result;
        }

        private async Task<TResult> FeedbackToAdapter<TResult>(FeedbackDto dto) where TResult : class
        {
            return await _httpClient.PostAsync<string, TResult>(dto.Method, dto.Data, dto.Header);
        }

        private async Task<TResult> OauthToAdapter<TResult>(FeedbackDto dto) where TResult : class
        {
            return await _httpClient.PostOauthAsync<string, TResult>(dto.Method, dto.Header, dto.Params);
        }
    }
}
