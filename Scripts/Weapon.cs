using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public static float bulletAmount = 50;
    public Image barImage;
    private float firstBulletAmount;
    void Start()
    {
        barImage = GameObject.Find("Container/Bar").GetComponent<Image>();
        firstBulletAmount = 50f;
        bulletAmount = 50f;
    }
    void Update()
    {
        if (GameObject.Find("Gun").activeSelf)
        {
            if (bulletAmount > 2)
            {
                if ((Input.GetButton("Fire1")) && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else if (bulletAmount > 1)
            {
                if ((Input.GetButton("Fire1")) && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
        }
        barImage.fillAmount = bulletAmount / firstBulletAmount;
    }
    void Shoot()
    {
        if (!(DialogueManager.dialogueIsActive))
        {
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletAmount--;
        }
    }
}
