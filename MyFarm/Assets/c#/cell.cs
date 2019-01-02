using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class cell : MonoBehaviour {
    /// <summary>
    /// 总矿石数量
    /// </summary>
    public int kuangnumber;
    public int mofafen;
    
    private Text playernum;
    private Text playermofa; 
    /// <summary>
    /// 设定的key变量  用于后面标记点击的是哪块地
    /// </summary>
    public string key="c0"; 
    /// <summary>
    /// list数组 用于存放16块土地   方便使用
    /// </summary>
    public List<GameObject> cells = new List<GameObject>();
    /// <summary>
    /// 设置三个sprite变量用于接收获取到的图片
    /// </summary>
    Sprite im1; 
    Sprite im2 ;
    Sprite im3 ;
    /// <summary>
    /// 设置三个bool变量  用于设置反复高亮
    /// </summary>
    bool s = false;
    bool s1 = false;
    bool s2 = false;
    bool s3 = false;
    /// <summary>
    /// 创建三个颜色的实例
    /// 用于下文颜色的改变
    /// </summary>
    Color color = new Color();
    Color color1 = new Color();
    Color color2 = new Color();
    Color color3 = new Color();
    /// <summary>
    /// 设置16块地的实例  初始化名字
    /// </summary>
    cells t15 = new cells("c15");
    cells t14 = new cells("c14");
    cells t13 = new cells("c13");
    cells t12 = new cells("c12");
    cells t11 = new cells("c11");
    cells t10 = new cells("c10");
    cells t9 = new cells("c9");
    cells t8 = new cells("c8");
    cells t7 = new cells("c7");
    cells t6 = new cells("c6");
    cells t5 = new cells("c5");
    cells t4 = new cells("c4");
    cells t3 = new cells("c3");
    cells t2 = new cells("c2");
    cells t1 = new cells("c1");
    cells t0 = new cells("c0");
    List<cells> ts = new List<cells>();
    /// <summary>
    /// 创建一个<string, cells>类型字典
    /// </summary>
    public     Dictionary<string, cells> shuijingnum = new Dictionary<string, cells>();
   /// <summary>
   /// 用于显示当前矿石数量的文本
   /// </summary>
    public Text number;
    public Text nownumber;
    private GameObject ga;

    void Start () {
        for (int i = 0; i < 16; i++)
        {
            cells[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        }
        cells[15].transform.Find("texiao").gameObject.SetActive(false);
        //将土地实例添加到字典中
        shuijingnum.Add(t15.name,t15);
        shuijingnum.Add(t14.name, t14);
        shuijingnum.Add(t13.name, t13);
        shuijingnum.Add(t12.name, t12);
        shuijingnum.Add(t11.name, t11);
        shuijingnum.Add(t10.name, t10);
        shuijingnum.Add(t9.name, t9);
        shuijingnum.Add(t8.name, t8);
        shuijingnum.Add(t7.name, t7);
        shuijingnum.Add(t6.name, t6);
        shuijingnum.Add(t5.name, t5);
        shuijingnum.Add(t4.name, t4);
        shuijingnum.Add(t3.name, t3);
        shuijingnum.Add(t2.name, t2);
        shuijingnum.Add(t1.name, t1);
        shuijingnum.Add(t0.name,t0);
        //遍历字典中所有的土地  设置初始值为300
        foreach (var item in shuijingnum)
        {
            item.Value.nownum =300;
        }
        ts.Add(t15);
        ts.Add(t14);
        ts.Add(t13);
        ts.Add(t12);
        ts.Add(t11);
        ts.Add(t10);
        ts.Add(t9);
        ts.Add(t8);
        ts.Add(t7);
        ts.Add(t6);
        ts.Add(t5);
        ts.Add(t4);
        ts.Add(t3);
        ts.Add(t2);
        ts.Add(t1);

        ts.Add(t0);
        //找到图片来源
        im1 = Resources.Load<Sprite>("1");
        im2 = Resources.Load<Sprite>("2");
        im3 = Resources.Load<Sprite>("3");
        //设置初始状态
        s = true;
        s1 = true;
        s2 = true;
        s3 = true;
        //找到显示矿石当前数量弹窗并隐藏
        number = GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("Tip").transform.Find("tip").transform.Find("Nownum").gameObject.GetComponent<Text>();
        playernum = GameObject.Find("TextA").GetComponent<Text>();
        playermofa = GameObject.Find("TextB").GetComponent<Text>(); 
        nownumber = GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("nownumber").GetComponent<Text>();
        //cells[15].transform.Find("texiao").gameObject.SetActive(false);
       GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(false);
    }

    private bool TEXIAO=false;
    /// <summary>
    /// 第十六块地  编号为c15
    /// </summary>
    /// 
    public void kaikentudi15()
    {
        
        key = "c15";  //当点击这块地的时候  设置key的值为成c15
       
        if (cells[15].GetComponent<Image>().color == Color.red)//判断土地的颜色是否是红色  
        {
            cells[15].GetComponent<Image>().color =Color.white;// 如果是红色把他的颜色改为初始颜色
            if (kuangnumber>300)    //判断所拥有的矿石数量是否能够开垦土地  300开地
            {
                cells[15].GetComponent<Image>().sprite = im2;    //如果够开  那么把土地的图片换成im2
                shuijingnum[key].statue = Statue.增种;
                GameObject.Find("c15").transform.Find("kuang").transform.gameObject.SetActive(true);  //然后把矿石的图片显示出来

                Debug.Log(GameObject.Find("c15").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;   //自身的矿石数量减少300
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");//矿石不足就无法开垦土地
            }
            
           
        }
        if (cells[15].GetComponent<Image>().color == Color.blue) //如果这块地的颜色变为了蓝色   
        {
            //addheavy(t15);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true); //找到显示矿石当前数量弹窗并显示

        }
        if (cells[15].GetComponent<Image>().color == Color.cyan)  //如果土地的颜色为天蓝色
        {
           kuangnumber+=( shuijingnum["c15"].nownum-300);         //土地的矿石数量变为初始的300
            shuijingnum["c15"].nownum = 300;                        //自身拥有的矿石增加（土地所拥有的矿石总数-300）
            number.text = shuijingnum[key].nownum.ToString();     //将土地的矿石数量显示在弹窗上
            big(key);  //调用big方法  根据土地矿石数量把矿石图片大小改变
        }
        if (cells[15].GetComponent<Image>().color ==Color.magenta)
        {
            if (shuijingnum[key].nownum<3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            else
            {

            }
            TEXIAO = true;
           // GameObject s = cells[15].transform.Find("texiao").gameObject;
           //s.SetActive(true);
           // Debug.Log(s.name);
           //s.transform.localPosition=new Vector3(-12.8f, 13, -3.05175f)*Time.deltaTime;
           //Thread.Sleep(100);

        }
        
    }
    ///十六块地的开垦 
    #region
    public void kaikentudi14()
    {
        key = "c14";
        if (cells[14].GetComponent<Image>().color == Color.red)
        {
            cells[14].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[14].GetComponent<Image>().sprite = im2;
                GameObject.Find("c14").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c14").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[14].GetComponent<Image>().color == Color.blue)
        {
          
          //  addheavy(t14);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);
           
        }
        if (cells[14].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[14].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi13()
    {
        key = "c13";
        if (cells[13].GetComponent<Image>().color == Color.red)
        {
            cells[13].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 3000)
            {
                cells[13].GetComponent<Image>().sprite = im2;
                GameObject.Find("c13").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c13").transform.Find("kuang").gameObject.name);
                kuangnumber -= 3000;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[13].GetComponent<Image>().color == Color.blue)
        {
         
          
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[13].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 3000);
            shuijingnum[key].nownum = 3000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[13].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 30000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 200;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 30000;
                shuijingnum[key].nownum = 30000;

            }
            TEXIAO = true;
        }
    }
    public void kaikentudi12()
    {
        key = "c12";
        if (cells[12].GetComponent<Image>().color == Color.red)
        {
            cells[12].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 50000)
            {
                cells[12].GetComponent<Image>().sprite = im2;
                GameObject.Find("c12").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c12").transform.Find("kuang").gameObject.name);
                kuangnumber -= 50000;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[12].GetComponent<Image>().color == Color.blue)
        {
           
           
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[12].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 50000);
            shuijingnum[key].nownum = 50000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[12].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 300000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 400;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 300000;
                shuijingnum[key].nownum = 300000;

            }
            TEXIAO = true;
        }
    }
    public void kaikentudi11()
    {
        key = "c11";
        if (cells[11].GetComponent<Image>().color == Color.red)
        {
            cells[11].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[11].GetComponent<Image>().sprite = im2;
                GameObject.Find("c11").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c11").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[11].GetComponent<Image>().color == Color.blue)
        {
           
          //  addheavy(t11);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[11].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[11].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;

        }
    }
    public void kaikentudi10()
    {
        key = "c10";
        if (cells[10].GetComponent<Image>().color == Color.red)
        {
            cells[10].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[10].GetComponent<Image>().sprite = im2;
                GameObject.Find("c10").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c10").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[10].GetComponent<Image>().color == Color.blue)
        {
          
           // addheavy(t10);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[10].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[10].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;

        }
    }
    public void kaikentudi9()
    {
        key = "c9";
        if (cells[9].GetComponent<Image>().color == Color.red)
        {
            cells[9].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[9].GetComponent<Image>().sprite = im2;
                GameObject.Find("c9").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c9").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[9].GetComponent<Image>().color == Color.blue)
        {
           
           // addheavy(t9);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[9].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[9].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;

        }
    }
    public void kaikentudi8()
    {
        key = "c8";
        if (cells[8].GetComponent<Image>().color == Color.red)
        {
            cells[8].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[8].GetComponent<Image>().sprite = im2;
                GameObject.Find("c8").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c8").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[8].GetComponent<Image>().color == Color.blue)
        {
          
          //  addheavy(t8);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[8].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[8].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi7()
    {
        key = "c7";
        if (cells[7].GetComponent<Image>().color == Color.red)
        {
            cells[7].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[7].GetComponent<Image>().sprite = im2;
                GameObject.Find("c7").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c7").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[7].GetComponent<Image>().color == Color.blue)
        {
          
          //  addheavy(t7);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[7].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[7].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi6()
    {
        key = "c6";
        if (cells[6].GetComponent<Image>().color == Color.red)
        {
            cells[6].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[6].GetComponent<Image>().sprite = im2;
                GameObject.Find("c6").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c6").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[6].GetComponent<Image>().color == Color.blue)
        {
           
          //  addheavy(t6);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[6].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[6].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi5()
    {
        key = "c5";
        if (cells[5].GetComponent<Image>().color == Color.red)
        {
            cells[5].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[5].GetComponent<Image>().sprite = im2;
                GameObject.Find("c5").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c5").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[5].GetComponent<Image>().color == Color.blue)
        {
          
           // addheavy(t5);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[5].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[5].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi4()
    {
        key = "c4";
        if (cells[4].GetComponent<Image>().color == Color.red)
        {
            cells[4].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 300)
            {
                cells[4].GetComponent<Image>().sprite = im2;
                GameObject.Find("c4").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c4").transform.Find("kuang").gameObject.name);
                kuangnumber -= 300;
            }
            else
            {
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[4].GetComponent<Image>().color == Color.blue)
        {
           
           // addheavy(t4);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[4].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 300);
            shuijingnum[key].nownum = 300;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[4].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 3000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 100;
            }
            TEXIAO = true;
        }
    }
    public void kaikentudi3()
    {
        key = "c3";
        if (cells[3].GetComponent<Image>().color == Color.red)
        {
            cells[3].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 3000)
            {
                cells[3].GetComponent<Image>().sprite = im2;
                GameObject.Find("c3").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c3").transform.Find("kuang").gameObject.name);
                kuangnumber -= 3000;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[3].GetComponent<Image>().color == Color.blue)
        {
           
         //   addheavy(t3);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[3].GetComponent<Image>().color == Color.cyan)
        {

            kuangnumber += (shuijingnum[key].nownum - 3000);
            shuijingnum[key].nownum = 3000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);   
        }
        if (cells[3].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 30000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 200;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 30000;
                shuijingnum[key].nownum = 30000;

            }
            TEXIAO = true;
        }
    }
    public void kaikentudi2()
    {
        key = "c2";
        if (cells[2].GetComponent<Image>().color == Color.red)
        {
            cells[2].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 3000)
            {
                cells[2].GetComponent<Image>().sprite = im2;
                GameObject.Find("c2").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c2").transform.Find("kuang").gameObject.name);
                kuangnumber -= 3000;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[2].GetComponent<Image>().color == Color.blue)
        {
           
           // addheavy(t2);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[2].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 3000);
            shuijingnum[key].nownum = 3000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[2].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 30000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 200;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 30000;
                shuijingnum[key].nownum = 30000;

            }
            TEXIAO = true;
        }
    }
    public void kaikentudi1()
    {
        key = "c1";
        if (cells[1].GetComponent<Image>().color == Color.red)
        {
            cells[1].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 3000)
            {
                cells[1].GetComponent<Image>().sprite = im2;
                GameObject.Find("c1").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c1").transform.Find("kuang").gameObject.name);
                kuangnumber -= 3000;
            }
            else
            {
                GameObject.Find("RoomListPanel(Clone)").gameObject.transform.Find("mmm").transform.Find("Text").gameObject.SetActive(true);
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[1].GetComponent<Image>().color == Color.blue)
        {
           
          //  addheavy(t1);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[1].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 3000);
            shuijingnum[key].nownum = 3000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[1].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 30000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 200;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 30000;
                shuijingnum[key].nownum = 30000;

            }
            TEXIAO = true;
        }
    }
    public void kaikentudi0()
    {
        key = "c0";
        if (cells[0].GetComponent<Image>().color == Color.red)
        {
            cells[0].GetComponent<Image>().color = Color.white;
            if (kuangnumber > 3000)
            {
                cells[0].GetComponent<Image>().sprite = im2;
                GameObject.Find("c0").transform.Find("kuang").transform.gameObject.SetActive(true);

                Debug.Log(GameObject.Find("c0").transform.Find("kuang").gameObject.name);
                kuangnumber -= 3000;
            }
            else
            {
                print("矿石不足无法开垦耕地");
            }
        }
        if (cells[0].GetComponent<Image>().color == Color.blue)
        {
           
            //addheavy(t0);
            GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(true);

        }
        if (cells[0].GetComponent<Image>().color == Color.cyan)
        {
            kuangnumber += (shuijingnum[key].nownum - 3000);
            shuijingnum[key].nownum = 3000;
            number.text = shuijingnum[key].nownum.ToString();
            big(key);
        }
        if (cells[0].GetComponent<Image>().color == Color.magenta)
        {
            if (shuijingnum[key].nownum < 30000)
            {
                mofafen -= 100;
                shuijingnum[key].nownum += 200;
            }
            else
            {
                mofafen += shuijingnum[key].nownum - 30000;
                shuijingnum[key].nownum = 30000;

            }
            TEXIAO = true;
        }
    }
    #endregion
    /// <summary>
    /// 设置可开垦的土地为高亮
    /// </summary>
    public void gaoliang()  //
    {
        if (s==true)       {   
             color = Color.red;
        }
        else
        {
             color = Color.white;
        }
        for (int i = 0; i < cells.Count; i++)
        {
                if (cells[i].GetComponent<Image>().sprite.name != "2")
                {
                    cells[i].GetComponent<Image>().color = color;
                }
        }
        s = !s;
    }
    /// <summary>
    /// 设置可增种的土地为高亮
    /// </summary>
    public void zzgaoliang()
    {

        if (s1 == true)
        {
            color1 = Color.blue;
        }
        else
        {
            color1 = Color.white;
        }
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].GetComponent<Image>().sprite.name == "2")
            {
                cells[i].GetComponent<Image>().color =color1;
            }
        }
        s1 = !s1;
    }
    /// <summary>
    /// 设置可采集的土地颜色为高亮
    /// </summary>
    public void Caijigaoliang()
    {
        if (s2 == true)
        {
            color2 = Color.cyan;
        }
        else
        {
            color2 = Color.white;
        }
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].GetComponent<Image>().sprite.name == "2")
            {
                cells[i].GetComponent<Image>().color = color2;
            }
        } 
        s2 = !s2;
    }
    public void mofafengaoliang()
    {
        if (s3 == true)
        {
            color3 = Color.magenta;
        }
        else
        {
            color3 = Color.white;
        }
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].GetComponent<Image>().sprite.name == "2")
            {
                cells[i].GetComponent<Image>().color = color3;
            }
        }
        s3 = !s3;
    }
    // Update is called once per frame

    /// <summary>
    /// 兑换
    /// </summary>
    private bool dui;
    public void duihuan()
    {
        dui = true;
        if (dui == true)
        {
            if (kuangnumber>999)
            {
                kuangnumber -= 1000;
                mofafen += 100;
            }
           
            
            dui = false;
        }
    }
    void Update ()
    {

       
        playernum.text = kuangnumber.ToString();
        playermofa.text = mofafen.ToString();
        


        if (TEXIAO == false)
        {
                    GameObject.Find(key).transform.Find("tudi").transform.Find("texiao").gameObject.SetActive(false);
        }
        else
        {
                    GameObject.Find(key).transform.Find("tudi").transform.Find("texiao").gameObject.SetActive(true);
            
                    TEXIAO = false;
                    //GameObject.Find(key).transform.Find("tudi").transform.Find("texiao").gameObject.SetActive(true);
        }


        for (int i = 0; i < 16; i++)
        {
            if (cells[i].GetComponent<Image>().sprite == im2)
            {
                shuijingnum[key].statue = Statue.增种;
            }
            else
            {
                shuijingnum[key].statue = Statue.未开垦;
            }
        }
      
       


        nownumber.text = "当前土地水晶:" + shuijingnum[key].nownum.ToString();
        big(key);

    }
    private bool quxiao;
    private bool queding=false;
    /// <summary>
    /// 根据土地矿石的数量改变矿石图片的大小
    /// </summary>
    /// <param name="k"></param>
    public void  big(string k)//
    {
        if (shuijingnum[k].nownum > 1000)
        {
            GameObject.Find(k).transform.Find("kuang").gameObject.transform.localScale = new Vector3(1.5f, 1.5f,1.5F);
        }
        if (shuijingnum[k].nownum >= 3000)
        {
            GameObject.Find(k).transform.Find("kuang").gameObject.transform.localScale = new Vector3(2f, 2f,2F);
        }
        if (shuijingnum[k].nownum < 1000)
        {
            GameObject.Find(k).transform.Find("kuang").gameObject.transform.localScale = new Vector3(1f, 1f,1F);
        }
    }
    /// <summary>
    /// 弹窗的取消按钮(未实现)
    /// </summary>
    public void quxiao1()
    {
        
        quxiao = true;
    }
    /// <summary>
    /// 弹窗的确定按钮   每点击一次确定  土地的矿石的数量增加100 最高增加到3000   
    /// 玩家所拥有的矿石数量减少100
    /// </summary>
    public void queding1()
    {
        queding = true;
        number.text = shuijingnum[key].nownum.ToString();
        if (kuangnumber>0)
        {
            shuijingnum[key].nownum += 100;
            if (shuijingnum[key].name == "c13" || shuijingnum[key].name == "c3" || shuijingnum[key].name == "c2" || shuijingnum[key].name == "c1" || shuijingnum[key].name == "c0")
            {
                if (shuijingnum[key].nownum >= 30000)
                {
                    shuijingnum[key].nownum = 30000;
                }
            }
            if (shuijingnum[key].name == "c12")
            {
                if (shuijingnum[key].nownum >= 300000)
                {
                    shuijingnum[key].nownum = 300000;
                }
            }
            else
            {

                if (shuijingnum[key].nownum >= 3000)
                {
                    shuijingnum[key].nownum = 3000;
                }


            }


            kuangnumber -= 100;
           
        }
        big(key);
        number.text = shuijingnum[key].nownum.ToString();
    }
    /// <summary>
    /// 弹窗的X按钮   用于关闭弹窗
    /// </summary>
    public void setactive()
    {
        GameObject.Find("RoomListPanel(Clone)").transform.Find("Tip").gameObject.SetActive(false);
    }







}
/// <summary>
/// 土地类  土地有几个属性  名字   初始矿石数量 当前拥有矿石数量    土地的状态
/// </summary>
public class cells
{
    public string name;
    public int startnum=300;
    public int nownum=300;
    public Crop crop;
    public Statue statue;
    public cells    (string _name)
    {
        name = _name;

    }
} 
public enum Statue {未开垦,增种}  //枚举土地的状态
public enum Crop {蓝水晶,紫水晶,红水晶,绿水晶 }
