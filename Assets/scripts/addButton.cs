using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class addButton : MonoBehaviour
{
    [SerializeField]
    GameObject good;
    [SerializeField]
    GameObject optionsPanel;
    public void addGood()
    {
        bool temp = true;
        int ind = 0;
        List<GameObject> t = null;
        if (optionsPanel.name == "optionsPanel2")
        {
            t = itemList.chels;
            ind = 2;
        }
        else if (optionsPanel.name == "optionsPanel3")
        {
            t = itemList.shop;
            ind = 1;
        }
        else if (optionsPanel.name == "optionsPanel4")
        {
            t = itemList.alco;
            ind = 3;
        }
        foreach (GameObject gameobj in t)
        {
            if (ind == 1 || ind == 3)
                if (gameobj.GetComponent<itemScript>().name == "")
                {
                    temp = false;
                    break;
                }
            if (ind == 2)
                if (gameobj.GetComponent<chelScript>().name == "")
                {
                    temp = false;
                    break;
                }
        }
        if (temp)
        {
            GameObject g = Instantiate(good, gameObject.transform.parent);
            t.Add(g);
            g.transform.SetSiblingIndex(g.transform.GetSiblingIndex() - 1);
            if (ind == 1 || ind == 3)
            {
                g.GetComponent<Button>().onClick.AddListener(g.GetComponent<itemScript>().optPanelSetActive);
                g.GetComponent<itemScript>().optionsPanel = optionsPanel;
            }
            if (ind == 2)
            {
                g.GetComponent<Button>().onClick.AddListener(g.GetComponent<chelScript>().optPanelSetActive);
                g.GetComponent<chelScript>().optionsPanel = optionsPanel;
            }
        }
    }
}