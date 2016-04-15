using UnityEngine;
using System.Collections;

public class SimpleShot : aShot{
    public override void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
