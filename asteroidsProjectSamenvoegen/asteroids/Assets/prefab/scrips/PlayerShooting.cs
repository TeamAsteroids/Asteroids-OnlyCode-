using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    public float coolDownTimer = 0;

    private void Update()
    {
        coolDownTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }else if (Input.GetButton("Fire2") && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay = 0.10f;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
