using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour
{
	public Transform background;				
	public float parallaxScale;	
	public float smoothing;

	private Transform cam;						
	private Vector3 previousCamPos;				


	void Awake ()
	{
		cam = Camera.main.transform;
	}


	void Start ()
	{
		previousCamPos = cam.position;
	}


	void Update ()
	{
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;

			float backgroundTargetPosX = background.position.x + parallax * parallaxScale;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, background.position.y, background.position.z);

			background.position = Vector3.Lerp(background.position, backgroundTargetPos, smoothing * Time.deltaTime);


		previousCamPos = cam.position;
	}
}
