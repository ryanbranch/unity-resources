using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();
    }

    // Update is called once per frame
    void Update()
    {
        // C A M E R A     I N T E R A C T I O N
        // Camera Pan
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if ((horizontalInput) != 0 || (verticalInput != 0))
        {
            wr.mainCamera.Move(horizontalInput, verticalInput);
        }
        // Camera Zoom
        if (Input.GetKey(Instructions.keyCameraZoomOut))
        {
            wr.mainCamera.ZoomOut();
        }
        else if (Input.GetKey(Instructions.keyCameraZoomIn))
        {
            wr.mainCamera.ZoomIn();
        }
    }
}
