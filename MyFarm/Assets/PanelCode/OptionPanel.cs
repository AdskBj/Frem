using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;


public class OptionPanel : TTUIPage
{

    private Button startBtn;
    private Button closeBtn;
    private Dropdown dropdown1;
    private Dropdown dropdown2;
    public OptionPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/OptionPanel";
    }

    #region 生命周期
    //public override void Init(params object[] args)
    //{
    //    base.Init(args);
    //    skinPath = "OptionPanel";
    //    layer = PanelLayer.Panel;
    //}

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Transform skinTrans = gameObject.transform;
        //开始按钮
        startBtn = skinTrans.Find("StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartClick);
        //关闭按钮
        closeBtn = skinTrans.Find("CloseBtn").GetComponent<Button>();
        closeBtn.onClick.AddListener(OnCloseClick);
        //数量下拉框
        dropdown1 = skinTrans.Find("Dropdown1").GetComponent<Dropdown>();
        dropdown2 = skinTrans.Find("Dropdown2").GetComponent<Dropdown>();
    }
    #endregion

    public void OnStartClick()
    {
        PanelMgr.instance.ClosePanel("TitlePanel");
        int n1 = dropdown1.value + 1;
        int n2 = dropdown2.value + 1;
        Battle.instance.StartTwoCampBattle(n1, n2);
        ClosePage();
    }

    public void OnCloseClick()
    {
        ClosePage();
    }
}