using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Collectable
{
    public Sprite doorMove1, doorMove2;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = doorMove1;
            GetComponent<SpriteRenderer>().sprite = doorMove2;
            //Debug.Log("You got " + moneyAmount + " coin");
        }
    }
}
