using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimYScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float yRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yRotation = Mathf.Clamp(yRotation - Input.GetAxis("Mouse Y") * rotationSpeed, -90, 90);
        transform.rotation = Quaternion.Euler(yRotation, transform.rotation.eulerAngles.y, 0);

    }
}