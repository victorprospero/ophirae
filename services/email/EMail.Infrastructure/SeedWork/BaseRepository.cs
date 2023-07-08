using EMail.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EMail.Infrastructure.SeedWork
{
    public class BaseRepository
    {
        protected string StorageFilePath { get; }


        protected BaseRepository(string storageFilePath)
        {
            StorageFilePath = storageFilePath;
        }

        protected async Task<string> ReadData()
        {
            if (File.Exists(StorageFilePath))
            {
                try
                {
                    return await File.ReadAllTextAsync(StorageFilePath);
                }
                catch (Exception) { }
            }
            return string.Empty;
        }

        public bool ResetStorage()
        {
            if (!File.Exists(StorageFilePath)) return true;
            
            try
            {
                File.Delete(StorageFilePath);
                return true;
            }
            catch (Exception) { }
            
            return false;
        }

        protected async Task<bool> SaveData<T>(IEnumerable<T> data) where T : BaseEntity
        {
            IEnumerable<string> dataToSave = data.Select(x => x.Serialize());
            if (this.ResetStorage())
            {
                try
                {
                    await File.AppendAllLinesAsync(StorageFilePath, dataToSave);
                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }
    }
}
