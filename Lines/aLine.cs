using UnityEngine;
using System.Collections;

public abstract class aLine : MonoBehaviour {
    protected static int linesAmount = 0;
    protected Transform startObject;
    protected Rigidbody2D rBody;
    protected LineRenderer _lineRenderer;
    protected Material material;

    bool isVisible = true;

    public static T CreateLine<T>(Transform startObject, Material lineMaterial) where T : aLine
    {
        var go = new GameObject("Line" + linesAmount);
        var line = go.AddComponent<T>();
        line.SetVariables(startObject, lineMaterial);
        linesAmount++;

        return line;
    }

    public virtual void SetVariables(Transform startObject, Material lineMaterial)
    {
        this.startObject = startObject;
        this.material = lineMaterial;
        this.rBody = startObject.GetComponent<Rigidbody2D>();

        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = material;
        _lineRenderer.SetWidth(0.1f, 0.1f);
        _lineRenderer.useWorldSpace = true;
    }

    void Update() {
        if (isVisible)
            UpdateLine();
    }

    public virtual void UpdateLine() { }

    public void SetVisible(bool newVisible) {
        isVisible = newVisible;
        _lineRenderer.enabled = newVisible;
    }
}
