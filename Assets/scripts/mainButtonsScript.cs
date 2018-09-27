using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainButtonsScript : MonoBehaviour {

    public GameObject UpPanel;

    public Text nameOfPanel;
    public GameObject invChel;
    public GameObject calcItem;
    public GameObject moreInfo;
    public GameObject calcChel;
    public void activateInvChel()
    {
        
        if (invChel.active == false)
        {
            Deactivate();
            invChel.SetActive(true);
            nameOfPanel.text = "Участники";
            UpPanel.GetComponent<UpPanelScript>().GetCountOfPerson();
        }
    }
    public void activateCalcItem()
    {
        if (calcItem.active == false)
        {
            Deactivate();
            calcItem.SetActive(true);
            moreInfo.SetActive(true);
            nameOfPanel.text = "Расчет продукции";
            UpPanel.GetComponent<UpPanelScript>().GetPrice();
        }
    }
    public void activateCalcChel()
    {
        if (calcChel.active == false)
        {
            Deactivate();
            calcChel.SetActive(true);
            nameOfPanel.text = "Алконайзер";
            UpPanel.GetComponent<UpPanelScript>().GetCountOfAlco();
        }
    }
	public void Deactivate()
    {
        invChel.SetActive(false);
        calcItem.SetActive(false);
        moreInfo.SetActive(false);
        calcChel.SetActive(false);
    }
}
