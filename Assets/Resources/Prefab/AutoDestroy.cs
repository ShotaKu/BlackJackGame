using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                print("Particle End");
                Destroy(transform.parent.gameObject);
            }
        }
    }
}