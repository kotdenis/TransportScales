﻿namespace TransportScales.Core.Services.Interfaces
{
    public interface ICacheManager
    {
        Task<T> GetAsync<T>(string key, Func<T> func);
        Task SetAsync<T>(string key, T value);
        Task ClearlAsync(string key);
    }
}
