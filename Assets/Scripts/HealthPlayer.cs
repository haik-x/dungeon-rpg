using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int startHealth;
    private int hp;
    public Slider healthScore;

    public GameObject diePEffect;

    void Start()
    {
        hp = startHealth;
    }

    public void Update()
    {
       healthScore.GetComponent<Slider>().value = hp;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        if (diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
