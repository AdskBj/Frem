using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class Root : MonoBehaviour
{

    void Start()
    {
        Application.runInBackground = true;
        //PanelMgr.instance.OpenPanel<LoginPanel>("");
        TTUIPage.ShowPage<LoginPanel>();
    }

    void Update()
    {
        NetMgr.Update();
    }
}
