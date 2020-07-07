using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Entity : MonoBehaviour, ISelectable
{
    public GameObject wrGo;
    public Wrapper wr;

    public SpriteRenderer sr;

    [SerializeField]
    public int DimX { get; set; }
    [SerializeField]
    public int DimY { get; set; }
    [SerializeField]
    public SelectorShape SelShape { get; set; }
    [SerializeField]
    public Selector Sel { get; set; }
    public Collider2D Bc { get; set; }

    public GameObject Gobj { get; set; }


    protected void Construct()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();

        Gobj = gameObject;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        // TODO: FIX THIS; Entity should not inherently use CircleCollider2D over BoxCollider2D
        Bc = gameObject.AddComponent<CircleCollider2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(Instructions.resCircle48);
        sr.sortingOrder = Instructions.defaultEntitySortingOrder;
        sr.color = Instructions.colorRed;
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public void AddSelector()
    {
        Debug.Log("Before");
        wr.selectors.Add(Instantiate(wr.selectorPrefab).GetComponent<Selector>());
        Debug.Log("After");
        Sel = wr.selectors[wr.selectors.Count - 1];
        Sel.SetParent(this);
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
        Sel.Select();
    }
    public void MoveToPos(float x_, float y_)
    {
        gameObject.transform.SetPositionAndRotation(new Vector3(x_, y_, gameObject.transform.position.z), Quaternion.identity);
    }
}
