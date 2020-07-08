// TODO: Look into Method Hiding with Class Inheritance and whether that is appropriate here

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Particle : Entity
{
    public override void Construct()
    {
        base.Construct();
        DimX = Instructions.defaultParticleDimX;
        DimY = Instructions.defaultParticleDimY;
        SelShape = Instructions.defaultParticleSelShape;

        // If the Type of THIS is Particle, then this is the end of calling Construct()
        if (this.GetType() == typeof(Particle))
        {
            Debug.Log("True for PARTICLE in Construct()");
            flagDidConstruct = true;
        }
    }
    public void Construct(int x_, int y_)
    {
        base.Construct();
        // INTERFACE ISelectable
        DimX = x_;
        DimY = y_;
        SelShape = SelectorShape.Circular;

        // If the Type of THIS is Particle, then this is the end of calling Construct()
        if (this.GetType() == typeof(Particle))
        {
            Debug.Log("True for PARTICLE in Construct(x, y)");
            flagDidConstruct = true;
        }
    }

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }

    override public void AddSelector()
    {
        base.AddSelector();
    }

    override public void EventLeftMouseDown()
    {
        base.EventLeftMouseDown();
    }
}
