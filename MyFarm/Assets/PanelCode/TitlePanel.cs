using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class TitlePanel : TTUIPage
{

    private Button startBtn;
    private Button infoBtn;
    public TitlePanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/TitlePanel";
    }
    #region 生命周期
    //public override void Init(params object[] args)
    //{
    //    base.Init(args);
    //    skinPath = "TitlePanel";
    //    layer = PanelLayer.Panel;
    //}
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Transform skinTrans = gameObject.transform;
        startBtn = skinTrans.Find("StartBtn").GetComponent<Button>();
        infoBtn = skinTrans.Find("InfoBtn").GetComponent<Button>();

        startBtn.onClick.AddListener(OnStartClick);
        infoBtn.onClick.AddListener(OnInfoClick);
    }
    #endregion


    public void OnStartClick()
    {
        //设置
        TTUIPage.ShowPage<OptionPanel>("");
        //PanelMgr.instance.OpenPanel<OptionPanel>("");
    }

    public void OnInfoClick()
    {
        TTUIPage.ShowPage<InfoPanel>("");
       // PanelMgr.instance.OpenPanel<InfoPanel>("");
    }
}