using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnTraps : MonoBehaviour
{
    public GameObject trapPrefab;

    public void Start()
    {
        PhotonNetwork.Instantiate(trapPrefab.name, new Vector2(0, -2.75f), Quaternion.identity);
    }
}
