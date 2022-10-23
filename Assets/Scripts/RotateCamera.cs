using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveH=Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up*moveH*rotationSpeed*Time.deltaTime);
    }
}
