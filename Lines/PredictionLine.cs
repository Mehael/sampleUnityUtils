using UnityEngine;
using System.Collections;

public class PredictionLine : aLine {
    public int segmentsAmount = 10;
    Vector2 velocity;

    public override void SetVariables(Transform startObject, Material lineMaterial)
    {
        base.SetVariables(startObject, lineMaterial);
        _lineRenderer.SetVertexCount(segmentsAmount);
    }

    public float multiplSpeed = 70f;

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    public override void UpdateLine() {
        _lineRenderer.SetVertexCount(segmentsAmount);

         var position = startObject.position;
         //var velocity = rBody.velocity;

         for (var i = 0; i < segmentsAmount; i++) {
            _lineRenderer.SetPosition(i, new Vector3(position.x, position.y, 0));
            velocity += Physics2D.gravity * Time.fixedDeltaTime * multiplSpeed;
            var segmentVector = (Vector3)velocity * Time.fixedDeltaTime * multiplSpeed;

            RaycastHit2D hit = Physics2D.Raycast(position, segmentVector.normalized, segmentVector.magnitude);
            if (hit.collider != null)
            {
                velocity = Vector3.Reflect(velocity, hit.normal);
                position = hit.point;
            } else
                position += segmentVector;

        }
     }
}
