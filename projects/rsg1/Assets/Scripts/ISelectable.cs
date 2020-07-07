using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    Collider2D Bc { get; set; }
    int DimX { get; set; }
    int DimY { get; set; }
    SelectorShape SelShape { get; set; }
    Selector Sel { get; set; }

    void AddSelector();
    void EventLeftMouseDown();

}
