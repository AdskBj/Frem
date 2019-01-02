using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class InfoPanel : TTUIPage
{
    public InfoPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    { 
        uiPath = "UIPrefab/InfoPanel";
    }
    private Button closeBtn;

    #region 生命周期
    //public override void Init(params object[] args)
    //{
    //    base.Init(args);
    //    skinPath = "InfoPanel";
    //    layer = PanelLayer.Panel;
    //}


    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Transform skinTrans = gameObject.transform;
        closeBtn = skinTrans.Find("CloseBtn").GetComponent<Button>();

        closeBtn.onClick.AddListener(OnCloseClick);
    }
    #endregion

    public void OnCloseClick()
    {
       ClosePage();
    }
}