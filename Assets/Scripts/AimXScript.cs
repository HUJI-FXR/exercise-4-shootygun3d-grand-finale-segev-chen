using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimXScript : MonoBehaviour
{
    // rotate the object to face the mouse cursor
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float xRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, xRotation, 0);

    }
}