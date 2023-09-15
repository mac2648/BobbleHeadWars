using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        pos.z += MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position = pos;
    }
}
