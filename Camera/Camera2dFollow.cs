using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera2dFollow : MonoBehaviour
{
	public Transform target;
	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	public float MaxCameraSize;
	public float MinCameraSize;

	CharacterController2D _playerController;
	Vector3 _smoothDampVelocity;
	Vector3 CamTarget;
	Vector3 PlayerCamTarget;

	public List<Transform> anchors = new List<Transform>();
	Camera cam;
	float TargetCamSize;
	float sizeVelocity;

	void OnEnable()
	{
		transform = Camera.main.transform;
		_playerController = target.GetComponent<CharacterController2D>();
		cam = Camera.main;

		var playerPos = _playerController.transform.position;
		PlayerCamTarget = new Vector3(
			playerPos.x,
			playerPos.y,
			playerPos.z - cameraOffset.z);
		TargetCamSize = MinCameraSize;

		recalculateCamTarget();
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(CamTarget, 1);

		Gizmos.color = Color.gray;
		Gizmos.DrawSphere(PlayerCamTarget, 1);
		foreach (var t in anchors)
			Gizmos.DrawSphere(t.position, 1);
	}

	void LateUpdate()
	{
		updateCameraPosition();
	}

	public void updateCameraPosition(bool force=false)
	{
		if (Input.anyKey || force)
		{
			if (_playerController.velocity.x > 0)
				PlayerCamTarget = target.position - cameraOffset;

			if (_playerController.velocity.x < 0)
			{
				var leftOffset = cameraOffset;
				leftOffset.x *= -1;
				PlayerCamTarget = target.position - leftOffset;
			}

			if (force)
				PlayerCamTarget = target.position - new Vector3(0, 2.1f, cameraOffset.z);

			recalculateCamTarget();
		}

		MoveCam();
	}

	void MoveCam()
	{
		transform.position = Vector3.SmoothDamp(transform.position, CamTarget, ref _smoothDampVelocity, smoothDampTime);
		cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, TargetCamSize, ref sizeVelocity, smoothDampTime * 2);
	}

	void recalculateCamTarget()
	{
		var massCenter = PlayerCamTarget;
		foreach (var anch in anchors)
			massCenter += anch.position;

		if (anchors.Count == 0)
			TargetCamSize = MinCameraSize;
		else
			TargetCamSize = MaxCameraSize;

		CamTarget = massCenter / (anchors.Count + 1);
		CamTarget.z = PlayerCamTarget.z;
	}

	void AddAnchor(Transform newAnchor)
	{
		anchors.Add(newAnchor);
		recalculateCamTarget();
	}

	void RemAnchor(Transform Anchor)
	{
		anchors.Remove(Anchor);
		recalculateCamTarget();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "anchor")
			AddAnchor(other.transform);
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "anchor")
			RemAnchor(other.transform);
	}
}