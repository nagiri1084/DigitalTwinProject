using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshController : MonoBehaviour
{
    public int speedForward = 4; //���� �ӵ�
    public int speedSide = 2; //������ �ӵ�

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
