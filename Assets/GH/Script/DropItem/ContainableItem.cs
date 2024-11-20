using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class ContainableItem : ScriptableObject
{
    public int ContainableItemNum;
    public string ItemName;
    public string ItemExplanation;
    public Sprite IconSprite;
    abstract public void GetItem(GameObject playerObject);
}
