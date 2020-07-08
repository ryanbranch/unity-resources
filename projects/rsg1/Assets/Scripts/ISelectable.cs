using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    int DimX { get; set; }
    int DimY { get; set; }
    SelectorShape SelShape { get; set; }
    Selector Sel { get; set; }
    GameObject Gobj { get; set; }
    Collider2D Bc { get; set; }

    void AddSelector();
    void EventLeftMouseDown();

}
