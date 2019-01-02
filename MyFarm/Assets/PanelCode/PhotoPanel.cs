using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using System;

public class PhotoPanel : TTUIPage {

    private Button ExitBtn;
    MainPanel mainPanel = new MainPanel();
    PlayerPanel playerPanel = new PlayerPanel();
    
    private Button Btn1;
    private Button Btn2;
    private Button Btn3;
    private Button Btn4;
    private Button Btn5;
    private Button Btn6;

    public PhotoPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/PhotoPanel";

    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);

        ExitBtn = transform.Find("ExitBtn").GetComponent<Button>();
        ExitBtn.onClick.AddListener(OnExitClick);

        Btn1 = transform.Find("Btn1").GetComponent<Button>();
        Btn2 = transform.Find("Btn2").GetComponent<Button>();
        Btn3 = transform.Find("Btn3").GetComponent<Button>();
        Btn4 = transform.Find("Btn4").GetComponent<Button>();
        Btn5 = transform.Find("Btn5").GetComponent<Button>();
        Btn6 = transform.Find("Btn6").GetComponent<Button>();

        Btn1.onClick.AddListener(OnBtn1Click);
        Btn2.onClick.AddListener(OnBtn2Click);
        Btn3.onClick.AddListener(OnBtn3Click);
        Btn4.onClick.AddListener(OnBtn4Click);
        Btn5.onClick.AddListener(OnBtn5Click);
        Btn6.onClick.AddListener(OnBtn6Click);

        mainPanel.ChangePhoto();
        playerPanel.ChangePhoto();
    }

    private void OnExitClick()
    {
        Hide();
    }

    private void OnBtn1Click()
    {
        mainPanel.ChangePhoto1();
        playerPanel.ChangePhoto1();
    }

    private void OnBtn2Click()
    {
        mainPanel.ChangePhoto2();
        playerPanel.ChangePhoto2();
    }

    private void OnBtn3Click()
    {
        mainPanel.ChangePhoto3();
        playerPanel.ChangePhoto3();
    }

    private void OnBtn4Click()
    {
        mainPanel.ChangePhoto4();
        playerPanel.ChangePhoto4();
    }

    private void OnBtn5Click()
    {
        mainPanel.ChangePhoto5();
        playerPanel.ChangePhoto5();
    }

    private void OnBtn6Click()
    {
        mainPanel.ChangePhoto6();
        playerPanel.ChangePhoto6();
    }
}
