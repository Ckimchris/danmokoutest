﻿using System;
using System.Reactive;
using BagoumLib.Mathematics;
using Suzunoya.ControlFlow;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SuzunoyaUnity {
public static class Helpers {
    public static void SetLayerRecursively(this GameObject o, int layer) {
        if (o == null) return;
        o.layer = layer;
        foreach (Transform ch in o.transform) {
            SetLayerRecursively(ch.gameObject, layer);
        }
    }

    public static Vector3 V3(float x, float y, float z = 0) => new Vector3(x, y, z);
    public static Vector3 V3(double x, double y, double z = 0) => new Vector3((float)x, (float)y, (float)z);

    public static Vector3 V3(float xyz) => new Vector3(xyz, xyz, xyz);
    
    public static Color WithA(this Color c, float a) {
        c.a = a;
        return c;
    }
    public static Color MulA(this Color c, float a) {
        c.a *= a;
        return c;
    }
    
    public static byte ToByte(this float f) =>
        f <= 0 ? byte.MinValue :
        f >= 1 ? byte.MaxValue :
        (byte) (f * 256f);

    public static Vector3 WithY(this Vector3 v3, float y) => new Vector3(v3.X, y, v3.Z);

    public static LazyAction Lazy(Action a) => new LazyAction(a);

    public static Func<float, Vector3> JumpY(float mag) => t => new Vector3(0, mag * OffEasers.ESine010(t), 0);
    public static Func<float, Vector3> JumpX(float mag) => t => new Vector3(mag * OffEasers.ESine010(t), 0, 0);
    public static Func<float, Vector3> JumpNX(float mag, int n) => t => new Vector3(mag * OffEasers.ESine010(t * n), 0, 0);
}
}