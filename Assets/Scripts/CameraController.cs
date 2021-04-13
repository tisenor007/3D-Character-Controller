using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSmoothingFactor = 1.0f;

    public float minLookUpAngle = -20f;
    public float maxLookUpAngle = 40f;
    



    private Quaternion camRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.x +=  Input.GetAxis("Mouse Y") * cameraSmoothingFactor * (-1) ;     // look up & down
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor;              // look left & right

        camRotation.x = Mathf.Clamp(camRotation.x, minLookUpAngle, maxLookUpAngle);     // Limits the look up & down angles

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);        
    }
}
