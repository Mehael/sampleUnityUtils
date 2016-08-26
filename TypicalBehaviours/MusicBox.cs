using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {
	public string music;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			StartCoroutine(Sounds.instance.PlayLoop(music));
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
			StartCoroutine(Sounds.instance.Stop(music));
	}
}
