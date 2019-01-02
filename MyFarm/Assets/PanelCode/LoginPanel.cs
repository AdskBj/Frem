using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class LoginPanel : TTUIPage
{
    private InputField idInput;
    private InputField pwInput;
    private Button loginBtn;
    private Button regBtn;

    public LoginPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/LoginPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);

        idInput = transform.Find("IDInput").GetComponent<InputField>();
        pwInput = transform.Find("PWInput").GetComponent<InputField>();
        loginBtn = transform.Find("LoginBtn").GetComponent<Button>();
        regBtn = transform.Find("RegBtn").GetComponent<Button>();

        loginBtn.onClick.AddListener(OnLoginClick);
        regBtn.onClick.AddListener(OnRegClick);
    }

    public void OnRegClick()
    {

        TTUIPage.ShowPage<RegPanel>("");
        ClosePage();
    }

    public void OnLoginClick()
    {
        
        //用户名密码为空
        if (idInput.text == "" || pwInput.text == "")
        {
            TTUIPage.ShowPage<TipPanel>("用户名密码不能为空");

            return;
        }
        if (idInput.text.Length < 4 || idInput.text.Length > 20 || pwInput.text.Length < 4 || pwInput.text.Length > 20)
        {
            TTUIPage.ShowPage<TipPanel>("用户名密码长度必须是4-20位");
            return;
        }
        //只能由数字字母和下划线组成
        string str = @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\";
        for (int i = 0; i < idInput.text.Length; i++)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (idInput.text[i].Equals(str[j]))
                {
                    TTUIPage.ShowPage<TipPanel>("用户名只能由数字字母下划线组成");
                }
            }
        }
        string str1 = @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\_";
        for (int i = 0; i < pwInput.text.Length; i++)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (pwInput.text[i].Equals(str1[j]))
                {
                    TTUIPage.ShowPage<TipPanel>("密码只能由数字字母组成");
                }
            }
        }
       
       
      
        
        // 连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "10.0.0.83";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))

                TTUIPage.ShowPage<TipPanel>("连接服务器失败!");
        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Login");
        protocol.AddString(idInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnLoginBack);

        //Hide();
    }


    public void OnLoginBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);

        if (ret == 0)
        {
            TTUIPage.ShowPage<TipPanel>("登陆成功");
            //开始游戏
            Debug.Log("111");

            Hide();
            TTUIPage.ShowPage<RoomListPanel>("");
            TTUIPage.ShowPage<MainPanel>("");
        }
        else
        {
            TTUIPage.ShowPage<TipPanel>("登录失败，请检查用户名密码!");

        }
    }
}