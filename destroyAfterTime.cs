using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class destroyAfterTime : MonoBehaviour {
    public float timeToDestroy = 3f;

	IEnumerator Start () {
        yield return new WaitForSeconds(timeToDestroy);
	    Destroy(gameObject);
    }
}
