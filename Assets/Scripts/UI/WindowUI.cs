using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUI : MonoBehaviour
{
    public GameObject myobject;
    public bool isActivate;
    public KeyCode keyBlind;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyBlind) && isActivate == false)
        {
            myobject.SetActive(true);
            isActivate = true;
        }
        else if (Input.GetKeyDown(keyBlind) && isActivate == true)
        {
            myobject.SetActive(false);
            isActivate = false;
        }
    }


}