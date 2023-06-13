using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_hareketi : MonoBehaviour
{
    float X_mouse;
    float Y_mouse;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        X_mouse=Input.GetAxis("Mouse Y");
        Y_mouse=Input.GetAxis("Mouse X");
        transform.Rotate(-X_mouse,0,0);

        transform.Rotate(0,Y_mouse,0,Space.World);
    }
}
