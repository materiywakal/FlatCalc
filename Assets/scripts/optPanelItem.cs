using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class optPanelItem : MonoBehaviour
{
    public GameObject item;
    public InputField name;
    public InputField ml;
    public InputField percent;
    public InputField count;
    public GameObject save;
    public GameObject cancel;
    public GameObject panel;
    public void getComp()
    {
        name.text = item.GetComponent<itemScript>().name;
        if (item.GetComponent<itemScript>().ml != 0)
            ml.text = item.GetComponent<itemScript>().ml.ToString();
        if (item.GetComponent<itemScript>().percent != 0)
            percent.text = item.GetComponent<itemScript>().percent.ToString();
        if (item.GetComponent<itemScript>().count != 0)
            count.text = item.GetComponent<itemScript>().count.ToString();
    }
    public void Save()
    {
        if (name.text != "" && checkExisted(name.text))
            if (ml.text != "" && percent.text != "")
            {
                saveMoves();
                Cancel();
            }
    }
    private void saveMoves()
    {
        item.GetComponent<itemScript>().name = name.text;
        if (ml.text != "")
            item.GetComponent<itemScript>().ml = double.Parse(ml.text);
        else
            item.GetComponent<itemScript>().ml = 0;
        if (percent.text != "")
            item.GetComponent<itemScript>().percent = double.Parse(percent.text);
        else
            item.GetComponent<itemScript>().percent = 0;
        if (count.text != "")
            item.GetComponent<itemScript>().count = double.Parse(count.text);
        else
            item.GetComponent<itemScript>().count = 0;
        foreach (GameObject obj in itemList.chels)
            obj.GetComponent<chelScript>().countC();
    }
    public void Cancel()
    {
        itemList.refresh();
        name.text = "";
        ml.text = "";
        percent.text = "";
        count.text = "";
        name.placeholder.GetComponent<Text>().text = "Название";
        item.GetComponent<itemScript>().refreshName();
        item = null;
        gameObject.SetActive(false);
    }
    public void Delete()
    {
        itemList.alco.Remove(item);
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
        for (int i = 0; i < itemList.alco.Count; i++)
            if (itemList.alco[i].GetComponent<itemScript>().name == t && itemList.alco[i] != item)
                return false;
        return true;
    }
    public void checkMlField()
    {
        try
        {
            double.Parse(ml.text);
        }
        catch
        {
            ml.text = "";
            return;
        }
        if (double.Parse(ml.text) < 0 || double.Parse(ml.text) > 50000)
            ml.text = "";
    }
    public void checkPercentField()
    {
        try
        {
            double.Parse(percent.text);
        }
        catch
        {
            percent.text = "";
            return;
        }
        if (double.Parse(percent.text) > 100 || double.Parse(percent.text) < 0)
            percent.text = "";
    }
    public void checkCountField()
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
        if (double.Parse(count.text) > 10000 || double.Parse(count.text) < 0)
            count.text = "";
    }
}

