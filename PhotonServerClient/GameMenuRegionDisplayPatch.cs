using HarmonyLib;
using UnityEngine;

namespace PhotonServerClient
{
    [HarmonyPatch(typeof(PLUIPlayMenu), "Update")]
    internal class GameMenuRegionDisplayPatch
    {
        static void Postfix(PLUIPlayMenu __instance)
        {
            if (ClientInterface.IsPrivateConnection)
            {
                __instance.MenuTopText.text = PLLocalize.Localize("Found ", false) + PhotonNetwork.GetRoomList().Length.ToString() + PLLocalize.Localize(" crews - ", false) + PLLocalize.Localize("N/A", false);
            }
        }

    }
    [HarmonyPatch(typeof(PLRegionSelect), "OnEnter")]
    internal class DisableRegionSelectionPatch
    {
        //
        private static void Prefix()
        {
            if (ClientInterface.IsPrivateConnection)
            {
                PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            }
        }
    }
}
