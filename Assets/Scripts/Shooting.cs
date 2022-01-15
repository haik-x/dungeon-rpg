using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject arrow;
    public Transform shootPos;
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public int maxAmmo;
    private int currentAmmo;
    public Text ammoText;

    void Start()
    {
        currentAmmo = 0;
        isShooting = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting && currentAmmo>0)
        {
            StartCoroutine(Shoot());
            /*currentAmmo--;
            ammoText.text = currentAmmo.ToString();*/
            UpdateAmmo(-1);
        }
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
        isShooting = true;
        GameObject newBullet = Instantiate(arrow, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    public void UpdateAmmo(int ammo)
    {
        currentAmmo += ammo;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        ammoText.text = currentAmmo.ToString();
    }
}
