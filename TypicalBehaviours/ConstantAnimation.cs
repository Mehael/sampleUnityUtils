using UnityEngine;
using System.Collections;

public class ConstantAnimation : MonoBehaviour {
    public Vector3 moveVector;
    public float Torgue;

	// Update is called once per frame
	void Update () {
        var delta = Time.deltaTime;
        transform.Translate(moveVector * delta);
        transform.Rotate(Vector3.forward, Torgue * delta);
	}
}
