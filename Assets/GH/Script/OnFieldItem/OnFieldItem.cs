using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class OnFieldItem : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GetItem(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public abstract void GetItem(GameObject PlayerObject);
}
