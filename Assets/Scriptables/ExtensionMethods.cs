using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ExtensionMethods
{
    public static bool IsEqual(this float val1, float val2, float delta = 0.0001f)
    {
        return Mathf.Abs(val1 - val2) < delta;
    }

    public static bool IsEqual(this Color val1, Color val2)
    {
        if (val1.r.IsEqual(val2.r, 0.1f) && val1.g.IsEqual(val2.g, 0.1f)
            && val1.b.IsEqual(val2.b, 0.1f) && val1.a.IsEqual(val2.a, 0.1f))
            return true;
        return false;
    }

    public static bool IsEqual(this Vector3 val1, Vector3 val2)
    {
        if (val1.x.IsEqual(val2.x) && val1.y.IsEqual(val2.y) && val1.z.IsEqual(val2.z))
            return true;
        return false;
    }
}