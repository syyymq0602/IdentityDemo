using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PumpData.DiagnosticMessage
{
    public class DiagnosticDataSeederContributor :
        IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Diagnose, Guid> _diagnoseRepository;

        public DiagnosticDataSeederContributor(IRepository<Diagnose, Guid> diagnoseRepository)
        {
            _diagnoseRepository = diagnoseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\pump\\csv\\DiagnosticMessage.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                // 通过异步方法给对象赋值插入到数据库中
                var diagnosehas = await _diagnoseRepository.FindAsync(p => p.D_id == Convert.ToDouble(arr[0]));
                if (diagnosehas == null)
                {
                    await _diagnoseRepository.InsertAsync(
                           new Diagnose
                           {
                               D_id = Convert.ToDouble(arr[0]),
                               D_Date = Convert.ToDateTime(arr[1]),
                               D_Result = arr[2],
                               D_DecisionSupport = arr[3],
                               StateInformation = arr[4],
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
