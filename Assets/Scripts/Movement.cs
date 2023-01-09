using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float maxAcceleration = 20f;

    [SerializeField]
    float minAcceleration = 1f;

    Animator animator;

    [SerializeField]
    float smoothingValue = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private Manager manager;

    private float prevAcc = 1;

    // Start is called before the first frame update

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        if (manager == null)
        {
            Debug.LogError("No Manager");
        }

        animator = GetComponent<Animator>();
        if (!animator)
        {
            Debug.LogError("No aniamtor found");
        }

        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // NEW
        // if (Time.timeScale > 0)
        if (manager.GetGo())
        {
            float nextAcceleration = Random.Range(minAcceleration, maxAcceleration);
            // float clampNextAcc = Mathf.Clamp(
            //     Random.Range(prevAcc - 1, prevAcc + 1),
            //     minAcceleration,
            //     maxAcceleration
            // );
            // prevAcc = clampNextAcc;
            var nextPos = transform.position += Vector3.forward * nextAcceleration * Time.deltaTime;
            // var nextPos = transform.position += Vector3.forward * clampNextAcc * Time.deltaTime;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                nextPos,
                ref velocity,
                smoothingValue
            );
        }
    }
}
