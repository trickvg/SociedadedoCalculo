﻿// Note: this script has to be on an always-active UI parent, so that we can
// always find it from other code. (GameObject.Find doesn't find inactive ones)
using UnityEngine;
using UnityEngine.UI;

public partial class UIPlayerTradeRequest : MonoBehaviour
{
    public GameObject panel;
    public Text nameText;
    public Button acceptButton;
    public Button declineButton;

    void Update()
    {
        Player player = Player.localPlayer;

        // only if there is a request and if not accepted already
        if (player != null && player.tradeRequestFrom != "" && player.State != "TRADING")
        {
            panel.SetActive(true);
            nameText.text = player.tradeRequestFrom;
            acceptButton.onClick.SetListener(() => {
                player.CmdTradeRequestAccept();
            });
            declineButton.onClick.SetListener(() => {
                player.CmdTradeRequestDecline();
            });
        }
        else panel.SetActive(false);
    }
}
