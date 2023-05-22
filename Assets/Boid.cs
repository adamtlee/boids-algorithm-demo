using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    float speed; 
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(BoidManager.BM.minSpeed, BoidManager.BM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0, speed * Time.deltaTime);
    }
}
