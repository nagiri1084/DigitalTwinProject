using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshGripEvent : MonoBehaviourPun
{
    public GameObject fixingHand;
    //private Collider col;
    //private string colName;
    private bool enterState = false;

    private void Start()
    {
        fixingHand.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hands")
        {
            string otherName = other.gameObject.name;
            enterState = true;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("TrueFixingHand", RpcTarget.All, otherName);
            Debug.Log("ManageHand");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "hands")
        {
            string otherName = other.gameObject.name;
            enterState = false;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("FalseFixingHand", RpcTarget.All, otherName);
            Debug.Log("OnTriggerExit");
        }
    }

    [PunRPC]
    private void TrueFixingHand(string colliderName)
    {
        GameObject colliderObject = GameObject.Find(colliderName);
        if (enterState == true && colliderObject != null)
        {
            colliderObject.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log(colliderObject.transform.GetChild(0));
            fixingHand.gameObject.SetActive(true);
        }
    }

    [PunRPC]
    private void FalseFixingHand(string colliderName)
    {
        GameObject colliderObject = GameObject.Find(colliderName);
        if (enterState == false && colliderObject != null)
        {
            colliderObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log(colliderObject.transform.GetChild(0));
            fixingHand.gameObject.SetActive(false);
        }
    }
}
