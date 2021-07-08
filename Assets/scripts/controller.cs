using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public const int SIZE = 18;
    Button[] buttons;
    Image[] image; 
    Sprite img;
    Image ObjectwithImage;
    public Sprite spriteToChangeItTo;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public int Speed;
    private int value;
    Text CPS;
    Text Coins;


    // Start is called before the first frame update
    void Start()
    {
        InitButtons();
    }

    public void Click()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        int i = GetNumber(name);
        CPSplus(i, name);
        ifClicked(i,name);
        CoinsMinus(i, name);
    }
    private void ifClicked(int i, string name)
    {

        int COUNT = 5;
        //Debug.Log(i + " clicked");
        ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
        if (ObjectwithImage.sprite == spr2)
        {
            for (int j = 0; j < i - 1; j++)
            {
                COUNT++;
            }
            ObjectwithImage.sprite = spriteToChangeItTo;
            for (int j = 0; j < 3; j++)
            {
                if ((i + COUNT + j) <= SIZE) {
                ObjectwithImage = GameObject.Find($"GEX ({i + COUNT + j})").GetComponent<Image>();
                if (ObjectwithImage.sprite != spr1)
                {
                    ObjectwithImage.sprite = spr2;
                }
                }
            }
        }
    }
    private void CoinsMinus(int i, string name)
    {

    }
    private void CPSplus(int i, string name)
    {
        ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
        if (ObjectwithImage.sprite == spr2)
        {
            Debug.Log(i);
            CPS = GameObject.Find("CPS").GetComponent<Text>();
            value = Convert.ToInt32(GameObject.Find("Text"+i).GetComponent<Text>());
            CPS.text = "Coins per second " + Convert.ToString(value);
        }

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
