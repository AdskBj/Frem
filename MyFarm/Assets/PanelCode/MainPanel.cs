using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class MainPanel : TTUIPage
{
    private Button B1;
    private Button B2;
    private Button B3;
    private Button B4;
    private Button ExitBtn;
    private Button SettingBtn;
    private Button WarehouseBtn;
    private Button PlayerBtn;
    private Text T1;
    private Text T2;

    private Image photo;
    Sprite p1,p2,p3,p4,p5,p6;
    private cell S;

    public MainPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/MainPanel";
    }
    public override void Awake(GameObject go)
    {
        S = new cell();
        base.Awake(go);

        Transform numA = transform.Find("NumA");
        Transform numB = transform.Find("NumB");

        //B1 = transform.Find("B1").GetComponent<Button>();
        //B2 = transform.Find("B2").GetComponent<Button>();
        //B3 = transform.Find("B3").GetComponent<Button>();
        //B4 = transform.Find("B4").GetComponent<Button>();
        ExitBtn = transform.Find("ExitBtn").GetComponent<Button>();
        SettingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        WarehouseBtn = transform.Find("WarehouseBtn").GetComponent<Button>();
        PlayerBtn = transform.Find("PlayerBtn").GetComponent<Button>();

        T1 = numA.Find("TextA").GetComponent<Text>();
        T2 = numB.Find("TextB").GetComponent<Text>();

        //B1.onClick.AddListener(OnB1Click);
        //B2.onClick.AddListener(OnB2Click);
        //B3.onClick.AddListener(OnB3Click);
        //B4.onClick.AddListener(OnB4Click);
        ExitBtn.onClick.AddListener(OnExitClick);
        SettingBtn.onClick.AddListener(OnSettingClick);
        WarehouseBtn.onClick.AddListener(OnWarehouseClick);
        PlayerBtn.onClick.AddListener(OnPlayerClick);


    }
    public void ChangePhoto()
    {
        photo = GameObject.Find("MainPhoto").GetComponent<Image>();



        p1 = Resources.Load<Sprite>("HeadImage/Image1");
        p2 = Resources.Load<Sprite>("HeadImage/Image2");
        p3 = Resources.Load<Sprite>("HeadImage/Image3");
        p4 = Resources.Load<Sprite>("HeadImage/Image4");
        p5 = Resources.Load<Sprite>("HeadImage/Image5");
        p6 = Resources.Load<Sprite>("HeadImage/Image6");
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
    
    //private void OnB1Click()
    //{

    //    S.gaoliang();

    //}

    //private void OnB2Click()
    //{
    //    S.zzgaoliang();
    //}

    //private void OnB3Click()
    //{

    //}

    //private void OnB4Click()
    //{
    //    S.Caijigaoliang();
    //}

    private void OnExitClick()
    {
        TTUIPage.ShowPage<ExitPanel>();
    }

    private void OnSettingClick()
    {
        TTUIPage.ShowPage<SettingPanel>();
    }

    private void OnWarehouseClick()
    {
        TTUIPage.ShowPage<WarehousePanel>();
    }

    private void OnPlayerClick()
    {
        TTUIPage.ShowPage<PlayerPanel>();
    }

}
