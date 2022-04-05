using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSettings : MonoBehaviour
{
    public void clickButton()
    {
        ScenesManager.instance.ToSettingsScene();
    }
    public void clickButtonGameScene()
    {
        ScenesManager.instance.ToTutorialScene();
    }
    public void clickButtonQuit()
    {
        ScenesManager.instance.Quit();
    }

}
