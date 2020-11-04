using Acme.BookStore.Books;
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
        private readonly IRepository<Datas, Guid> _bookRepository;

        public PumpStoreDataSeederContributor(IRepository<Datas, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\FFT_ys.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                string line = sr.ReadLine();
                string[] arr = line.Split(",");         
                // 通过异步方法给对象赋值插入到数据库中
                await _bookRepository.InsertAsync(
                       new Datas
                       {
                           datas = Convert.ToDouble(arr[0])
                       },
                       autoSave: true
                       );
            }
            // 关闭数据流
            sr.Close();
        }
    }
}
