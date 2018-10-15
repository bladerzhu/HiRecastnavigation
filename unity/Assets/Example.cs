/***************************************************************
 * Description: This used to export obj file
 * Document: https://github.com/hiramtan/HiRecastnavigation
 * Author: hiramtan@live.com
 ****************************************************************************/

using UnityEngine;

public class Example : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {

        var test = HiRecastnavigation.Navigation.TestCsharpCallC(3, 4);

        Debug.LogError(test);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
