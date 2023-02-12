using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    //1
    UIDocument doc;
    Button playButton, settingsButton, exitButton, muteButton;

    //4
    Button backButton;

    //2
    VisualElement buttons;

    //3
    [SerializeField]
    VisualTreeAsset settingsButtonTemplate; 
    VisualElement settingsButtons; //Create based on the file above


    private void Awake()
    {
        //1
        doc = GetComponent<UIDocument>();
        playButton = doc.rootVisualElement.Q<Button>("PlayButton");
        settingsButton = doc.rootVisualElement.Q<Button>("SettingsButton");
        exitButton = doc.rootVisualElement.Q<Button>("ExitButton");
        muteButton = doc.rootVisualElement.Q<Button>("MuteButton");

        //playButton.clicked+= ()=> Debug.Log("play button clicked");
        playButton.clicked += PlayButtonOnClicked;
        exitButton.clicked += () => UnityEditor.EditorApplication.isPlaying = false;  //Application.Quit();
        
        //2
        settingsButton.clicked += SettingsButtonOnClicked;        
        buttons = doc.rootVisualElement.Q<VisualElement>("Buttons");

        //3
        settingsButtons = settingsButtonTemplate.CloneTree();
        //4
        backButton = settingsButtons.Q<Button>("BackButton"); //huom. settingsButtons, ei doc
        backButton.clicked += BackButtonOnClicked;
    }

    void PlayButtonOnClicked()
    {
        //1
        Debug.Log("Clicked play..");
    }

    void ExitButtonOnClicked()
    {
        //1
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER
             Application.OpenURL(webplayerQuitURL);
    #else
             Application.Quit();
    #endif
    }

    void SettingsButtonOnClicked()
    {
        //2
        buttons.Clear();
        //3
        buttons.Add(settingsButtons);
    }

    void BackButtonOnClicked()
    {
        //4
        buttons.Clear();
        buttons.Add(playButton);        
        buttons.Add(settingsButton);
        buttons.Add(exitButton);
    }
}
