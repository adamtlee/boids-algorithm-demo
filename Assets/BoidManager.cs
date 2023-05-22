using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{

    public GameObject insectPrefab; 
    public int numInsect = 20; 
    public GameObject[] allInsect; 
    public Vector3 swarmLimits = new Vector3(5, 5, 5); 
    // Start is called before the first frame update
    void Start()
    {
        allInsect = new GameObject[numInsect]; 
        for (int i = 0; i < numInsect; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swarmLimits.x, swarmLimits.x),
                                                                  Random.Range(-swarmLimits.y, swarmLimits.y),
                                                                  Random.Range(-swarmLimits.z, swarmLimits.z));
            allInsect[i] = Instantiate(insectPrefab, pos, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
