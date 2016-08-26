using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : AlphaController {
    public static Fade instance;

	public Graphic menuFadeSprite;

	public GameObject pauseGroup;

	public Graphic pauseFadeSprite;
	public GameObject pauseInputGroup;
	public GameObject pauseDoTipsGroup;
	public GameObject pauseYNTipsGroup;

	void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        menuFadeSprite.gameObject.SetActive(true);
        AddUIElement(menuFadeSprite);
	}
	
	public IEnumerator Unfade(){
		menuFadeSprite.gameObject.SetActive(true);
		Hide(instance.menuFadeSprite);
		yield return StartCoroutine(WaitBusy());
	}

	public IEnumerator FadeIt()
	{
		Show(instance.menuFadeSprite);
		yield return StartCoroutine(WaitBusy());
	}

	public IEnumerator FadeGamePause()
	{
		pauseGroup.gameObject.SetActive(true);
		Show(pauseFadeSprite);
		yield return StartCoroutine(WaitBusy());
	}

	public IEnumerator ShowGo(GameObject go)
	{
		yield return StartCoroutine(ActiveAndShow(go));
	}

	public IEnumerator HideGo(GameObject go)
	{
		yield return StartCoroutine(DeactiveAndHide(go));
		go.gameObject.SetActive(false);
	}

	public IEnumerator UnfadePause()
	{
		yield return StartCoroutine(DeactiveAndHide(pauseFadeSprite));
		//pauseGroup.gameObject.SetActive(false);
	}

	IEnumerator DeactiveAndHide(GameObject go)
	{
		var gr = go.GetComponentsInChildren<Graphic>();
		foreach (var g in gr)
			StartCoroutine(DeactiveAndHide(g));

		yield return StartCoroutine(WaitBusy());
	}

	IEnumerator ActiveAndShow(GameObject go)
	{
		go.SetActive(true);
		var gr = go.GetComponentsInChildren<Graphic>();
		foreach (var g in gr)
		{
			g.canvasRenderer.SetAlpha(0f);
			StartCoroutine(ActiveAndShow(g));
		}

		yield return StartCoroutine(WaitBusy());
	}

	IEnumerator DeactiveAndHide(Graphic gr)
	{		
		Hide(gr);
		yield return StartCoroutine(WaitBusy());
	}

	IEnumerator ActiveAndShow(Graphic gr)
	{
		gr.gameObject.SetActive(true);
		Show(gr);
		yield return StartCoroutine(WaitBusy());
	}

}
