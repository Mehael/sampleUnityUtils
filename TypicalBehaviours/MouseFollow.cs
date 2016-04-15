using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
