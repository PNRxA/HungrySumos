using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: James
public class BallRayScript : MonoBehaviour
{
    RaycastHit hitPoint;
    Rigidbody rigi;
    public GameManager gameManager;
    private float stoppingDist = 1;
    


    // Use this for initialization
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.debug)
        {
            Debug.DrawRay(rigi.transform.position, -Vector3.up, Color.red, stoppingDist);

            if (Physics.Raycast(rigi.transform.position, -Vector3.up, out hitPoint, stoppingDist))
            {
                if (hitPoint.transform.GetComponent<BoxCollider>())
                {
                    print(hitPoint.transform.name);
                }
            }
        }
    }


}
