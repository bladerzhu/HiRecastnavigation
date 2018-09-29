using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour
{
    [DllImport("HiRecastnavigation")]
    private static extern int MyADD(int x, int y);
    int i = MyADD(5, 7);
    // Use this for initialization
    void Start()
    {
        Debug.LogError(i);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
