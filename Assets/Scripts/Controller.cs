using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: Peter
public class Controller : MonoBehaviour
{
    private float rotationZ = 0f;
    private Rigidbody rigid;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() // Monitor horizonal input keys and lock rotation to 45 degrees 
    {
        rotationZ += Input.GetAxis("Horizontal") * 10;
        rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        Vector3 eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
        Quaternion rotation = Quaternion.Euler(eulerAngles);
        rigid.MoveRotation(rotation);
    }

}
