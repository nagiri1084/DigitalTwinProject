using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTeleportMove : MonoBehaviour
{
    //public GameObject vrUser; //�÷��̾�
    public int vrUserPosCnt = 0;
    public GameObject[] posPrinter; //������ ���� ��ġ
    public GameObject[] posRock; //����ĳ�� ���� ��ġ


    //public void TeleportTo3DPrinterPos()
    //{
    //    if (vrUser == null)
    //    {
    //        vrUser = GameObject.Find("VRUser(Clone)");
    //    }
    //    else
    //    {
    //        vrUser.transform.position = posPrinter.transform.position; //�ڷ���Ʈ�� ���� ��ġ �̵�
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
    //        vrUser.transform.position = posRock.transform.position; //�ڷ���Ʈ�� ���� ��ġ �̵�
    //        Debug.Log("Move to Rock Edu position");
    //    }
    //}

}
