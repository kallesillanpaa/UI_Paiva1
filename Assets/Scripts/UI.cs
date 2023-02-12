using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button btnStart = root.Q<Button>("ButtonStart");
        Button btnStop = root.Q<Button>("ButtonStop");
        Button btnColor = root.Q<Button>("ButtonColor");

        btnStart.clicked += () => Debug.Log("Clicked Start");
        btnStop.clicked += () => Debug.Log("Clicked Stop");
        btnColor.clicked += () => ChangeColor();
    }


    void ChangeColor()
    {
        Debug.Log("Changing Color..");
        GameObject cube = GameObject.Find("Cube");
        cube.GetComponent<Renderer>().material.color = Color.red;
    }

}
