using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxClass : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public SpriteRenderer sr;
    public BoxCollider2D bc;

    [SerializeField]
    public Selector sel;

    public void Construct()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(Instructions.resSquare128);
        bc = gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelector(Selector sel_)
    {
        sel = sel_;
    }

    public void AddSelector()
    {
        // REFERENCE: Instantiate a Prefab and append (Add) its designated class instance to a List
        wr.selectors.Add(Instantiate(wr.selectorPrefab).GetComponent<Selector>());
        sel = wr.selectors[wr.selectors.Count - 1];
    }

    public void EventLeftMouseDown()
    {
        // NOTE: It's okay to handle KEYBOARD events here because they are explicitly preceded by a MOUSE event
        // If the LEFT-CTRL key is down, then move the camera to center on the Sandbox
        if (Input.GetKey(KeyCode.LeftControl))
        {
            wr.mainCamera.MoveToPos(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        // Execute the Selector's Select() method
        sel.Select();
    }
}
