using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTeleportMove : MonoBehaviour
{
    //public GameObject vrUser; //플레이어
    public int vrUserPosCnt = 0;
    public GameObject[] posPrinter; //프린터 교육 위치
    public GameObject[] posRock; //광물캐기 교육 위치


    //public void TeleportTo3DPrinterPos()
    //{
    //    if (vrUser == null)
    //    {
    //        vrUser = GameObject.Find("VRUser(Clone)");
    //    }
    //    else
    //    {
    //        vrUser.transform.position = posPrinter.transform.position; //텔레포트로 교육 위치 이동
    //        Debug.Log("Move to 3D Printer Edu position");
    //    }
    //}
    //public void TeleportToRockPos()
    //{
    //    if (vrUser == null)
    //    {
    //        vrUser = GameObject.Find("VRUser(Clone)");
    //    }
    //    else
    //    {
    //        vrUser.transform.position = posRock.transform.position; //텔레포트로 교육 위치 이동
    //        Debug.Log("Move to Rock Edu position");
    //    }
    //}

}
