using UnityEngine;
using System.Collections;

public class AlpfaFlips : MonoBehaviour {
	public float fadeTime = 5f;
	public float delay = 2f;

	IEnumerator Start () {
		var sprite = GetComponent<SpriteRenderer>();
		var velocity = 0f;
		var color = sprite.color;
		var targetAlpfa = 1f;
		while (true)
		{
			yield return new WaitForSeconds(delay);

			targetAlpfa = targetAlpfa == 0 ? 1 : 0;
			while (Mathf.Abs(color.a- targetAlpfa) > .1f)
			{
				color.a = Mathf.SmoothDamp(color.a, targetAlpfa, ref velocity, fadeTime);
				sprite.color = color;
				yield return new WaitForFixedUpdate();
			}
		}
	}

}
