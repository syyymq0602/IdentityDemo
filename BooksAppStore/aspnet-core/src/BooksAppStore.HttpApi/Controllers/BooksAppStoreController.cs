using BooksAppStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BooksAppStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BooksAppStoreController : AbpController
    {
        protected BooksAppStoreController()
        {
            LocalizationResource = typeof(BooksAppStoreResource);
        }
    }
}