using EMail.Domain.SeedWork;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EMail.Infrastructure.SeedWork
{
    public class BaseRepository
    {
        private string StorageFilePath { get; }
        private readonly string StorageDirectory = "storage";

        protected BaseRepository(string storageFileName)
        {
            StorageFilePath = $"{StorageDirectory}/{storageFileName}";
            if (!Directory.Exists(StorageDirectory))
            {
                Directory.CreateDirectory(StorageDirectory);
            }
        }

        protected async Task<string> ReadData()
        {
            if (File.Exists(StorageFilePath))
            {
                return await File.ReadAllTextAsync(StorageFilePath);
            }
            return string.Empty;
        }

        public bool ResetStorage()
        {
            if (File.Exists(StorageFilePath)) File.Delete(StorageFilePath);
            return true;
        }

        protected async Task<bool> SaveData<T>(IEnumerable<T> data) where T : BaseEntity
        {
            IEnumerable<string> dataToSave = data.Select(x => x.Serialize());
            if (this.ResetStorage())
            {
                await File.AppendAllLinesAsync(StorageFilePath, dataToSave);
            }
            return false;
        }
    }
}
