using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using OOP_HW.Attributes;
using OOP_HW.ExtensionMethods;
using OOP_HW.Interfaces;

namespace OOP_HW.DataSources
{
    class FileDataSource : ISource
    {
        const string filesPath = @"../../../DocumentStorage";
        private readonly IMemoryCache memoryCache;
        public FileDataSource(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public List<IDocument> RetrieveAllDocuments()
        {
            List<IDocument> documents;
            documents = RetrieveCachedData();
            if (documents == null)
            {
                documents = RetrieveAndCacheData();
            }
            return documents;
        }
        private List<IDocument> RetrieveAndCacheData()
        {
            List<IDocument> documents = new();
            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                IDocument doc = file.Initialize();
                if (doc != null)
                {
                    documents.Add(doc);
                }
            }
            CacheData(documents);
            return documents;
        }
        private List<IDocument> RetrieveCachedData()
        {
            List<IDocument> documents = memoryCache.Get<List<IDocument>>("documents");
            return documents;
        }
        private void CacheData(List<IDocument> documents)
        {
            List<IDocument> cache = new();
            foreach (IDocument doc in documents)
            {
                if (doc.GetType().GetCustomAttribute<CacheableAttribute>().ShouldBeCached)
                {
                    cache.Add(doc);
                }
            }
            memoryCache.Set("documents", cache, TimeSpan.FromMinutes(1));
        }

    }
}
