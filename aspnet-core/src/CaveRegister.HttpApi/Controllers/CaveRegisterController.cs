using CaveRegister.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CaveRegister.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CaveRegisterController : AbpController
    {
        protected CaveRegisterController()
        {
            LocalizationResource = typeof(CaveRegisterResource);
        }
    }
}