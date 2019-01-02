using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class RegPanel : TTUIPage
{
    private InputField idInput;
    private InputField pwInput;
    private Button regBtn;
    private Button closeBtn;
    private InputField repInput;

    public RegPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/RegPanel";
    }


    public override void Awake(GameObject go)
    {
        base.Awake(go);

        idInput = transform.Find("IDInput").GetComponent<InputField>();
        pwInput = transform.Find("PWInput").GetComponent<InputField>();
        regBtn = transform.Find("RegBtn").GetComponent<Button>();
        closeBtn = transform.Find("CloseBtn").GetComponent<Button>();
        repInput = transform.Find("RepInput").GetComponent<InputField>();

        regBtn.onClick.AddListener(OnRegClick);
        closeBtn.onClick.AddListener(OnCloseClick);
    }
    
    public void OnCloseClick()
    {
        Hide();
    }

    public void OnRegClick()
    {
        TTUIPage.ShowPage<LoginPanel>("");

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
                    TTUIPage.ShowPage<TipPanel>("只能由数字字母下划线组成");
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
        //两次密码不同
        if (pwInput.text != repInput.text)
        {
            TTUIPage.ShowPage<TipPanel>("两次输入的密码不同!!");

            return;
        }
        //连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "10.0.0.68";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))
                // PanelMgr.instance.OpenPanel<TipPanel>("", "连接服务器失败!");
                TTUIPage.ShowPage<TipPanel>("连接服务器失败!");
        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Register");
        protocol.AddString(idInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnRegBack);
    }

    public void OnRegBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);
        if (ret == 0)
        {
            TTUIPage.ShowPage<TipPanel>("注册成功!");

            TTUIPage.ShowPage<LoginPanel>("");
            Hide();
            ClosePage();
        }
        else
        {
            TTUIPage.ShowPage<TipPanel>("注册失败!");
        }
    }
}