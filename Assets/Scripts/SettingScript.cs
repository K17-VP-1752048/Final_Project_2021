using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    public void OpenSettingPanel()
    {
        if(settingPanel != null)
        {
            settingPanel.SetActive(true);
        }
    }

    public void CloseSettingPanel()
    {
        if(settingPanel != null)
        {
            settingPanel.SetActive(false);
        }
    }
}
