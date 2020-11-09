using Acme.BookStore.Books;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class PumpStoreDataSeederContributor
         : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Datas> _bookRepository;

        public PumpStoreDataSeederContributor(IRepository<Datas> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\RCS-1\\RCS-1.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            for(int i = 0;i<100;i++)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                await _bookRepository.InsertAsync(
                        new Datas(arr[0].ConvertToTimeStamp())
                        {
                            datas = Convert.ToDouble(arr[1]),
                        },
                        autoSave: true
                        );
            }
            /*
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                // 通过异步方法给对象赋值插入到数据库中
                await _bookRepository.InsertAsync(
                       new Datas(BsonTimestamp.Create("1566876914"), Convert.ToDouble(arr[0]))
                       );
            }
            */
            // 关闭数据流
            sr.Close();
        }
    }
}
