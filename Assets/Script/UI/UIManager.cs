using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject playerinveninventory;
    public GameObject showmenu;

    public void Openinventory()
    {
        playerinveninventory.SetActive(true);
    }

    public void Openmenu()
    {
        showmenu.SetActive(true);
    }
}
