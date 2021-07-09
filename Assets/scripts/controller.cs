using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    private int value = 1;
    private int count;
    Text CPS;
    Text Coins;


    // Start is called before the first frame update
    void Start()
    {
        InitButtons();
        StartCoroutine(Count());
    }

    public IEnumerator Count()
    {
        int x = 0;
        while (count < 10000)
        {
            count = count + value;
            GameObject.Find("Coins").GetComponent<Text>().text = "Coins: " + count.ToString();
            yield return new WaitForSeconds(1);
        }
    }
    public void Click()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        int i = GetNumber(name);
        Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
        if (Convert.ToInt32(Coins.text) <= count)
        {
            CoinsMinus(i, name);
            ifClicked(i, name);
            CPSplus(i, name);
        }
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
            if (i == 1 || i == 17)
            {
                int prices = Random.Range(10, 30);
                CPS = GameObject.Find($"GEX ({SIZE})").GetComponentInChildren<Text>();
                ObjectwithImage = GameObject.Find($"GEX ({SIZE})").GetComponent<Image>();
                if (ObjectwithImage.sprite != spr1)
                {
                    ObjectwithImage.sprite = spr2;
                    CPS.text = Convert.ToString(prices);
                    CPS.color = new Color(202, 255, 0);
                }
            }
            for (int j = 0; j < 3; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i + COUNT + j) <= SIZE)
                {
                    CPS = GameObject.Find($"GEX ({i + COUNT + j})").GetComponentInChildren<Text>();
                    ObjectwithImage = GameObject.Find($"GEX ({i + COUNT + j})").GetComponent<Image>();
                    if (ObjectwithImage.sprite != spr1)
                    {
                        ObjectwithImage.sprite = spr2;
                        CPS.text = Convert.ToString(prices);
                        CPS.color = new Color(202, 255, 0);
                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i + 1) <= SIZE && i != 6)
                {
                    CPS = GameObject.Find($"GEX ({i + 1})").GetComponentInChildren<Text>();
                    ObjectwithImage = GameObject.Find($"GEX ({i + 1})").GetComponent<Image>();
                    if (ObjectwithImage.sprite != spr1)
                    {
                        ObjectwithImage.sprite = spr2;
                        CPS.text = Convert.ToString(prices);
                        CPS.color = new Color(202, 255, 0);
                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i - 1) >= SIZE)
                {
                    CPS = GameObject.Find($"GEX ({i - 1})").GetComponentInChildren<Text>();
                    ObjectwithImage = GameObject.Find($"GEX ({i - 1})").GetComponent<Image>();
                    if (ObjectwithImage.sprite != spr1)
                    {
                        ObjectwithImage.sprite = spr2;
                        CPS.text = Convert.ToString(prices);
                        CPS.color = new Color(202, 255, 0);
                    }
                }
            }

        }
    }
    private void CoinsMinus(int i, string name)
    {
        {
            ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
            if (ObjectwithImage.sprite == spr2)
            {
               // Debug.Log(i);
                CPS = GameObject.Find("Coins").GetComponent<Text>();
                Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
                count = count - Convert.ToInt32(Coins.text);
                CPS.text = "Coins: " + Convert.ToString(count);
                int prices = Random.Range(1, 5);
                Coins.text = Convert.ToString(prices);
                Coins.color = new Color(0, 0, 0);

            }

        }
    }
    private void CPSplus(int i, string name)
    {
        ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
        if (ObjectwithImage.sprite == spr1)
        {
            //Debug.Log(i);
            CPS = GameObject.Find("CPS").GetComponent<Text>();
            //Debug.Log(CPS);
            Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
            value = value + Convert.ToInt32(Coins.text);
            CPS.text = "Coins per second: " + Convert.ToString(value);
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
