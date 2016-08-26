using UnityEngine;
using System.Collections;

public class SinFly : MonoBehaviour {
	public Vector3 maxFloat;
	public float flySpeed;
	public float fadeTime;
	public bool isHidedOnStart = false;

	Vector3 original;
	bool firstStart = true;
	SpriteRenderer sprite;

	void Start()
	{
		original = transform.localPosition;
		firstStart = false;
		sprite = GetComponent<SpriteRenderer>();
		if (isHidedOnStart)
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
		StartCoroutine(Fly());
	}

	void OnEnable () {
		if (firstStart == false)
			StartCoroutine(Fly());
	}

	public IEnumerator Show()
	{
		yield return StartCoroutine(AlpfaChange(1));
	}

	public IEnumerator Hide()
	{
		yield return StartCoroutine(AlpfaChange(0));
	}

	IEnumerator AlpfaChange(float targetAlpfa)
	{
		var velocity = 0f;
		var color = sprite.color;
		while (Mathf.Abs(color.a - targetAlpfa) > .1f)
		{
			color.a = Mathf.SmoothDamp(color.a, targetAlpfa, ref velocity, fadeTime);
			sprite.color = color;
			yield return new WaitForFixedUpdate();
		}

		color.a = targetAlpfa;
		sprite.color = color;
	}

	IEnumerator Fly()
	{
		var time = 0f;
		var virtualSpeedTime = 0f;
		while (true)
		{
			time += Time.deltaTime;
			virtualSpeedTime = time * flySpeed;
			if (virtualSpeedTime > Mathf.PI) time = 0;
			transform.localPosition = original + (maxFloat * Mathf.Sin(virtualSpeedTime));
			yield return new WaitForFixedUpdate();
		}
	}

	void OnDisable()
	{
		transform.localPosition = original;
	}
}
