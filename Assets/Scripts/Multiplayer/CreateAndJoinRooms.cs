using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField craeteInput;
    public TMP_Text levelLabel;
    public InputField joinInput;

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
        customProps["level"] = int.Parse(levelLabel.text.Substring(8));
        roomOptions.CustomRoomProperties = customProps;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(craeteInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("level")) { 
            int level = (int)PhotonNetwork.CurrentRoom.CustomProperties["level"];
            PhotonNetwork.LoadLevel("Level" + level);
        }
    }
}
