using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemList : MonoBehaviour {
    static public List<GameObject> chels = new List<GameObject>();
    static public List<GameObject> shop = new List<GameObject>();
    static public List<GameObject> alco = new List<GameObject>();
    static public void refresh()
    {
        foreach (GameObject obj in itemList.chels)
        {
            obj.GetComponent<chelScript>().countC();
            obj.GetComponent<chelScript>().getState();
        }
    }
}
