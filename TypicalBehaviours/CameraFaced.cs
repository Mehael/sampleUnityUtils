using UnityEngine;
using System.Collections;

public class CameraFaced : MonoBehaviour {
    Vector3 camPosition;
    
    void LateUpdate() //really on camera change need only
    {
        if (camPosition == Camera.main.transform.position)
            return;

        camPosition = Camera.main.transform.position;
        transform.LookAt(
            new Vector3(camPosition.x,
                 camPosition.y,
                 camPosition.z),
                -Vector3.forward);

    }
}
