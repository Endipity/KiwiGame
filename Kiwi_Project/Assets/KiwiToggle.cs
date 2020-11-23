using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiToggle : MonoBehaviour
{
    GameObject V4, V2;
    bool Run = true;
    void Start()
    {
        V4 = GameObject.FindGameObjectWithTag("V4group");
        V2 = GameObject.FindGameObjectWithTag("V2group");
        V4.SetActive(!V4.activeInHierarchy);
        //hide v4 at start
        /*
        var objectsV4 = GameObject.FindGameObjectsWithTag("V4group");
        var objectsV2 = GameObject.FindGameObjectsWithTag("V2group");
        foreach (var obj in objectsV4)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
        */
    }

    public void ToggleVisOn()
    {
        V2.SetActive(false);
        V4.SetActive(true);
   
        
        /*
        //disable/enable v2
        foreach (var obj in objectsV2)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
        //disable/enable v4
        foreach (var obj in objectsV4)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
        */

    }
    public void ToggleVisOff()
    {
        V2.SetActive(true);
        V4.SetActive(false);


        /*
        //disable/enable v2
        foreach (var obj in objectsV2)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
        //disable/enable v4
        foreach (var obj in objectsV4)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
        */

    }
}



