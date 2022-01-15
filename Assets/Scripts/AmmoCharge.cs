using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCharge : MonoBehaviour
{
    public int ammoToAdd;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGO = col.gameObject;
        if (colGO.tag == "Player")
        {
            colGO.GetComponent<Shooting>().UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
    }
}
