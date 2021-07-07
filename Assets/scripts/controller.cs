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
    Sprite img;
    Image ObjectwithImage;
    public Sprite spriteToChangeItTo;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    int ryad;

    // Start is called before the first frame update
    void Start()
    {
        InitButtons();
    }

    public void Click()
    {
        int COUNT = 5;
        string name = EventSystem.current.currentSelectedGameObject.name;
        int i = GetNumber(name);
        Debug.Log(i + " clicked");
        ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
        ryad = (i-1)/6 + 1;
        if (ObjectwithImage.sprite == spr2)
        {
            for (int j = 0; j < i-1; j++)
            {
                COUNT++;
            }
            ObjectwithImage.sprite = spriteToChangeItTo;
            if  (i % 2 != 0)
                {
                for (int j = 0; j < 3; j++)
                {
                    ObjectwithImage = GameObject.Find($"GEX ({i + COUNT + j})").GetComponent<Image>();
                    ObjectwithImage.sprite = spr2;
                }
            }
            else 
            {
                for (int j = 0; j < 2; j++)
                {
                    ObjectwithImage = GameObject.Find($"GEX ({i + COUNT + j})").GetComponent<Image>();
                    ObjectwithImage.sprite = spr2;
                }
            }
        } Debug.Log(ryad);
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
