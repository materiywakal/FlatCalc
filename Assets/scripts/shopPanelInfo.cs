using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopPanelInfo : MonoBehaviour {

    public Text sumValue;
    public Text sumForAllValue;
	public void close()
    {
        gameObject.SetActive(false);
    }
    public void activate()
    {
        gameObject.SetActive(true);
    }
    public void changeValues()
    {
        double price = 0;
        for (int i = 0; i < itemList.shop.Count; i++)
            price += double.Parse(itemList.shop[i].GetComponent<itemScript>().price.text);
        sumValue.text = price.ToString();
        if (itemList.chels.Count != 0)
            sumForAllValue.text = (price / itemList.chels.Count).ToString();
        else
            sumForAllValue.text = sumValue.text;
    }
}
