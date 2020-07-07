using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left Mouse Button DOWN
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = wr.mainCamera.cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                // Prints some information about the clicked-upon object
                //Debug.Log(hit.collider.gameObject.name);
                //Debug.Log(hit.collider.gameObject.transform.position);


                // SANDBOX CLICKS
                if (hit.collider.gameObject.name == (Instructions.sandboxPrefabGoName))
                {
                    Debug.Log("Mouse Clicked on Sandbox GameObject (ORIGINAL)");
                    

                    // Calls the EventLeftMouseDown() method of the SandboxClass instance belonging to the clicked-upon GameObject
                    hit.collider.gameObject.GetComponent<SandboxClass>().EventLeftMouseDown();
                }

            }
            // Otherwise, hit.collider is NULL and so nothing should be selected
            else
            {
                wr.DeselectAll();
            }
        }
    }
}
