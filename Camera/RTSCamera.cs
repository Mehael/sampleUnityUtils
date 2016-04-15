using UnityEngine;
using System.Collections;
using System;

public class RTSCamera : MonoBehaviour
{
    public int scrollArea = 7;
    public float moveSpeed = 0.1f;
    public Transform rotationCenter;
    public Vector3 rotationVector;

    void Update()
    {
        var mPosX = Input.mousePosition.x;
        var mPosY = Input.mousePosition.y;

        if (mPosX < scrollArea) 
             move(new Vector3(-1, 0, 0)); 
        if (mPosX >= Screen.width - scrollArea) 
            move(new Vector3(1, 0, 0)); 
        if (mPosY >= Screen.height - scrollArea)
            move(new Vector3(0, 1, 0));
        if (mPosY < scrollArea) 
            move(new Vector3(0, -1, 0));

        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(Rotor(-1));
        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(Rotor(1));
    }

    void move(Vector3 derection)
    {
        transform.Translate(derection * moveSpeed, Space.Self);
    }

    IEnumerator Rotor(int rotationSign)
    {
        float processAngle = 0f;
        float distinationAngle = 30f;
        float iterationAngle;
        float rotationSpeed = 100f;

        while (processAngle < distinationAngle)
        {                
            iterationAngle = Time.deltaTime * rotationSpeed;
            transform.RotateAround(rotationCenter.transform.position,
                rotationVector,
                iterationAngle*rotationSign);

            processAngle += iterationAngle;

            yield return null;
        }
    }
}
