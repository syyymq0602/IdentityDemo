using BooksAppStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BooksAppStore.Permissions
{
    public class BooksAppStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BooksAppStorePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BooksAppStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BooksAppStoreResource>(name);
        }
    }
}
