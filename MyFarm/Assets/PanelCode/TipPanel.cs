using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class TipPanel : TTUIPage
{
    private Text text;
    private Button btn;
    string str = "";

    public TipPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/TipPanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        str = data.ToString();

        text = transform.Find("Text").GetComponent<Text>();
        text.text = str;
        //关闭按钮
        btn = transform.Find("Btn").GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);
    }
    public override void Refresh()
    {
        base.Refresh();

        str = data.ToString();
        text.text = str;
    }

    //按下“知道了”按钮的事件
    public void OnBtnClick()
    {

        Hide();
    }
}