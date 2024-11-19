using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseOptions : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;
    public void Close()
    {
        option.SetActive(false);
        menu.SetActive(true);
    }
}
