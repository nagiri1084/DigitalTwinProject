using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshRock : MonoBehaviourPun
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hammer")
        {
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("DroppedRocks", RpcTarget.All);
            pv.RPC("DroppingRocksSound", RpcTarget.All);
        }
    }

    [PunRPC]
    private void DroppedRocks()
    {
        Debug.Log("DroppedRocks");
        //if (this.GetComponent<Rigidbody>().isKinematic == true) this.GetComponent<Rigidbody>().isKinematic = false;
        if (this.GetComponent<Rigidbody>().useGravity == false) this.GetComponent<Rigidbody>().useGravity = true;
        if (this.GetComponent<BoxCollider>().isTrigger == true) this.GetComponent<BoxCollider>().isTrigger = false;

    }

    [PunRPC]
    private void DroppingRocksSound()
    {
        Debug.Log("DroppingRocksSound");
        if (audioSource)
        {
            audioSource.Play();
        }
    }
}
