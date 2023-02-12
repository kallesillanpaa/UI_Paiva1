using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        panel.SetActive(!panel.activeInHierarchy);
    }


}
