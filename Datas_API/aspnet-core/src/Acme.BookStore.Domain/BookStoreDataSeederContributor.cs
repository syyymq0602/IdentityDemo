using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        // : IDataSeedContributor, ITransientDependency
    {
        /*
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\q.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            while (!sr.EndOfStream)
            {           
                // 一行一行读取数据
                string line = sr.ReadLine();
                string[] arr = line.Split(" ");
                // 查询重复数据
                var hasBook = await _bookRepository.FindAsync(p => p.B_id == arr[0]);
                if (hasBook == null)
                {
                    // 通过异步方法给对象赋值插入到数据库中
                    await _bookRepository.InsertAsync(
                           new Book
                           {
                               B_id =arr[0],
                               Price = Convert.ToDecimal(arr[1])
                           },
                           autoSave: true
                    );
                }

            }
            // 关闭数据流
            sr.Close();
        }
        */
    }
}
