using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class optPanelChel : MonoBehaviour {

    public GameObject chel;
    public InputField name;
    public InputField height;
    public InputField weight;
    public Toggle male;
    public Toggle female;
    public void getComp()
    {
        name.text = chel.GetComponent<chelScript>().name;
        if (chel.GetComponent<chelScript>().height >100 && chel.GetComponent<chelScript>().height < 300)
            height.text = chel.GetComponent<chelScript>().height.ToString();
        if (chel.GetComponent<chelScript>().weight != 0)
            weight.text = chel.GetComponent<chelScript>().weight.ToString();
        male.isOn = chel.GetComponent<chelScript>().isMale;
    }
    public void Save()
    {
        if (name.text != "" && height.text != "" && weight.text != "")
            saveMoves();
    }
    public void saveMoves()
    {
        chel.GetComponent<chelScript>().name = name.GetComponentInChildren<Text>().text;
        if (height.GetComponentInChildren<Text>().text != "")
            chel.GetComponent<chelScript>().height = Int32.Parse(height.GetComponentInChildren<Text>().text);
        else
            chel.GetComponent<chelScript>().height = 0;
        if (weight.GetComponentInChildren<Text>().text != "")
            chel.GetComponent<chelScript>().weight = Int32.Parse(weight.GetComponentInChildren<Text>().text);
        else
            chel.GetComponent<chelScript>().weight = 0;
        if (male.isOn)
            chel.GetComponent<chelScript>().isMale = true;
        else
            chel.GetComponent<chelScript>().isMale = false;
        Cancel();
    }
    public void Cancel()
    {
        itemList.refresh();
        name.text = "";
        height.text = "";
        weight.text = "";
        male.isOn = true;
        chel.GetComponent<chelScript>().refreshName();
        chel = null;
        gameObject.SetActive(false);
    }
    public void Delete()
    {
        itemList.chels.Remove(chel);
        Destroy(chel);
        Cancel();
    }
    public void lessThen30()
    {
        if (name.text.Length > 30)
        {
            name.text = "";
            name.placeholder.GetComponent<Text>().text = "Имя < 30 символов";
        }
    }
    public bool checkExisted(string t)
    {
        for (int i = 0; i < itemList.chels.Count; i++)
        {
            if (itemList.chels[i].GetComponent<chelScript>().name == t && itemList.chels[i] != chel)
            {
                return false;
            }
        }
        return true;
    }
    public void toggleMale()
    {
        if (male.isOn)
            female.isOn = false;
        else
            female.isOn = true;
    }
    public void toggleFemale()
    {
        if (female.isOn)
            male.isOn = false;
        else
            male.isOn = true;
    }
    public void checkHeight()
    {
        try
        {
            Int32.Parse(height.text);
        }
        catch
        {
            height.text = "";
            return;
        }
        if (Int32.Parse(height.text) > 300 || Int32.Parse(height.text) < 100)
            height.text = "";
    }
    public void checkWeight()
    {
        try
        {
            Int32.Parse(weight.text);
        }
        catch
        {
            weight.text = "";
            return;
        }
        if (Int32.Parse(weight.text) > 1000 || Int32.Parse(weight.text) < 0)
            weight.text = "";
    }
}
