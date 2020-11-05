using PumpData.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PumpData.Permissions
{
    public class PumpDataPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PumpDataPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(PumpDataPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PumpDataResource>(name);
        }
    }
}
