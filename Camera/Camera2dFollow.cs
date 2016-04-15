using UnityEngine;
using System.Collections;

public class Camera2dFollow : MonoBehaviour {
    public float speed = 0.1f;
    Transform mainCamera;
    void Start()
    {
        mainCamera = Camera.main.transform;
    }
	// Update is called once per frame
	void FixedUpdate () {
        var specificVector = new Vector3(transform.position.x, transform.position.y, mainCamera.position.z);
        mainCamera.position = Vector3.Lerp(mainCamera.position, specificVector, speed * Time.deltaTime);
	}
}
