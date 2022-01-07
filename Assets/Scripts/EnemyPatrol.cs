 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed, range, timeBwtShoot, shootSpeed;
    private float distPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask blockingLayer;
    public Collider2D bodyCollider;
    public Transform shootPos;
    public GameObject bullet;

    void Start()
    {
        mustPatrol = true;
        canShoot = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerF = GameObject.Find("Player");
        Transform player = playerF.transform;

        if (mustPatrol)
        {
            Patrol();
        }
        distPlayer = Vector2.Distance(transform.position, player.position);
        if(distPlayer<= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if (canShoot)
            StartCoroutine(Shoot());
        }
        else
        {
            mustPatrol = true;
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, blockingLayer);
        }
    }
    void Patrol()
    {
        if (bodyCollider.IsTouchingLayers(blockingLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
    IEnumerator Shoot()
    {
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        canShoot = false;

        yield return new WaitForSeconds(timeBwtShoot);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed*walkSpeed*Time.fixedDeltaTime,0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        canShoot = true;

    }
}
