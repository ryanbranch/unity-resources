// TODO: Look into Method Hiding with Class Inheritance and whether that is appropriate here

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Particle : Entity
{

    public void Construct(int x_, int y_)
    {
        base.Construct();
        // INTERFACE ISelectable
        DimX = x_;
        DimY = y_;
        SelShape = SelectorShape.Circular;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        gameObject.transform.SetPositionAndRotation(new Vector3(-3f, 3f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void AddSelector()
    {
        base.AddSelector();
    }

    public void EventLeftMouseDown()
    {
        base.EventLeftMouseDown();
    }
}
