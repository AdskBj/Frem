using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMsg : MonoBehaviour {

  public  cell p1 = new cell();
    int s;
    int s1;

   public void send()
    {
        s = p1.kuangnumber;
        s1 = p1.mofafen;
        //p1.shuijingnum[]
        Debug.Log(s);
        Debug.Log(s1);
    }
}
