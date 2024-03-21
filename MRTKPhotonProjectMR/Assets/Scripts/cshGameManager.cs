using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class cshGameManager : MonoBehaviourPun // ������ ���� ���� ���� �� ���� UI�� �����ϴ� ���� �Ŵ��� ��ũ��Ʈ
{
    public static cshGameManager instance // �ܺο��� �̱��� ������Ʈ�� �����ö� ����� ������Ƽ
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<cshGameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static cshGameManager m_instance; // �̱����� �Ҵ�� static ����

    public GameObject[] Players;
    public GameObject[] PlayersPos;


    //private GameObject MixedRealitySceneContent;
    //public GameObject MixedRealityPlayspace; // ������ MR �÷��̾� ĳ����
    //public GameObject MixedRealityToolkit;
    //public GameObject MRPlayerPrefab; // ������ VR �÷��̾� ĳ����
    public GameObject VRPlayerPrefab; // ������ VR �÷��̾� ĳ����

    //public GameObject MRSpawnPosPrefab; // ������ VR �÷��̾� ĳ������ ��ġ
    //public GameObject VRSpawnPosPrefab; // ������ AR �÷��̾� ĳ������ ��ġ


    private int playerCnt = 0;

    public int userId;

    Hashtable Player = new Hashtable();
    bool state = true;
    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        userId = GameObject.FindWithTag("UserId").GetComponent<cshSelectUser>().userId;
        //userId = GameObject.Find("UserId").GetComponent<cshSelectUser>().userId;
        //PC Editor Ȯ�θ��//////
        //Photon.Realtime.Player[] plys = PhotonNetwork.PlayerListOthers;
        //playerCnt = PhotonNetwork.CountOfPlayers - 1;
        /////////////////////////
        ///
        //if (playerCnt == 0)
        //if (Application.platform != RuntimePlatform.Android)
        //Vector3 randomSpawnPos = PlayersPos[userId].transform.position;//Random.insideUnitSphere * 5f;
        //PhotonNetwork.Instantiate(Players[userId].name, randomSpawnPos, Quaternion.identity);

        //�����ʰ��Բ� ���Ӹ޴����� �����ϱ����Ͽ� ArrayList�� ���

        if (userId == 1)
        {
            // ������ ���� ��ġ ����
            //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);//Random.insideUnitSphere * 5f;

            // ��Ʈ��ũ���� ��� Ŭ���̾�Ʈ���� ���� ����  
            // �ش� ���� ������Ʈ�� �ֵ����� ���� �޼��带 ���� ������ Ŭ���̾�Ʈ�� ����
            PhotonNetwork.Instantiate(VRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
            //playerCnt++;
        }
        else
        {
            //Vector3 randomSpawnPos = MRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);///Random.insideUnitSphere * 5f;
            //PhotonNetwork.Instantiate(MixedRealityPlayspace.name, randomSpawnPos, Quaternion.identity);
            //PhotonNetwork.Instantiate(MixedRealityToolkit.name, randomSpawnPos, Quaternion.identity);
            //MixedRealityPlayspace = GameObject.Find("MixedRealityPlayspace");
            //GameObject MRPCamera = MixedRealityPlayspace.transform.GetChild(0).gameObject;
            //GameObject temp = PhotonNetwork.Instantiate(MRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
            //temp.transform.parent = MRPCamera.transform;
        }

        //else
        /*
        if (Application.platform == RuntimePlatform.Android) // Android ����̽� ���       
        {
            //Vector3 randomSpawnPos = MRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);///Random.insideUnitSphere * 5f;
            PhotonNetwork.Instantiate(MRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
        }
        else
        {
                // ������ ���� ��ġ ����
                //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);///Random.insideUnitSphere * 5f;
            // ��Ʈ��ũ���� ��� Ŭ���̾�Ʈ���� ���� ����  
            // �ش� ���� ������Ʈ�� �ֵ����� ���� �޼��带 ���� ������ Ŭ���̾�Ʈ�� ����
            PhotonNetwork.Instantiate(VRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
                //playerCnt++;

        }
        */
        //if (Application.platform == RuntimePlatform.Android) // Android ����̽� ���       
    }

    void PlayerViewSystem()
    {

    }
}