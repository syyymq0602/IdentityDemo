using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PumpData.FaultKnowledge
{
    public class FaultDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Fault, Guid> _faultRepository;
        public FaultDataSeederContributor(IRepository<Fault, Guid> faultRepository)
        {
            _faultRepository = faultRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\csv\\FaultKnowledge.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                // 通过异步方法给对象赋值插入到数据库中
                var faulthas = await _faultRepository.FindAsync(p => p.F_id == Convert.ToDouble(arr[0]));
                if (faulthas == null)
                {
                    await _faultRepository.InsertAsync(
                           new Fault
                           {
                               F_id = Convert.ToDouble(arr[0]),
                               F_type = arr[1],
                               F_feature = arr[2],
                               DecisionSupport = arr[3]
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
