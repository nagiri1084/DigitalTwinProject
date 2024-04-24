using Photon.Pun;   // Photon �� ���� ����� ���� ���̺귯���� Unity���� ������Ʈ�� ��� ����
using Photon.Realtime;  // Realtime Network ���� ���� c# ���̺귯��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshLobbyManager : MonoBehaviourPunCallbacks // PUN �����Ҷ� override ����� �ڵ� �ۼ��ؾߵ�
{
    private string gameVersion = "1"; // ���� �������� ��Ī�ϱ� ���� string ��� ���ڻӸ� �ƴ� �ٸ� �͵� ��� ����

    public Text connectionInfoText;
    public Button joinButton;
    public string enterScene;

    string scenename = "Lab";
    private void Start()
    {
        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = gameVersion;
        // ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        // Room ���� ��ư ��� ��Ȱ��ȭ
        joinButton.interactable = false;
        // ���� �õ� ������ �ؽ�Ʈ�� ǥ��
        //connectionInfoText.text = "Master ������ ���� ��...";
        connectionInfoText.text = "Join Master server...";

    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        //connectionInfoText.text = "�¶���: Master ������ �����";
        connectionInfoText.text = "On-line: Connect Master server";
        //base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        //connectionInfoText.text = "��������: Master ������ ������� ����\n���� ��õ� ��...";
        connectionInfoText.text = "Off-line: Not connect Master server\nRetrying connection...";
        PhotonNetwork.ConnectUsingSettings();
        //base.OnDisconnected(cause);
    }

    public void Connect()
    {
        // �ߺ� ���� �õ��� ���� ���� ���� ��ư ��� ��Ȱ��ȭ
        joinButton.interactable = false;

        // Master ������ ���� ���̶��
        if (PhotonNetwork.IsConnected)
        {
            //connectionInfoText.text = "Room�� ����...";
            connectionInfoText.text = "Join Room...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //connectionInfoText.text = "��������: Master ������ ������� ����\n���� ��õ� ��...";
            connectionInfoText.text = "Off-line: Not connect Master server\nRetrying connection...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //connectionInfoText.text = "�� ���� ����, ���ο� �� ����...";
        connectionInfoText.text = "No room available, create a new room...";

        // ���ο� ���� ����� (���� Name, ���� �ɼ� ����)
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 8 });

        //base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        //connectionInfoText.text = "�� ���� ����";
        connectionInfoText.text = "Successfully joined the room";
        PhotonNetwork.LoadLevel(enterScene);

        //base.OnJoinedRoom();
    }

}