using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject FollowTarget;
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowTarget)
        {
            transform.position = Vector3.Lerp(transform.position, FollowTarget.transform.position, MoveSpeed * Time.deltaTime);
        }
    }
}
