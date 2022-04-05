using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public void clickButton()
    {
        ScenesManager.instance.ToMenuScene();
    }
}
