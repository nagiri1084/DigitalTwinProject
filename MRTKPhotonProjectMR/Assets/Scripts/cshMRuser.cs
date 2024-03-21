using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshMRuser : MonoBehaviourPun
{
    //private GameObject MixedRealityToolkit;
    //private GameObject MixedRealitySceneContent;
    private GameObject R_Hand;
    private GameObject L_Hand;
    private GameObject R_Model;
    private GameObject L_Model;
    bool RightCreateState = false;
    bool LeftCreateState = false;

    // Start is called before the first frame update
    void Start()
    {

        if (!photonView.IsMine) //내가 아니면 = 다른 사용자들이면
        {

            Camera[] cameras;
            cameras = transform.gameObject.GetComponentsInChildren<Camera>();

            foreach (Camera c in cameras)
            {
                c.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindLeftHand();
        FindRightHand();
    }

    void FindLeftHand()
    {
        L_Hand = GameObject.Find("Left_ConicalGrabPointer(Clone)");

        if (L_Hand)
        {
            if (LeftCreateState == false)
            {
                L_Model = PhotonNetwork.Instantiate("L_Model", L_Hand.transform.position, Quaternion.identity, 0);
                Debug.Log("create l_model");
                LeftCreateState = true;
            }
            else
            {
                L_Model.transform.position = new Vector3(L_Hand.transform.position.x - 0.05f, L_Hand.transform.position.y, L_Hand.transform.position.z) ;
                L_Model.transform.rotation = L_Hand.transform.rotation;
            }
        }
        else
        {
            if (LeftCreateState == true)
            {
                PhotonNetwork.Destroy(L_Model);
                LeftCreateState = false;
            }
        }
    }
    void FindRightHand()
    {

        R_Hand = GameObject.Find("Right_ConicalGrabPointer(Clone)");

        if (R_Hand)
        {
            if (RightCreateState == false)
            {
                R_Model = PhotonNetwork.Instantiate("R_Model", R_Hand.transform.position, Quaternion.identity, 0);
                Debug.Log("create r_model");
                RightCreateState = true;
            }
            else
            {
                R_Model.transform.position = new Vector3(R_Hand.transform.position.x - 0.05f, R_Hand.transform.position.y, R_Hand.transform.position.z);
                R_Model.transform.rotation = R_Hand.transform.rotation;
            }
        }
        else
        {
            if (RightCreateState == true)
            {
                PhotonNetwork.Destroy(R_Model);
                RightCreateState = false;
            }
        }
    }
}
