using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GravMap
{

    public static float GravMapM(this float CurrentFlySpeed, float MinFlySpeed, float MaxFlySpeed, float MinGrav, float MaxGrav)
    {
        var fromAbs = CurrentFlySpeed - MinFlySpeed;
        var fromMaxAbs = MaxFlySpeed - MinFlySpeed;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = MaxGrav - MinGrav;
        var toAbs = toMaxAbs * normal;

        var CurrentGrav = toAbs + MinGrav;

        return CurrentGrav;
    }
}
