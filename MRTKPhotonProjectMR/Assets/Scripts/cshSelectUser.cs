using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSelectUser : MonoBehaviour
{
    public int userId = 0; // 0:MR, 1:VR,
    public Button[] btnUserList;
    public cshLobbyManager cshLobbyManager;
    private float time;
    private bool Connect = false;

    public Text btnUsertxt;
    string[] UserList = { "MR", "VR"};

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //btnUserList[userId-1].interactable = false;
        //btnUserList[userId-1].colors = setColor(btnUserList[userId - 1], Color.cyan);
        btnUsertxt.text = UserList[userId];
    }

    // Update is called once per frame
    void Update()
    {
        //if(time <= 11 && userId != 1)
        //    TimeCheck();
    }

    private void TimeCheck()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time >= 10 && Connect == false)
        {
            Connect = true;
            userId = 0;
            btnUsertxt.text = UserList[userId];
            cshLobbyManager.GetComponent<cshLobbyManager>().Connect();
        }
    }

    public void SelectPlayer(int id)
    {
        userId = id;
        for (int i = 0; i < btnUserList.Length; i++)
        {
            btnUserList[i].interactable = true;
            btnUserList[i].colors = setColor(btnUserList[i], new Color(200 / 255f, 200 / 255f, 200 / 255f, 128 / 255f));
        }

        btnUserList[id - 1].interactable = false;
        btnUserList[id - 1].colors = setColor(btnUserList[id - 1], Color.cyan);
    }

    private ColorBlock setColor(Button b, Color c)
    {
        ColorBlock cb = b.colors;
        cb.disabledColor = c;
        return cb;
    }

    public void SelectVR()
    {
        if (userId == 0)
        {
            userId = 1;
            btnUsertxt.text = UserList[userId];
        }
        else
        {
            userId = 0;
            btnUsertxt.text = UserList[userId];
        }
    }
}