using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextTypingWithSound : MonoBehaviour {
    public string textToType;
    public float typingPause = .1f;
    public Text shadow;
    public AudioClip letterSound;
    public bool isSelfDestroying = false;
    public float timeToDestroy = 5f;

    Text textUIComponent;
    AudioSource audioPlayer;
    float hideSpeed = 1f;

	void OnEnable () {
        StartCoroutine(Print());
    }

    IEnumerator Print()
    {
        textUIComponent = GetComponent<Text>();
        if (letterSound)
            audioPlayer = GetComponent<AudioSource>();
        textUIComponent.text = "";

        foreach (var letter in textToType)
        {
            textUIComponent.text += letter;
            if (shadow != null)
                shadow.text = textUIComponent.text;

            if (letterSound)
                audioPlayer.PlayOneShot(letterSound);

            yield return new WaitForSeconds(typingPause);
        }

        if (!isSelfDestroying)
            yield break;

        yield return new WaitForSeconds(timeToDestroy);
        yield return StartCoroutine(FadeTo(.0f, hideSpeed));
        Destroy(gameObject);
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        Color color = textUIComponent.color;
        float startAlpha = color.a;
        
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(color.r, color.g, color.b, Mathf.Lerp(startAlpha, aValue, t));
            textUIComponent.color = newColor;
            yield return null;
        }
    }

}
