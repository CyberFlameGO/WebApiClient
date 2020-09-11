﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebApiClientCore.Extensions.OAuths.TokenProviders
{
    /// <summary>
    /// 表示Client身份信息token提供者
    /// </summary>
    /// <typeparam name="THttpApi"></typeparam>
    public class ClientCredentialsTokenProvider<THttpApi> : TokenProvider, IClientCredentialsTokenProvider<THttpApi>
    {
        /// <summary>
        /// Client身份信息token提供者
        /// </summary>
        /// <param name="services"></param> 
        public ClientCredentialsTokenProvider(IServiceProvider services)
            : base(services)
        {
        }

        /// <summary>
        /// 请求获取token
        /// </summary> 
        /// <param name="serviceProvider">服务提供者</param>
        /// <returns></returns>
        protected override Task<TokenResult?> RequestTokenAsync(IServiceProvider serviceProvider)
        {
            return serviceProvider
                .GetRequiredService<IClientCredentialsTokenClient>()
                .RequestTokenAsync(typeof(THttpApi));
        }

        /// <summary>
        /// 刷新token
        /// </summary> 
        /// <param name="serviceProvider">服务提供者</param>
        /// <param name="refresh_token">刷新token</param>
        /// <returns></returns>
        protected override Task<TokenResult?> RefreshTokenAsync(IServiceProvider serviceProvider, string refresh_token)
        {
            return serviceProvider
               .GetRequiredService<IClientCredentialsTokenClient>()
               .RefreshTokenAsync(refresh_token, typeof(THttpApi));
        }
    }
}