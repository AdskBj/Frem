using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class PlayerPanel : TTUIPage {

    private Button ExitBtn;
    private Button PhotoBtn;
    private Text Name;
    private Text Email;
    private Text Tel;
    private Text allCells;
    private Text cellA;
    private Text cellB;
    private Text cellC;

    private Image photo;
    Sprite p1, p2, p3, p4, p5, p6;

    public PlayerPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/PlayerPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Transform PLayerInfo = transform.Find("PLayerInfo");
        Transform CellInfo = transform.Find("CellInfo");

        ExitBtn = transform.Find("ExitBtn").GetComponent<Button>();
        PhotoBtn = transform.Find("PhotoBtn").GetComponent<Button>();

        Name = PLayerInfo.Find("Name").GetComponent<Text>();
        Email = PLayerInfo.Find("Email").GetComponent<Text>();
        Tel = PLayerInfo.Find("Tel").GetComponent<Text>();

        allCells = CellInfo.Find("allCells").GetComponent<Text>();
        cellA = CellInfo.Find("cellA").GetComponent<Text>();
        cellB = CellInfo.Find("cellB").GetComponent<Text>();
        cellC = CellInfo.Find("cellC").GetComponent<Text>();

        ExitBtn.onClick.AddListener(OnExitClick);
        PhotoBtn.onClick.AddListener(OnPhotoClick);       
    }
    public void ChangePhoto()
    {
        photo = GameObject.Find("InfoPhoto").GetComponent<Image>();
        p1 = Resources.Load<Sprite>("HeadImage/Image1");
        p2 = Resources.Load<Sprite>("HeadImage/Image2");
        p3 = Resources.Load<Sprite>("HeadImage/Image3");
        p4 = Resources.Load<Sprite>("HeadImage/Image4");
        p5 = Resources.Load<Sprite>("HeadImage/Image5");
        p6 = Resources.Load<Sprite>("HeadImage/Image6");
    }

    private void OnPhotoClick()
    {
        TTUIPage.ShowPage<PhotoPanel>();
    }

    private void OnExitClick()
    {
        Hide();
    }

    #region
    public void ChangePhoto1()
    {
        photo.sprite = p1;
    }
    public void ChangePhoto2()
    {
        photo.sprite = p2;
    }
    public void ChangePhoto3()
    {
        photo.sprite = p3;
    }
    public void ChangePhoto4()
    {
        photo.sprite = p4;
    }
    public void ChangePhoto5()
    {
        photo.sprite = p5;
    }
    public void ChangePhoto6()
    {
        photo.sprite = p6;
    }
    #endregion       
}
