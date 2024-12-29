using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static bool InLineOfSight(this Vector3 start, Vector3 end, LayerMask mask)
    {
        Vector3 dir = end - start;
        return !Physics.Raycast(start, dir, dir.magnitude, mask);
    }

}
