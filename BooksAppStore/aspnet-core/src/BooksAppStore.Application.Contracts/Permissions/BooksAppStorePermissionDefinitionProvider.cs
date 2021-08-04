using BooksAppStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BooksAppStore.Permissions
{
    public class BooksAppStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var booksGroup = context.AddGroup(BooksAppStorePermissions.GroupName);

            var booksPermission = booksGroup.AddPermission(BooksAppStorePermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(BooksAppStorePermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(BooksAppStorePermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(BooksAppStorePermissions.Books.Delete, L("Permission:Books.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BooksAppStoreResource>(name);
        }
    }
}
