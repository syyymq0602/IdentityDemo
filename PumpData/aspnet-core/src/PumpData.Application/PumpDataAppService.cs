using System;
using System.Collections.Generic;
using System.Text;
using PumpData.Localization;
using Volo.Abp.Application.Services;

namespace PumpData
{
    /* Inherit your application services from this class.
     */
    public abstract class PumpDataAppService : ApplicationService
    {
        protected PumpDataAppService()
        {
            LocalizationResource = typeof(PumpDataResource);
        }
    }
}
