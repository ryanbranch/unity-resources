using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public Camera cam;

    public float positionZ;
    public float movementSpeed;
    public float zoomOutRatio;
    public float zoomInRatio;

    public void Construct()
    {
        positionZ = Instructions.defaultCameraPositionZ;
    }

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();

        cam = gameObject.GetComponent<Camera>();

        movementSpeed = Instructions.defaultCameraMovementSpeed;
        zoomOutRatio = Instructions.defaultCameraZoomOutRatio;
        zoomInRatio = Instructions.defaultCameraZoomInRatio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(float x_, float y_)
    {
        transform.Translate(new Vector3(x_, y_, 0) * movementSpeed * Time.deltaTime);
    }

    public void ZoomOut()
    {
        cam.orthographicSize *= zoomOutRatio;
    }

    public void ZoomIn()
    {
        cam.orthographicSize *= zoomInRatio;
    }

    public void MoveToPos(float x_, float y_)
    {
        gameObject.transform.SetPositionAndRotation(new Vector3(x_, y_, positionZ), Quaternion.identity);
    }
}
