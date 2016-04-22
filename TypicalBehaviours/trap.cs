using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {
    public Transform trapGO;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trapGO.gameObject.SetActive(true);
        }
    }
}
