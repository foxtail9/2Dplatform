using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerinveninventory;

    public void Openinventory()
    {
        playerinveninventory.SetActive(true);
    }
}
