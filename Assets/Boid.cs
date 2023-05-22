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
        ApplyRules();
        this.transform.Translate(0,0, speed * Time.deltaTime);
    }

    void ApplyRules()
    {
        GameObject[] gos; 
        gos = BoidManager.BM.allInsect;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero; 
        float gSpeed = 0.01f; 
        float nDistance; 
        int groupSize = 0; 

        foreach(GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= BoidManager.BM.neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++; 

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position); 
                    }

                    Boid anotherBoid = go.GetComponent<Boid>();
                    gSpeed = gSpeed + anotherBoid.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vcenter = vcenter/groupSize; 
            speed = gSpeed / groupSize; 

            Vector3 direction = (vcenter + vavoid) - transform.position; 
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                        Quaternion.LookRotation(direction),
                                                        BoidManager.BM.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
