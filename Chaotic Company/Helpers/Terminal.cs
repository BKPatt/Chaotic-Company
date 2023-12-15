using Chaotic_Company.Misc;

namespace Chaotic_Company.Helpers
{
    public static partial class Helper
    {
        public static Terminal? Terminal =>
            Helper.HUDManager is null
                ? null
                : Reflector.Target(Helper.HUDManager).GetInternalField<Terminal>("terminalScript");
    }
}