using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPhone : MonoBehaviourPun
{
    private GameObject Phone;
    //private string col;
    //private Material Color;
    private bool state = false;

    private void Start()
    {
        Phone = this.gameObject;
        Debug.Log(Phone.GetComponent<MeshRenderer>().material);
    }
    private void OnTriggerStay(Collider other)
    {
        //Color = other.GetComponent<Material>();
        if(other.gameObject.tag == "paint")
        {
            string otherName = other.gameObject.name;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("ColorChange", RpcTarget.All, otherName);
            Debug.Log("ColorChange");
        }
    }

    [PunRPC]
    private void ColorChange(string colliderName)
    {
        GameObject colliderObject = GameObject.Find(colliderName);
        if(colliderObject != null)
        {
            Material color = colliderObject.GetComponent<MeshRenderer>().material;
            StartCoroutine(Waiting());
            if (state == true)
            {
                Phone.GetComponent<MeshRenderer>().material = color;
                Debug.Log("Changed Material");
            }
        }
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3);
        state = true;
    }
}
