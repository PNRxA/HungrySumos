using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: James
public class Indicator : MonoBehaviour
{
    public Spawner spawner;
    public Color indicatorColor;

    private MeshRenderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        Material mat = rend.material;
        mat.color = spawner.GetNextBallColor();
    }
}
