using System.Linq;
using Chaotic_Company.Misc;

namespace Chaotic_Company.Helpers
{
    public static partial class Helper
    {
        static ShipTeleporter[]? ShipTeleporters => TPObject.Instance?.ShipTeleporters.Objects;

        public static ShipTeleporter? InverseTeleporter => Helper.ShipTeleporters?.FirstOrDefault(teleporter => teleporter.isInverseTeleporter);

        public static ShipTeleporter? Teleporter => Helper.ShipTeleporters?.FirstOrDefault(teleporter => !teleporter.isInverseTeleporter);
    }
}