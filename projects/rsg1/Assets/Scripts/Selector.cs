using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public SpriteRenderer sr;

    public bool flagHasParent;
    // TODO: Consider trying to go about this in a different way
    //   https://answers.unity.com/questions/539390/check-if-a-trigger-object-implements-an-interface.html
    //   https://answers.unity.com/questions/523409/strategy-pattern-with-monobehaviours.html?_ga=2.197816044.2121260276.1594178685-520519817.1594178685
    public ISelectable parent;

    public bool flagSelecting;
    public bool flagAnimating;
    public bool flagChangedView;

    public void Construct()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sortingOrder = Instructions.defaultSortingOrderSelector;
        // NOTE: Don't need the below line here, it's handled in DetermineSprite()
        sr.sprite = Resources.Load<Sprite>(Instructions.defaultImgSelector);
    }

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();


        flagHasParent = false;

        flagSelecting = false;
        flagAnimating = false;
        flagChangedView = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagChangedView)
        {
            Refresh();
        }

        
        if (flagAnimating)
        {
            flagChangedView = true;
        }

        //Debug.Log(parent.DimX);
    }

    // Only to be called when a visual change is needed
    public void Refresh()
    {
        if (flagAnimating)
        {
            float newRed = Mathf.Repeat((sr.color.r - 0.01f), 1f);
            float newGreen = Mathf.Repeat((sr.color.g - 0.02f), 1f);
            float newBlue = Mathf.Repeat((sr.color.b - 0.03f), 1f);
            sr.color = new Color(newRed, newGreen, newBlue);
        }
        // The update is to STOP displaying the Selector sprite, so we make it transparent
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
        
        // Resets the value of flagChangedView, since the view has been changed and no longer (immediately) needs to be
        flagChangedView = false;
    }

    public void Deselect()
    {
        // Action only needs to be taken if flagSelecting is true
        if (flagSelecting)
        {
            flagAnimating = false;
            flagChangedView = true;
            flagSelecting = false;
        }
        // Else, there is nothing selected to deselect.
    }

    public void Select()
    {
        // Action only needs to be taken if flagSelecting is false
        if (!flagSelecting)
        {
            flagAnimating = true;
            flagChangedView = true;
            flagSelecting = true;
        }
        // Else, the Selector is already selecting.
    }

    public void SetParent(ISelectable parent_)
    {
        parent = parent_;
        gameObject.transform.SetParent(parent.Gobj.transform);
        flagHasParent = true;
    }

    // INVARIANTS:
    //  - Selector must have a parent
    //    - Selector.SetParent() must have already been executed
    public bool DetermineSprite()
    {
        // Return early (false) if no parent has been established for the Selector
        if (!flagHasParent)
        {
            Debug.LogError("Selector does not have a defined parent, or its flagHasParent value is wrongly false");
            return false;
        }
        // Otherwise, can proceed with determining Sprite selection
        // Circular Selector Shape
        if (parent.SelShape == SelectorShape.Circular)
        {
            sr.sprite = Resources.Load<Sprite>(Instructions.defaultImgSelectorCircle);
        }
        // Rectangular Selector Shape
        else if (parent.SelShape == SelectorShape.Rectangular)
        {
            sr.sprite = Resources.Load<Sprite>(Instructions.defaultImgSelectorSquare);
        }
        // Other/Undefined
        else
        {
            Debug.LogError("Selector's parent.SelShape value is neither Circular nor Rectangular");
            return false;
        }

        return true;
    }
}
