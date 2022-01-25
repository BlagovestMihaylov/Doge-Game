using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    public Vector3 trigger;
    private bool flag = false;

    private void Awake()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
    void LateUpdate()
    {
        if (target.position.x > trigger.x && flag == false)
        {
            flag = true;
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
