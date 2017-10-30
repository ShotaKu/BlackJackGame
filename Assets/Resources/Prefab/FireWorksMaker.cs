using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksMaker : MonoBehaviour {

    private Object FireWork1 = null;
    private Object FireWork2 = null;

    void Start()
    {
        FireWork1 = Resources.Load("Prefab/FireWorks1");
        FireWork2 = Resources.Load("Prefab/FireWorks2");
        //generateFireWorks();
    }
    public void generateFireWorks()
    {
        //Random rand = new Random();
        for (int i = 0; i <= 5; i++)
        {
            print("making fireworks " + i);
            int type = Random.Range(1, 3);
            Vector3 position = new Vector3(Random.Range(-400, 400), Random.Range(-90, 90),-10);
            GameObject field = null;
            if (type == 1)
                field = Instantiate(FireWork1, position, Quaternion.identity) as GameObject;
            else
                field = Instantiate(FireWork2, position, Quaternion.identity) as GameObject;

            field.transform.SetParent(transform, false);
            
        }
        
    }
    public void clearAll()
    {
        //Random rand = new Random();
        foreach(Transform f in transform)
        {
            Destroy(f.gameObject);
        }

    }
}
