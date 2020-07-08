using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public abstract class Entity : MonoBehaviour, ISelectable
{
    public GameObject wrGo;
    public Wrapper wr;
    public SpriteRenderer sr;
    public bool flagDidConstruct;

    // Fulfillment of INTERFACE ISelectable
    public int DimX { get; set; }
    public int DimY { get; set; }
    public SelectorShape SelShape { get; set; }
    public Selector Sel { get; set; }
    public GameObject Gobj { get { return gameObject; } set {}  }
    public Collider2D Bc { get; set; }


    public virtual void Construct()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();

        // If the Type of THIS is Entity, then this is the end of calling Construct()
        if (this.GetType() == typeof(Entity)) {
            Debug.Log("True for ENTITY");
            flagDidConstruct = true;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // TODO: FIX THIS; Entity should not inherently use CircleCollider2D over BoxCollider2D
        Bc = gameObject.AddComponent<CircleCollider2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(Instructions.resCircle48);
        sr.sortingOrder = Instructions.defaultEntitySortingOrder;
        sr.color = Instructions.colorRed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void AddSelector()
    {
        wr.selectors.Add(Instantiate(wr.selectorPrefab).GetComponent<Selector>());
        Sel = wr.selectors[wr.selectors.Count - 1];
        Sel.Construct();
        Sel.SetParent(this);
        Sel.DetermineSprite();
    }

    public virtual void EventLeftMouseDown()
    {
        // NOTE: It's okay to handle KEYBOARD events here because they are explicitly preceded by a MOUSE event
        // If the LEFT-CTRL key is down, then move the camera to center on the Sandbox
        if (Input.GetKey(KeyCode.LeftControl))
        {
            wr.mainCamera.MoveToPos(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        // Execute the Selector's Select() method
        Sel.Select();
        // Update the Wrapper's primarySelection value
        wr.primarySelection = this;
    }
    public virtual void MoveToPos(float x_, float y_)
    {
        gameObject.transform.SetPositionAndRotation(new Vector3(x_, y_, gameObject.transform.position.z), Quaternion.identity);
    }
}
