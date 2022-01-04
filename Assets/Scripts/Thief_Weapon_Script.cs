using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief_Weapon_Script : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePEffect;

    void Start()
    {
        StartCoroutine(CountDownTime());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
