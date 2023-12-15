using BepInEx;
using BepInEx.Logging;
using Chaotic_Company.Managers;
using UnityEngine;
using Chaotic_Company.Misc;

namespace Chaotic_Company
{
    [BepInPlugin(Metadata.GUID, Metadata.NAME, Metadata.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        public static ManualLogSource LogSource;

        private void Awake()
        {
            LogSource = Logger;
            Instance = this;

            // Other initializations if necessary
            InitializePlayerSwapManager();

            Logger.LogInfo("Chaotic Company Player Swap has been initialized.");
        }

        private void InitializePlayerSwapManager()
        {
            GameObject playerSwapManagerObject = new GameObject("PlayerSwapManager");
            playerSwapManagerObject.AddComponent<PlayerSwapManager>();
            DontDestroyOnLoad(playerSwapManagerObject);
        }
    }
}
