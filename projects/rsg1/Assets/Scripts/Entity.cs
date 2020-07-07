using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public SpriteRenderer sr;

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
        sr.sprite = Resources.Load<Sprite>(Instructions.resCircle48);
        sr.sortingOrder = Instructions.defaultEntitySortingOrder;
        sr.color = Instructions.colorRed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
