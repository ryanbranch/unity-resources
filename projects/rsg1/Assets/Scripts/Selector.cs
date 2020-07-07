using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public SpriteRenderer sr;

    public bool flagSelecting;
    public bool flagAnimating;
    public bool flagChangedView;


    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();

        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(Instructions.resBorder8Square128);
        sr.sortingOrder = Instructions.defaultSelectorSortingOrder;

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
}
