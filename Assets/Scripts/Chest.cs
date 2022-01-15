using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int moneyAmount;
    public Text moneyText;


    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            moneyText.text = moneyAmount.ToString();

        }
    }
  
}
