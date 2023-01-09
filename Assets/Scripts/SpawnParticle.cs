using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Find children");

        // var children = GetComponentsInChildren<Transform>();
        // if (children != null)
        // {
        //     Debug.Log(children.Length);
        //     var particles = children[0];
        //     foreach (var child in children)
        //     {
        //         if (child.CompareTag("Particle"))
        //         {
        //             Debug.Log("Found particletag");
        //             var particle = child.GetComponent<ParticleSystem>();
        //             Debug.Log(child.gameObject.name);
        //             particle.Play();
        //         }
        //     }
        // }
    }

    // Update is called once per frame
    void Update() { }

    public void ParticleSpawn()
    {
        Debug.Log("Find children");

        var children = GetComponentsInChildren<Transform>();
        if (children != null)
        {
            Debug.Log(children.Length);
            var particles = children[0];
            foreach (var child in children)
            {
                if (child.CompareTag("Particle"))
                {
                    Debug.Log("Found particletag");
                    var particle = child.GetComponent<ParticleSystem>();
                    Debug.Log(child.gameObject.name);
                    particle.Play();
                }
            }
        }
    }
}
