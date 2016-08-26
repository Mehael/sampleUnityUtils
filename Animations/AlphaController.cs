using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class alphaInfo{
    public Color color;
    public int state = 0;
    public float alpha = 0;

    public alphaInfo(Graphic guiElement){
        color = guiElement.color;
		alpha = guiElement.canvasRenderer.GetAlpha();
    }
}

public abstract class AlphaController : MonoBehaviour {
    public bool isInFading = false;
    public float fadeSpeed = 1f;
    public bool isBusy = false;
    Dictionary<Graphic, alphaInfo> alphaInfo = new Dictionary<Graphic, alphaInfo>();

    public void AddUIElement(Graphic guiElement)
    {
        alphaInfo[guiElement] = new alphaInfo(guiElement);
    }

    public void RemoveUIElement(Graphic guiElement) { alphaInfo.Remove(guiElement); }

    public void Show(Graphic guiElement)
    {
        if (!alphaInfo.ContainsKey(guiElement))
            AddUIElement(guiElement);

		alphaInfo[guiElement].state = 1;
    }

    public IEnumerator WaitInFading()
    {
        while (isInFading) { yield return new WaitForEndOfFrame(); }
    }

    public void Hide(Graphic guiElement) {
        if (alphaInfo.ContainsKey(guiElement))
            alphaInfo[guiElement].state = -1; 
    }

    void Update()
    {
        var hasFading = false;
		var hasAnyProcess = false;
		foreach (var e in alphaInfo.Keys)
        {
			if (alphaInfo[e].state == 0) continue;
			else hasAnyProcess = true;

			if (alphaInfo[e].state > 0) hasFading = true;

            alphaInfo[e].alpha = Mathf.Clamp01(alphaInfo[e].alpha + 
                alphaInfo[e].state * fadeSpeed * Time.deltaTime);

            if ((alphaInfo[e].alpha == 0 && alphaInfo[e].state == -1) ||
            (alphaInfo[e].alpha == 1 && alphaInfo[e].state == 1))
                alphaInfo[e].state = 0;
 
            e.canvasRenderer.SetAlpha(alphaInfo[e].alpha);
        }

		isInFading = hasFading;
		isBusy = hasAnyProcess;

	}

	protected IEnumerator WaitBusy()
	{
		yield return new WaitForSeconds(1f);
		while (isBusy) yield return new WaitForEndOfFrame();
	}
}
