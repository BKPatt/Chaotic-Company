using System.Linq;
using UnityEngine;
using Chaotic_Company.Misc;

namespace Chaotic_Company.Helpers
{
    public static partial class Helper
    {
        public static bool Is(this Unlockable unlockable, int unlockableId) => unlockableId == (int)unlockable;

        public static void BuyUnlockable(Unlockable unlockable)
        {
            if (!Helper.Terminal.IsNotNull(out Terminal terminal))
            {
                Helper.PrintSystem("Terminal not found!");
                return;
            }

            Helper.StartOfRound?.BuyShipUnlockableServerRpc(
                (int)unlockable,
                terminal.groupCredits
            );
        }

        public static PlaceableShipObject? GetUnlockable(Unlockable unlockable) =>
            Object.FindObjectsOfType<PlaceableShipObject>()
                  .FirstOrDefault(placeableObject => unlockable.Is(placeableObject.unlockableID));
    }
}