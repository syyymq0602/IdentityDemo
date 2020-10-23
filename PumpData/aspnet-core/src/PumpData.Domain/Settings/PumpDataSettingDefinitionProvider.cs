using Volo.Abp.Settings;

namespace PumpData.Settings
{
    public class PumpDataSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(PumpDataSettings.MySetting1));
        }
    }
}
