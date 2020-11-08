using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PumpData.Books
{
    public class BookDataSeederContributor :
         IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _diagnoseRepository;

        public BookDataSeederContributor(IRepository<Book, Guid> diagnoseRepository)
        {
            _diagnoseRepository = diagnoseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\FFT_ys.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                // 通过异步方法给对象赋值插入到数据库中
                var diagnosehas = await _diagnoseRepository.FindAsync(p => p.Pressure1 == Convert.ToDouble(arr[0]));
                if (diagnosehas == null)
                {
                    await _diagnoseRepository.InsertAsync(
                       new Book
                       {
                           Pressure1 = Convert.ToDouble(arr[0])
                       },
                       autoSave: true
                    );
                }
            }
            // 关闭数据流
            sr.Close();
        }
    }
}
