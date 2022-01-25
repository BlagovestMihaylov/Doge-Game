using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListings : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;

    private List<RoomListing> listings = new List<RoomListing>();

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo ri in roomList)
        {
            int index = listings.FindIndex(x => x.RoomInfo.Name == ri.Name);
            if (ri.RemovedFromList)
            {
                if(index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                if(index == -1) { 
                    RoomListing rl = Instantiate(roomListing, content);
                    listings.Add(rl);
                    if (rl != null)
                    {
                        rl.setRoomInfo(ri);
                    }
                }
            }
            
        }
    }
}
