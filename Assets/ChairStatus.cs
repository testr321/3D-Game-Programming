using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairStatus : MonoBehaviour
{
    public bool occupiedChair = false;

    public void UpdateOccupancy()
    {
        if (!occupiedChair)
            occupiedChair = true;
        else
            occupiedChair = false;
    }
}
