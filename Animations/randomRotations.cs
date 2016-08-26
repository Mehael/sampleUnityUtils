using UnityEngine;
using System.Collections;

public class randomRotations : MonoBehaviour {
	public float flipDelay = 3f;
	float timer = 0f;
	Vector3 scale;
	Scriptable scriptable;

	void Start()
	{
		scale = transform.localScale;
		scriptable = GetComponent<Scriptable>();
	}

	void Update()
	{
		timer = timer + Time.deltaTime;
		if (timer < flipDelay) return;

		timer = 0;
		if (scriptable == null)
			transform.localScale = new Vector3(transform.localScale.x * (-1), scale.y, scale.z);
		else
			scriptable.Flip();
	}
}
