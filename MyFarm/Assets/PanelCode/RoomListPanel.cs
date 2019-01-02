using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class RoomListPanel : TTUIPage
{
    private Text idText;
    private Text winText;
    private Text lostText;
    private Transform content;
    private GameObject roomPrefab;
    private Button closeBtn;
    private Button newBtn;
    private Button reflashBtn;
    public RoomListPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/RoomListPanel";
    }

    #region 生命周期
    /// <summary> 初始化 </summary>
    //public override void Init(params object[] args)
    //{
    //    base.Init(args);
    //    skinPath = "RoomListPanel";
    //    layer = PanelLayer.Panel;
    //}
    #endregion
    public override void Awake(GameObject go)
    {
        base.Awake(go);

        //    Transform skinTrans = gameObject.transform;
        //    Transform listTrans = skinTrans.Find("ListImage");
        //    Transform winTrans = skinTrans.Find("WinImage");
        //    //获取成绩栏部件
        //    idText = winTrans.Find("IDText").GetComponent<Text>();
        //    winText = winTrans.Find("WinText").GetComponent<Text>();
        //    lostText = winTrans.Find("LostText").GetComponent<Text>();
        //    //获取列表栏部件
        //    Transform scroolRect = listTrans.Find("ScrollRect");
        //    content = scroolRect.Find("Content");
        //    roomPrefab = content.Find("RoomPrefab").gameObject;
        //    roomPrefab.SetActive(false);

        //    closeBtn = listTrans.Find("CloseBtn").GetComponent<Button>();
        //    newBtn = listTrans.Find("NewBtn").GetComponent<Button>();
        //    reflashBtn = listTrans.Find("ReflashBtn").GetComponent<Button>();

        //    reflashBtn.onClick.AddListener(OnReflashClick);
        //    newBtn.onClick.AddListener(OnNewClick);
        //    closeBtn.onClick.AddListener(OnCloseClick);
        //    //监听
        //    NetMgr.srvConn.msgDist.AddListener("GetAchieve", RecvGetAchieve);
        //    NetMgr.srvConn.msgDist.AddListener("GetRoomList", RecvGetRoomList);

        //    //发送查询
        //    ProtocolBytes protocol = new ProtocolBytes();
        //    protocol.AddString("GetRoomList");
        //    NetMgr.srvConn.Send(protocol);

        //    protocol = new ProtocolBytes();
        //    protocol.AddString("GetAchieve");
        //    NetMgr.srvConn.Send(protocol);
        //}
        ////收到GetAchieve协议
        //public void RecvGetAchieve(ProtocolBase protocol)
        //{
        //    //解析协议
        //    ProtocolBytes proto = (ProtocolBytes)protocol;
        //    int start = 0;
        //    string protoName = proto.GetString(start, ref start);
        //    int win = proto.GetInt(start, ref start);
        //    int lost = proto.GetInt(start, ref start);
        //    //处理
        //    idText.text = "指挥官：" + GameMgr.instance.id;
        //    winText.text = win.ToString();
        //    lostText.text = lost.ToString();
        //}


        ////收到GetRoomList协议                                                                                        
        //public void RecvGetRoomList(ProtocolBase protocol)
        //{
        //    //清理
        //    ClearRoomUnit();
        //    //解析协议
        //    ProtocolBytes proto = (ProtocolBytes)protocol;
        //    int start = 0;
        //    string protoName = proto.GetString(start, ref start);
        //    int count = proto.GetInt(start, ref start);
        //    for (int i = 0; i < count; i++)
        //    {
        //        int num = proto.GetInt(start, ref start);
        //        int status = proto.GetInt(start, ref start);
        //        GenerateRoomUnit(i, num, status);
        //    }
        //}

        //public void ClearRoomUnit()
        //{
        //    for (int i = 0; i < content.childCount; i++)
        //        if (content.GetChild(i).name.Contains("Clone"))
        //            content.GetChild(i).gameObject.SetActive(false);
        //}


        //创建一个房间单元
        //参数 i，房间序号（从0开始）
        //参数num，房间里的玩家数
        //参数status，房间状态，1-准备中 2-战斗中
        //public void GenerateRoomUnit(int i, int num, int status)
        //{
        //    //添加房间
        //    content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (i + 1) * 110);
        //    GameObject o =GameObject.Instantiate(roomPrefab);
        //    o.transform.SetParent(content);
        //    o.transform.localScale = new Vector3(1, 1, 1);
        //    o.SetActive(true);
        //    //房间信息
        //    Transform trans = o.transform;
        //    Text nameText = trans.Find("nameText").GetComponent<Text>();
        //    Text countText = trans.Find("CountText").GetComponent<Text>();
        //    Text statusText = trans.Find("StatusText").GetComponent<Text>();
        //    nameText.text = "序号：" + (i + 1).ToString();
        //    countText.text = "人数：" + num.ToString();
        //    if (status == 1)
        //    {
        //        statusText.color = Color.black;
        //        statusText.text = "状态：准备中";
        //    }
        //    else
        //    {
        //        statusText.color = Color.red;
        //        statusText.text = "状态：开战中";
        //    }
        //    //按钮事件
        //    Button btn = trans.Find("JoinButton").GetComponent<Button>();
        //    btn.name = i.ToString();   //改变按钮的名字，以便给OnJoinBtnClick传参
        //    btn.onClick.AddListener(delegate()
        //    {
        //        OnJoinBtnClick(btn.name);
        //    }
        //    );
        //}


        ////刷新按钮
        //public void OnReflashClick()
        //{
        //    ProtocolBytes protocol = new ProtocolBytes();
        //    protocol.AddString("GetRoomList");
        //    NetMgr.srvConn.Send(protocol);
        //}

        ////加入按钮
        //public void OnJoinBtnClick(string name)
        //{
        //    ProtocolBytes protocol = new ProtocolBytes();
        //    protocol.AddString("EnterRoom");

        //    protocol.AddInt(int.Parse(name));
        //    NetMgr.srvConn.Send(protocol, OnJoinBtnBack);
        //    Debug.Log("请求进入房间 " + name);
        //}

        ////加入按钮返回
        //public void OnJoinBtnBack(ProtocolBase protocol)
        //{
        //    //解析参数
        //    ProtocolBytes proto = (ProtocolBytes)protocol;
        //    int start = 0;
        //    string protoName = proto.GetString(start, ref start);
        //    int ret = proto.GetInt(start, ref start);
        //    //处理
        //    if (ret == 0)
        //    {   TTUIPage.ShowPage<TipPanel>( "成功进入房间!");
        //        //PanelMgr.instance.OpenPanel<TipPanel>("", "成功进入房间!");

        //        //PanelMgr.instance.OpenPanel<RoomPanel>("");
        //        TTUIPage.ShowPage<RoomPanel>("");
        //        Hide();
        //    }
        //    else
        //    {
        //        TTUIPage.ShowPage<TipPanel>("进入房间失败");
        //        //PanelMgr.instance.OpenPanel<TipPanel>("", "进入房间失败");
        //    }
        //}

        ////新建按钮
        //public void OnNewClick()
        //{
        //    ProtocolBytes protocol = new ProtocolBytes();
        //    protocol.AddString("CreateRoom");
        //    NetMgr.srvConn.Send(protocol, OnNewBack);
        //}

        ////新建按钮返回
        //public void OnNewBack(ProtocolBase protocol)
        //{
        //    //解析参数
        //    ProtocolBytes proto = (ProtocolBytes)protocol;
        //    int start = 0;
        //    string protoName = proto.GetString(start, ref start);
        //    int ret = proto.GetInt(start, ref start);
        //    //处理
        //    if (ret == 0)
        //    {
        //        TTUIPage.ShowPage<TipPanel>("创建成功!");

        //        TTUIPage.ShowPage<RoomPanel>("");
        //        Hide();

        //    }
        //    else
        //    {
        //        TTUIPage.ShowPage<TipPanel>("创建房间失败");

        //    }
        //    gameObject.SetActive(false);
        //}

        ////登出按钮
        //public void OnCloseClick()
        //{
        //    ProtocolBytes protocol = new ProtocolBytes();
        //    protocol.AddString("Logout");
        //    NetMgr.srvConn.Send(protocol, OnCloseBack);
        //}

        ////登出返回
        //public void OnCloseBack(ProtocolBase protocol)
        //{
        //  TTUIPage.ShowPage<TipPanel>("登出成功");

        //    ClosePage();
        //    NetMgr.srvConn.Close();
        //    gameObject.SetActive(false);
        //    TTUIPage.ShowPage<LoginPanel>("");
        //}
    }
}
