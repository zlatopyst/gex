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
    Text[] buttons;
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
        restart();
        InitButtons();
        StartCoroutine(Count());
    }

    public IEnumerator Count()
    {
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
        ObjectwithImage = GameObject.Find(name).GetComponent<Image>();
        if ((ObjectwithImage.sprite == spr2) && (Convert.ToInt32(buttons[i].text) <= count))
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
                if (image[SIZE].sprite != spr1)
                {
                    image[SIZE].sprite = spr2;
                    buttons[SIZE].text = Convert.ToString(prices);
                    buttons[SIZE].color = new Color(202, 255, 0);
                }
            }
            for (int j = 0; j < 3; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i + COUNT + j) <= SIZE)
                {
                    if (image[i + COUNT + j].sprite != spr1)
                    {
                        image[i + COUNT + j].sprite = spr2;
                        buttons[i+COUNT+j].text = Convert.ToString(prices);
                        buttons[i+COUNT+j].color = new Color(202, 255, 0);
                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i + 1) <= SIZE && i != 6)
                {
                    if (image[i+1].sprite != spr1)
                    {
                        image[i+1].sprite = spr2;
                        buttons[i+1].text = Convert.ToString(prices);
                        buttons[i+1].color = new Color(202, 255, 0);
                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                int prices = Random.Range(10, 30);
                if ((i - 1) <= SIZE)
                {
                    if (image[i-1].sprite != spr1)
                    {
                        image[i-1].sprite = spr2;
                        buttons[i-1].text = Convert.ToString(prices);
                        buttons[i-1].color = new Color(202, 255, 0);
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
                //Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
                count = count - Convert.ToInt32(buttons[i].text);
                CPS.text = "Coins: " + Convert.ToString(count);
                int prices = Random.Range(1, 5);
                buttons[i].text = Convert.ToString(prices);
                buttons[i].color = new Color(0, 0, 0);

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
            value = value + Convert.ToInt32(buttons[i].text);
            CPS.text = "Coins per second: " + Convert.ToString(value);
        }

    }
    private void InitButtons()
    {
        buttons = new Text[SIZE+1];
        image = new Image[SIZE+1];
        for (int i = 0; i <= SIZE; i++)
        {
            image[i] =
                GameObject.Find($"GEX ({i})").GetComponent<Image>();
            buttons[i] =
                    GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
        }

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
    public void restart()
    {
        value = 1;
        count = 0;
        CPS = GameObject.Find("CPS").GetComponent<Text>();
        CPS.text = "Coins per second: " + Convert.ToString(value);
        for (int i = 1; i < 7; i++)
        {
            ObjectwithImage = GameObject.Find($"GEX ({i})").GetComponent<Image>();
            Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
            ObjectwithImage.sprite = spr2;
            Coins.text = Convert.ToString(20);
            Coins.color = new Color(202, 255, 0);
        }
        for (int i = 7; i < 19; i++)
        {
            ObjectwithImage = GameObject.Find($"GEX ({i})").GetComponent<Image>();
            Coins = GameObject.Find($"GEX ({i})").GetComponentInChildren<Text>();
            ObjectwithImage.sprite = spr3;
            Coins.text = Convert.ToString("");
        }
    }
}
