using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text roomLabel;

    public RoomInfo RoomInfo { get; private set; }


    public void setRoomInfo(RoomInfo ri)
    {
        RoomInfo = ri;
        if(ri.CustomProperties.ContainsKey("level"))
        {
            int level = (int)ri.CustomProperties["level"];
            roomLabel.text = ri.MaxPlayers + ", Level - " + level + ", " + ri.Name;
            return;
        }
        roomLabel.text = ri.MaxPlayers + ", " + ri.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
