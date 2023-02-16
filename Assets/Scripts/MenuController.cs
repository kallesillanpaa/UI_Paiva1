using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{

    UIDocument doc;
    Button playButton, settingsButton, exitButton, backButton;

    VisualElement buttons; //parent of play, settings, quit -buttons

    [SerializeField]VisualTreeAsset settingsButtonTemplate; //tree of visual element assets, made from UXML-file

    VisualElement settingsButtons; //parent of settings -buttons


    private void Awake()
    {

        doc = GetComponent<UIDocument>(); 
        playButton = doc.rootVisualElement.Q<Button>("PlayButton"); //rootVisualElement = UI layout's "root" visual element 
                                                //Q<Type to search>("Name of element") //Q=Query
        settingsButton = doc.rootVisualElement.Q<Button>("SettingsButton");
        exitButton = doc.rootVisualElement.Q<Button>("ExitButton");

        playButton.clicked+= ()=> Debug.Log("play button clicked"); // anonymous function (lambda) used here, since simple debug call only
        playButton.clicked += PlayButtonOnClicked; //add function to button click-event, possible to add many functions (like here)
                                                   //or also remove functions with -=

    //NOTE: .clicked works with buttons. However, if some other than button is clicked, possible to register/unregister event callbacks:
    // https://docs.unity.cn/ru/2020.1/Manual/UIE-Events-Handling.html


        exitButton.clicked += ExitButtonOnClicked;
        
        settingsButton.clicked += SettingsButtonOnClicked;        
        buttons = doc.rootVisualElement.Q<VisualElement>("Buttons");

        settingsButtons = settingsButtonTemplate.CloneTree(); //returns the root of the created visual elements tree

        backButton = settingsButtons.Q<Button>("BackButton"); //NOTICE! settingsButtons here instead of rootVisualElement, since we're 
                                                            // searching button from the settingsButtons
        backButton.clicked += BackButtonOnClicked;
    }

    void PlayButtonOnClicked()
    {
        Debug.Log("Clicked play..");
    }

    void ExitButtonOnClicked()
    {
    #if UNITY_EDITOR //if program is launched from Unity
            UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER //if program is launched from browser
             Application.OpenURL(webplayerQuitURL);
    #else   //normal quitting, as f.ex in standalone build
             Application.Quit();
    #endif
    }

    void SettingsButtonOnClicked()
    {
        buttons.Clear(); //removes all child elements of buttons
        buttons.Add(settingsButtons); //adds settingsButtons-visual element
    }

    void BackButtonOnClicked()
    {
        buttons.Clear();
        buttons.Add(playButton);        
        buttons.Add(settingsButton);
        buttons.Add(exitButton);
    }
}
