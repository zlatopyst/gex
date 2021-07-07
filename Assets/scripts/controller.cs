using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public const int SIZE = 36;
    Button[] buttons;
    Image[] image; 
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        InitButtons();
    }

    public void Click()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        int i = GetNumber(name);
        Debug.Log(i + " clicked");
        Debug.Log("Image Name: " + img.name);
    }
    private void InitButtons()
    {
        buttons = new Button[SIZE];
        for (int i = 1; i < SIZE; i++)
            buttons[i] = 
                GameObject.Find($"GEX ({i})").GetComponent<Button>();
    }
    private int GetNumber(string name)
    {
        Regex regex = new Regex("\\((\\d+)\\)");
        Match match = regex.Match(name);
        if (!match.Success)
            throw new System.Exception("error");
        Group group = match.Groups[1];
        string number = group.Value;
        return Convert.ToInt32(number);
    }
}
