using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPrompt : MonoBehaviour {

    public GameObject IDPrompt;
    public GameObject PWPrompt;
    public GameObject RepPrompt;

    
    void Start () {
        IDPrompt.SetActive(false);
        PWPrompt.SetActive(false);
        RepPrompt.SetActive(false);
    }
    public void IDPromptShow()
    {
        IDPrompt.SetActive(true);
    }
    public void PWPromptShow()
    {
        PWPrompt.SetActive(true);
    }
    public void IDPromptHide()
    {
        IDPrompt.SetActive(false);
    }
    public void PWPromptHide()
    {
        PWPrompt.SetActive(false);
    }
    public void RepPromptShow()
    {
        RepPrompt.SetActive(true);
    }
    public void RepPromptHide()
    {
        RepPrompt.SetActive(false);
    }
   
}
