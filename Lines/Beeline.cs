using UnityEngine;
using System.Collections;

public class Beeline : aLine {
    public Vector2 lineVector;

    public override void SetVariables(Transform startObject, Material lineMaterial)
    {
        base.SetVariables(startObject, lineMaterial);
        _lineRenderer.SetVertexCount(2);
    }

    public override void UpdateLine()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //set the start point and end point of the line renderer
        _lineRenderer.SetPosition(0, startObject.transform.position);
        _lineRenderer.SetPosition(1, mousePos);

        lineVector = new Vector2(mousePos.x - startObject.transform.position.x,
            mousePos.y - startObject.transform.position.y);
    }
}
