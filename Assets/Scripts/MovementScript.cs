using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] public Vector3 direction;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private string floorTag = "Floor";
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * direction * speed + GetComponent<Rigidbody>().velocity.y * Vector3.up;
    }
    public void jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == floorTag){isGrounded = true;}
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == floorTag){isGrounded = false;}
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == floorTag){isGrounded = true;}
    }
}