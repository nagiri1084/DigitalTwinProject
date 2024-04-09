using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshGripEvent : MonoBehaviourPun
{
    public GameObject fixingHand;
    private Collider col;
    private bool enterState = false;
    
    private void Start()
    {
        fixingHand.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hands")
        {
            col = other;
            enterState = true;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("ManageHand", RpcTarget.All);
            Debug.Log("ManageHand");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "hands")
        {
            col = other;
            enterState = false;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("ManageHand", RpcTarget.All);
            Debug.Log("OnTriggerExit");
        }
    }

    [PunRPC]
    private void ManageHand()
    {
        if(enterState == true && col != null)
        {
            col.transform.GetChild(0).gameObject.SetActive(false);
            fixingHand.gameObject.SetActive(true);
        }
        else if(enterState == false && col != null)
        {
            col.transform.GetChild(0).gameObject.SetActive(true);
            fixingHand.gameObject.SetActive(false);
        }
    }
}
