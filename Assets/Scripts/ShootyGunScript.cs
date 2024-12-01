using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifetime = 3f;
    [SerializeField] private string floorTag = "Floor";
    [SerializeField] private string enemyTag = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse button release
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Transform cameraTransform = Camera.main.transform;
        GameObject newBullet = Instantiate(bulletPrefab, cameraTransform.position, cameraTransform.rotation);
        newBullet.SetActive(true);

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.velocity = cameraTransform.forward * bulletSpeed;

        Destroy(newBullet, bulletLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemyTag
        || collision.gameObject.tag == floorTag)
        {
            Destroy(gameObject);
        }
    }
}
