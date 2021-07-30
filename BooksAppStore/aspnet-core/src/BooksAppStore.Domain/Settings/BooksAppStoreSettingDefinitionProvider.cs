using Volo.Abp.Settings;

namespace BooksAppStore.Settings
{
    public class BooksAppStoreSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BooksAppStoreSettings.MySetting1));
        }
    }
}
