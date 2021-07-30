using System;
using System.Collections.Generic;
using System.Text;
using BooksAppStore.Localization;
using Volo.Abp.Application.Services;

namespace BooksAppStore
{
    /* Inherit your application services from this class.
     */
    public abstract class BooksAppStoreAppService : ApplicationService
    {
        protected BooksAppStoreAppService()
        {
            LocalizationResource = typeof(BooksAppStoreResource);
        }
    }
}
