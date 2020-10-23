using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PumpData.EquipmentInformations
{
    public class EquipmentDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Equipment, Guid> _equipmentRepository;

        public EquipmentDataSeederContributor(IRepository<Equipment, Guid> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\pump\\csv\\EquipmentInformation.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                // 通过异步方法给对象赋值插入到数据库中
                var equipmenthas = await _equipmentRepository.FindAsync(p => p.E_id == Convert.ToDouble(arr[0]));
                if (equipmenthas == null)
                {
                    await _equipmentRepository.InsertAsync(
                           new Equipment
                           {
                               E_id = Convert.ToDouble(arr[0]),
                               E_Name = arr[1],
                               E_Brand = arr[2],
                               E_Type = arr[3],
                               E_Material = arr[4],
                               E_Use = arr[5],
                               E_InstallationSite = arr[6],
                               E_InstallationDate = Convert.ToDateTime(arr[7]),
                               E_MaintenanceDate = arr[8],
                               E_MaintenanceInformation = arr[9]
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
