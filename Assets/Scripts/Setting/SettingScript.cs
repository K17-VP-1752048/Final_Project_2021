using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    private void Start()
    {
        settingPanel.SetActive(false);
    }

    public void OpenSettingPanel()
    {
        if(settingPanel != null && settingPanel.activeInHierarchy == false)
        {
            settingPanel.SetActive(true);
        }
    }

    public void CloseSettingPanel()
    {
        if(settingPanel != null && settingPanel.activeInHierarchy)
        {
            settingPanel.SetActive(false);
        }
    }
}
