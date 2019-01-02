using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shexian : MonoBehaviour
{
    public Camera ca; 
    private Ray ra;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ra = ca.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ra, out hit))
        {

        }
    }
}