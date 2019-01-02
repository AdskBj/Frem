using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class ExitPanel : TTUIPage {

    private Button YesBtn;
    private Button NoBtn;
    public ExitPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/ExitPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        YesBtn = transform.Find("YesBtn").GetComponent<Button>();
        NoBtn = transform.Find("NoBtn").GetComponent<Button>();

        YesBtn.onClick.AddListener(OnYesBtnClick);
        NoBtn.onClick.AddListener(OnNosBtnClick);
    }

    private void OnYesBtnClick()
    {
        Application.Quit();
    }
    private void OnNosBtnClick()
    {
        Hide();
    } 
}
