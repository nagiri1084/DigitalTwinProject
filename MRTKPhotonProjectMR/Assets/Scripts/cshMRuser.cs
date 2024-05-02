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
        CreateRightHand();
        CreateLeftHand();
    }

    void CreateRightHand()
    {

        R_Hand = GameObject.Find("Right_PokePointer(Clone)");

        if (R_Hand)
        {
            if (!RightCreateState)
            {
                R_Model = PhotonNetwork.Instantiate("R_Model", R_Hand.transform.position, Quaternion.identity);
                Debug.Log("create r_model");
                RightCreateState = true;
                if (photonView.IsMine) //게임 사용자가 나라면
                {
                    R_Model.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                R_Model.transform.position = new Vector3(R_Hand.transform.position.x, R_Hand.transform.position.y - 0.1f, R_Hand.transform.position.z);
                R_Model.transform.rotation = R_Hand.transform.rotation;
                Debug.Log("transform r_model");
            }
        }
        else
        {
            if (RightCreateState)
            {
                PhotonNetwork.Destroy(R_Model);
                Debug.Log("Destroy r_model");
                RightCreateState = false;
            }
        }
    }

    void CreateLeftHand()
    {
        L_Hand = GameObject.Find("Left_PokePointer(Clone)");
        
        if (L_Hand)
        {
            if (!LeftCreateState)
            {
                L_Model = PhotonNetwork.Instantiate("L_Model", L_Hand.transform.position, Quaternion.identity);
                Debug.Log("create l_model");
                LeftCreateState = true;
                if (photonView.IsMine) //게임 사용자가 나라면
                {
                    L_Model.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                L_Model.transform.position = new Vector3(L_Hand.transform.position.x, L_Hand.transform.position.y - 0.1f, L_Hand.transform.position.z);
                L_Model.transform.rotation = L_Hand.transform.rotation;
                Debug.Log("transform l_model");
            }
        }
        else
        {
            if (LeftCreateState)
            {
                PhotonNetwork.Destroy(L_Model);
                Debug.Log("Destroy l_model");
                LeftCreateState = false;
            }
        }
    }

}
