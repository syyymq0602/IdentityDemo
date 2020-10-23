using MongoDB.Driver;
using PumpData.DiagnosticMessage;
using PumpData.EquipmentInformations;
using PumpData.FaultKnowledge;
using PumpData.RealTimeParam;
using PumpData.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace PumpData.MongoDB
{
    [ConnectionStringName("Default")]
    public class PumpDataMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();
        public IMongoCollection<Equipment> Equipments => Collection<Equipment>();
        public IMongoCollection<Diagnose> Diagnoses => Collection<Diagnose>();
        public IMongoCollection<Fault> Faults => Collection<Fault>();
        public IMongoCollection<Parameter> Parameters => Collection<Parameter>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
            modelBuilder.Entity<Equipment>(b =>
            {
                /* Sharing the same "AbpUsers" collection
                 * with the Identity module's IdentityUser class. */
                b.CollectionName = "EquipmentInformations"; 
            });
            modelBuilder.Entity<Diagnose>(b =>
            {
                b.CollectionName = "DiagnosticMessage";
            });
            modelBuilder.Entity<Fault>(b =>
            {
                b.CollectionName = "FaultKnowledge";
            });
            modelBuilder.Entity<Parameter>(b =>
            {
                b.CollectionName = "RealTimeParam";
            });
            modelBuilder.Entity<AppUser>(b =>
            {
                b.CollectionName = "AbpUsers";
            });
        }
    }
}
