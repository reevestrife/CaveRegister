using Volo.Abp.Settings;

namespace CaveRegister.Settings
{
    public class CaveRegisterSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CaveRegisterSettings.MySetting1));
        }
    }
}
