using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerEnter : MonoBehaviour
{
    private bool isTriggered = false;

    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        if (manager == null)
        {
            Debug.LogError("No manager");
        }
        Debug.Log("Start collisionvolume");
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            if (other != null)
            {
                var player = other.GetComponent<Player>();
                if (player != null)
                {
                    manager.DestroyPlayer(player);
                }
            }
            isTriggered = true;
        }
        else
        {
            Debug.Log("IS already triggered");
        }
    }
}
