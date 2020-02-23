using CaveRegister.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CaveRegister.Permissions
{
    public class CaveRegisterPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CaveRegisterPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(CaveRegisterPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CaveRegisterResource>(name);
        }
    }
}
