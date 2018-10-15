using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour
{
    [DllImport("HiRecastnavigation")]
    private static extern int MyADD(int x, int y);
   
    // Use this for initialization
    void Start()
    {
        int i = MyADD(9, 9);
        Debug.LogError(i);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
