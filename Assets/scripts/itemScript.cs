using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour {
    public GameObject optionsPanel;
    public Text price;
    public string name;
    public bool isAlco;
    public double ml;
    public double percent;
    public double cost;
    public double count;

    public void CreatePrice()
    {
        price.text = Convert.ToString(cost * count);
    }
    public void refreshName()
    {
        if (name != "")
            gameObject.GetComponentInChildren<Text>().text = name;
        else
            gameObject.GetComponentInChildren<Text>().text = "Имя товара";
    }
    public void optPanelSetActive()
    {
        optionsPanel.gameObject.SetActive(true);
        if (optionsPanel.name == "optionsPanel3")
        {
            optionsPanel.GetComponent<optPanelShop>().item = gameObject;
            optionsPanel.GetComponent<optPanelShop>().getComp();
        }
        else
        {
            optionsPanel.GetComponent<optPanelItem>().item = gameObject;
            optionsPanel.GetComponent<optPanelItem>().getComp();  
        }
    }
}
