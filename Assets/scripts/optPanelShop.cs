using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class optPanelShop : MonoBehaviour {

    public GameObject item;
    public InputField name;
    public InputField count;
    public InputField cost;

    public GameObject save;
    public GameObject cancel;

    public void getComp()
    {
        name.text = item.GetComponent<itemScript>().name;
        if (item.GetComponent<itemScript>().count != 0)
            count.text = item.GetComponent<itemScript>().count.ToString();
        if (item.GetComponent<itemScript>().cost != 0)
            cost.text = item.GetComponent<itemScript>().cost.ToString();
    }
    public void Save()
    {
        if (name.text != "" && checkExisted(name.text) && count.text != "" && cost.text != "")
        {
            saveMoves();
            Cancel();
        }
    }
    private void saveMoves()
    {
        item.GetComponent<itemScript>().name = name.text;
        if (count.text != "")
            item.GetComponent<itemScript>().count = double.Parse(count.text);
        else
            item.GetComponent<itemScript>().count = 0;
        if (cost.text != "")
            item.GetComponent<itemScript>().cost = double.Parse(cost.text);
        else
            item.GetComponent<itemScript>().cost = 0;

        item.GetComponent<itemScript>().CreatePrice();
    }
    public void Cancel()
    {
        name.text = "";
        count.text = "";
        cost.text = "";
        name.placeholder.GetComponent<Text>().text = "Название";
        item.GetComponent<itemScript>().refreshName();
        item = null;
        gameObject.SetActive(false);
    }
    public void Delete()
    {
        itemList.shop.Remove(item);
        Destroy(item);
        Cancel();
    }
    public void lessThen30()
    {
        if (name.text.Length > 30)
        {
            name.text = "";
            name.placeholder.GetComponent<Text>().text = "Название < 30 символов";
        }
    }
    public bool checkExisted(string t)
    {
        for (int i = 0; i < itemList.shop.Count; i++)
        {
            if (itemList.shop[i].GetComponent<itemScript>().name == t && itemList.shop[i] != item)
            {
                return false;
            }
        }
        return true;
    }
    public void checkcountField()
    {
        try
        {
            double.Parse(count.text);
        }
        catch
        {
            count.text = "";
            return;
        }
        if (double.Parse(count.text) < 0 || double.Parse(count.text) > 5000)
            count.text = "";
    }
    public void checkcostField()
    {
        try
        {
            double.Parse(cost.text);
        }
        catch
        {
            cost.text = "";
            return;
        }
        if (double.Parse(cost.text) < 0 || double.Parse(cost.text) > 99999999999)
            cost.text = "";
    }
}
