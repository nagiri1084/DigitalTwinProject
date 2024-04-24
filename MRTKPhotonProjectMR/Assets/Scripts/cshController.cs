using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshController : MonoBehaviour
{
    public int speedForward = 4; //전진 속도
    public int speedSide = 2; //옆걸음 속도

    private Transform tr; //플레이어 트랜스폼
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

    //플레이어 이동
    void MovePlayer()
    {
        dirX = 0;   //좌우 이동 방향(왼쪽: -1, 오른쪽: 1)
        dirZ = 0;   //앞뒤 이동 방향(후진: -1, 전진: 1)

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
        //이동 방향 설정 후 이동
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

    void MovePlayer2()
    {
        dirX = 0;   //좌우 이동 방향(왼쪽: -1, 오른쪽: 1)
        dirZ = 0;   //앞뒤 이동 방향(후진: -1, 전진: 1)
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (coord.x < 0) //왼쪽
                dirX = -1;
            else if (coord.x > 0) //오른쪽
                dirX = +1;
            if (coord.y < 0) //아래
                dirZ = -1;
            else if (coord.y > 0) //위
                dirZ = +1;
        }
        //이동 방향 설정 후 이동
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }
}
