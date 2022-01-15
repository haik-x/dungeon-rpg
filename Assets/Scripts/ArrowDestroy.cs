using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float dieTime;
    public int damage;
    public GameObject diePEffect;

    void Start()
    {
        StartCoroutine(Timer());
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name != "Player")
        {
            if (collisionGameObject.GetComponent<HealthEnemy>() != null)
            {
                collisionGameObject.GetComponent<HealthEnemy>().TakeDamage(damage);
            }
            Die();
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
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
