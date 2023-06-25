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
            

            
            /*//Hide Region Change button (Not functional)
            Component[] components = __instance.GetComponentsInParent(typeof(GameObject));
            foreach(Component c in components)
            {
                if(c.gameObject.name == "RegionChange")
                {
                    if (Global.IsPrivateConnection)
                    {
                        c.gameObject.SetActive(false);
                    }
                    else
                    {
                        c.gameObject.SetActive(true);
                    }
                    break;
                }
            }
            */
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
