using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overflowBugFix : MonoBehaviour {

    [SerializeField]
    Text t;
	public void setHorizontalOverflowWrap()
    {
        t.horizontalOverflow = HorizontalWrapMode.Wrap;
    }
}
