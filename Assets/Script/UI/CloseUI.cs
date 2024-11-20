using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject thisUI;
    public void UIClose()
    {
        thisUI.gameObject.SetActive(false);
    }
}
