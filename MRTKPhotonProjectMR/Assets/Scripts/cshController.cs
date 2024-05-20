using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;
using UnityEngineInternal;

public class cshController : MonoBehaviour
{
    public GameObject posPrinter; //프린터 교육 위치
    public GameObject posRock; //광물캐기 교육 위치
    private cshTeleportMove cshTeleportMove; //텔레포트할 위치
    public GameObject playerAvatar; //사용자 아바타(캐릭터)
    public GameObject centerCamera;

    public int speedForward = 1; //전진 속도
    public int speedSide = 1; //옆걸음 속도

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

    //플레이어 이동

    void MovePlayer()
    {
        dirX = 0;   //좌우 이동 방향(왼쪽: -1, 오른쪽: 1)
        dirZ = 0;   //앞뒤 이동 방향(후진: -1, 전진: 1)
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)) //조이 스틱을 움직이면
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

    void TeleportPlayer()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && posPrinter != null) // 컨트롤러 A버튼을 눌르면
        {
            this.transform.position = posPrinter.transform.position; //텔레포트로 교육 위치 이동
            Debug.Log("Move to 3D Printer Edu position");
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && posRock != null) // 컨트롤러 B버튼을 눌르면
        {
            this.transform.position = posRock.transform.position; //텔레포트로 교육 위치 이동
            Debug.Log("Move to Rock Edu position");
        }
    }
}
