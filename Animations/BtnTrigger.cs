using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BtnTrigger : AlphaController {
    protected bool isActive = false;
	protected List<Graphic> graphics = new List<Graphic>();
    Transform go;
    public List<IEnumerator> script;

    public void OnEnable()
    {
        go = transform.GetChild(0);
        foreach (var t in go.GetComponentsInChildren<Graphic>())
        {
            t.canvasRenderer.SetAlpha(0);
            graphics.Add(t);
        }

       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            go.gameObject.SetActive(true);
            graphics.ForEach(t => {Show(t); });
            isActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            graphics.ForEach(t => { Hide(t); });
            isActive = false;
        }
    }

    public void LateUpdate()
    {
        if (!isActive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickInitiator();
        }
    }

    public virtual void ClickInitiator()
    {
        //if (!Characters.instance.isInPause)
            StartCoroutine(Click());
    }

    IEnumerator Click()
    {
        graphics.ForEach(t => Hide(t));
        isActive = false;

        yield return StartCoroutine(ScriptMachine.Instance.Run(script));
        Destroy(gameObject);
    }
}
