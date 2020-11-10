using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonViewChecker : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;

    public Behaviour[] behavioursToEnable;
    public Behaviour[] behavioursToDisable;

    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();

        if(pv.IsMine)
        {
            foreach (GameObject go in objectsToEnable)
                go.SetActive(true);

            foreach (Behaviour script in behavioursToEnable)
                script.enabled = true;
        }
        else
        {
            foreach (GameObject go in objectsToDisable)
                go.SetActive(false);

            foreach (Behaviour script in behavioursToDisable)
                script.enabled = false;
        }
    }
}
