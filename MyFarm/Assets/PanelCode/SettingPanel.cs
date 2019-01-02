using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class SettingPanel : TTUIPage {

    private Button ExitBtn;
    public SettingPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/SettingPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        ExitBtn = transform.Find("ExitBtn").GetComponent<Button>();

        ExitBtn.onClick.AddListener(OnExitClick);
    }

    private void OnExitClick()
    {
        Hide();
    }
}
