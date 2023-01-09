using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcamera : MonoBehaviour
{
    [SerializeField]
    Transform cameraFollowTarget = null;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float smoothingValue = 0.3f;

    [SerializeField]
    float cameraBackDistance = 40f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - cameraFollowTarget.position;
        if (!cameraFollowTarget)
        {
            Debug.LogError("NO followCamera");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = cameraFollowTarget.position + offset;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothingValue
        );
        transform.position = cameraFollowTarget.position;
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + cameraBackDistance,
            transform.position.z
        );

        transform.LookAt(cameraFollowTarget);
    }
}
