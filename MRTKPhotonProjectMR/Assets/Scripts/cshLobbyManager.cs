using Photon.Pun;   // Photon 의 여러 기능을 포함 라이브러리를 Unity에서 컴포넌트로 사용 가능
using Photon.Realtime;  // Realtime Network 게임 개발 c# 라이브러리
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshLobbyManager : MonoBehaviourPunCallbacks // PUN 구현할때 override 사용해 코드 작성해야됨
{
    private string gameVersion = "1"; // 같은 버전끼리 매칭하기 위해 string 사용 숫자뿐만 아닌 다른 것도 사용 가능

    public Text connectionInfoText;
    public Button joinButton;
    public string enterScene;

    string scenename = "Lab";
    private void Start()
    {
        // 접속에 필요한 정보(게임 버전) 설정
        PhotonNetwork.GameVersion = gameVersion;
        // 설정한 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        // Room 접속 버튼 잠시 비활성화
        joinButton.interactable = false;
        // 접속 시도 중임을 텍스트로 표시
        //connectionInfoText.text = "Master 서버에 접속 중...";
        connectionInfoText.text = "Join Master server...";

    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        //connectionInfoText.text = "온라인: Master 서버와 연결됨";
        connectionInfoText.text = "On-line: Connect Master server";
        //base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        //connectionInfoText.text = "오프라인: Master 서버와 연결되지 않음\n접속 재시도 중...";
        connectionInfoText.text = "Off-line: Not connect Master server\nRetrying connection...";
        PhotonNetwork.ConnectUsingSettings();
        //base.OnDisconnected(cause);
    }

    public void Connect()
    {
        // 중복 접속 시도를 막기 위해 접속 버튼 잠시 비활성화
        joinButton.interactable = false;

        // Master 서버에 접속 중이라면
        if (PhotonNetwork.IsConnected)
        {
            //connectionInfoText.text = "Room에 접속...";
            connectionInfoText.text = "Join Room...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //connectionInfoText.text = "오프라인: Master 서버와 연결되지 않음\n접속 재시도 중...";
            connectionInfoText.text = "Off-line: Not connect Master server\nRetrying connection...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //connectionInfoText.text = "빈 방이 없음, 새로운 방 생성...";
        connectionInfoText.text = "No room available, create a new room...";

        // 새로운 방을 만들며 (방의 Name, 방의 옵션 설정)
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 8 });

        //base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        //connectionInfoText.text = "방 참가 성공";
        connectionInfoText.text = "Successfully joined the room";
        PhotonNetwork.LoadLevel(enterScene);

        //base.OnJoinedRoom();
    }

}