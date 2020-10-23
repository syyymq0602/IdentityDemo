using PumpData.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PumpData.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class PumpDataController : AbpController
    {
        protected PumpDataController()
        {
            LocalizationResource = typeof(PumpDataResource);
        }
    }
}