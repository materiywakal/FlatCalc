using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class chelScript : MonoBehaviour {

    public GameObject optionsPanel;
    public Text percent;
    public string name;
    public int height;
    public int weight;
    public bool isMale;
    double C;
    public void refreshName()
    {
        if (name != "")
            gameObject.GetComponentInChildren<Text>().text = name;
        else
            gameObject.GetComponentInChildren<Text>().text = "Имя человека";
    }
    public void optPanelSetActive()
    {
        optionsPanel.GetComponent<optPanelChel>().chel = gameObject;
        optionsPanel.gameObject.SetActive(true);
        optionsPanel.GetComponent<optPanelChel>().getComp();
    }
    public void getState()
    {
        if (C <= 0.5)
            percent.text = "Отсутствие влияния алкоголя";
        else if (C <= 1.5)
            percent.text = "Лёгкая степень опьянения";
        else if (C > 1.5 && C <= 2.0)
            percent.text = "Средняя степень опьянения";
        else if (C > 2.0 && C <= 3.0)
            percent.text = "Сильная степень опьянения";
        else if (C > 3 && C < 5.0)
            percent.text = "Тяжёлое отравление";
        else if (C >= 5)
            percent.text = "Смертельное отравление";
    }
    public void countC()
    {
        double V = 0, p = 0;
        C = 0;
        foreach(GameObject obj in itemList.alco)
        {
            V = obj.GetComponent<itemScript>().ml * obj.GetComponent<itemScript>().count / itemList.chels.Count;
            p = obj.GetComponent<itemScript>().percent;
            C += (V * (p / 100) * K()) / (weight * r());
        }
        Math.Round(C, 1);
    }
    public double K()
    {
        if (height >= 120 && height <= 140)
            return 1;
        else if (height > 140 && height <= 160)
            return 0.9;
        else if (height > 160 && height <= 180)
            return 0.8;
        else if (height > 180)
            return 0.75;
        return 0;
    }
    public double r()
    {
        if (isMale)
            return 0.7;
        else
            return 0.6;
    }
}
