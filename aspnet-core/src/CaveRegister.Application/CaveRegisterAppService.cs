using System;
using System.Collections.Generic;
using System.Text;
using CaveRegister.Localization;
using Volo.Abp.Application.Services;

namespace CaveRegister
{
    /* Inherit your application services from this class.
     */
    public abstract class CaveRegisterAppService : ApplicationService
    {
        protected CaveRegisterAppService()
        {
            LocalizationResource = typeof(CaveRegisterResource);
        }
    }
}
