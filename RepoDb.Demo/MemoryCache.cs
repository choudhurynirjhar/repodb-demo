using RepoDb.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RepoDb.Demo
{
    public class MemoryCache : ICache
    {
        private IDictionary data;

        public void Add<T>(string key, T value, int expiration = 180, bool throwException = true)
        {
            if (data == null)
                data = new Dictionary<string, CacheItem<T>>();
            var tempData = (Dictionary<string, CacheItem<T>>)data;
            if (tempData.ContainsKey(key) && throwException)
                throw new ArgumentException("Error");
            data.Add(key, new CacheItem<T>(key, value, expiration));
        }

        public void Add<T>(CacheItem<T> item, bool throwException = true)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public CacheItem<T> Get<T>(string key, bool throwException = true)
        {
            if (data == null)
                return null;
            var tempData = (Dictionary<string, CacheItem<T>>)data;
            if (!tempData.ContainsKey(key) && throwException)
                throw new ArgumentException("Error");
            return (CacheItem<T>)data[key];
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(string key, bool throwException = true)
        {
            throw new NotImplementedException();
        }
    }
}
