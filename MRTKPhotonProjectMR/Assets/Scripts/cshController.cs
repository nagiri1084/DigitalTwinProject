using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;
using UnityEngineInternal;

public class cshController : MonoBehaviour
{
    public GameObject posPrinter; //������ ���� ��ġ
    public GameObject posRock; //����ĳ�� ���� ��ġ
    private cshTeleportMove cshTeleportMove; //�ڷ���Ʈ�� ��ġ
    public GameObject playerAvatar; //����� �ƹ�Ÿ(ĳ����)
    public GameObject centerCamera;

    public int speedForward = 1; //���� �ӵ�
    public int speedSide = 1; //������ �ӵ�

    private float dirX = 0;
    private float dirZ = 0;

    void Start()
    {
        cshTeleportMove = GameObject.Find("TeleportMove").transform.GetComponent<cshTeleportMove>();
        posPrinter = cshTeleportMove.posPrinter[cshTeleportMove.vrUserPosCnt];
        posRock = cshTeleportMove.posRock[cshTeleportMove.vrUserPosCnt];
    }

    private void Update()
    {
        MovePlayer();
        TeleportPlayer();

        playerAvatar.transform.position = centerCamera.transform.position;
        playerAvatar.transform.rotation = centerCamera.transform.rotation;
    }

    //�÷��̾� �̵�

    void MovePlayer()
    {
        dirX = 0;   //�¿� �̵� ����(����: -1, ������: 1)
        dirZ = 0;   //�յ� �̵� ����(����: -1, ����: 1)
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)) //���� ��ƽ�� �����̸�
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (coord.x < 0) //����
                dirX = -1;
            else if (coord.x > 0) //������
                dirX = +1;
            if (coord.y < 0) //�Ʒ�
                dirZ = -1;
            else if (coord.y > 0) //��
                dirZ = +1;
        }
        //�̵� ���� ���� �� �̵�
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

    void TeleportPlayer()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && posPrinter != null) // ��Ʈ�ѷ� A��ư�� ������
        {
            this.transform.position = posPrinter.transform.position; //�ڷ���Ʈ�� ���� ��ġ �̵�
            Debug.Log("Move to 3D Printer Edu position");
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && posRock != null) // ��Ʈ�ѷ� B��ư�� ������
        {
            this.transform.position = posRock.transform.position; //�ڷ���Ʈ�� ���� ��ġ �̵�
            Debug.Log("Move to Rock Edu position");
        }
    }
}
