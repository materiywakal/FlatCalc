using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UpPanelScript : MonoBehaviour
{
    public Text Info;
    double price = 0;
    int countOfPerson = 0;
    int countOfItems = 0;
    int countOfAlco = 0;
    public void GetPrice()
    {
        price = 0;
        for (int i = 0; i < itemList.shop.Count; i++)
            price += double.Parse(itemList.shop[i].GetComponent<itemScript>().price.text);
        Info.text = "Стоимость: " + priceCut();
    }
    public string priceCut()
    {
        string output = price.ToString();
        if (output.Length > 3)
        {
            output = output.Remove(3, output.Length - 3);
            output += "...";
        }
        return output;
    }
    public void GetCountOfPerson()
    {
        countOfPerson = itemList.chels.Count;
        Info.text = "Участников: " + countOfPerson.ToString();
    }
    public void GetCountOfAlco()
    {
        countOfAlco = itemList.alco.Count;
        Info.text = "Алкоголя: " + countOfAlco.ToString();
    }
}
