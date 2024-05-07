using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;
using UnityEngineInternal;

public class cshController : MonoBehaviour
{
    public int speedForward = 4; //���� �ӵ�
    public int speedSide = 2; //������ �ӵ�

    public GameObject RightController; //������ ��Ʈ�ѷ�
    public Transform posPrinter; //������ ��ġ
    public Transform posRock; //����ĳ�� ��ġ
    private Transform tr; //�÷��̾� Ʈ������
    private float dirX = 0;
    private float dirZ = 0;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        //MovePlayer();
        MovePlayer2();
        if(OVRInput.Get(OVRInput.Button.One)) Teleport();
    }
    void Teleport()
    {
        RaycastHit hit;

        if (Physics.Raycast(RightController.transform.position, RightController.transform.forward, out hit))
        {
            Debug.DrawRay(RightController.transform.position, RightController.transform.forward, Color.blue);
            Target target = hit.transform.GetComponent<Target>();
            if (hit.transform.name == "MovePrinter")
            {
                tr.position = hit.transform.position;
            }
            if (hit.transform.name == "MoveRock")
            {
                tr.position = posRock.transform.position;
            }

            Debug.Log(hit.transform.name);
        }
    }

    //�÷��̾� �̵�
    void MovePlayer()
    {
        dirX = 0;   //�¿� �̵� ����(����: -1, ������: 1)
        dirZ = 0;   //�յ� �̵� ����(����: -1, ����: 1)

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(coord.x);
            var absY = Mathf.Abs(coord.y);

            if(absX > absY)
            {
                //right
                if (coord.x > 0) dirX = +1;
                //left
                else dirX = -1;
            }
            else
            {
                //up
                if (coord.y > 0) dirZ = +1;
                //down
                else dirZ = -1;
            }
        }
        //�̵� ���� ���� �� �̵�
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

    void MovePlayer2()
    {
        dirX = 0;   //�¿� �̵� ����(����: -1, ������: 1)
        dirZ = 0;   //�յ� �̵� ����(����: -1, ����: 1)
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
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
}
