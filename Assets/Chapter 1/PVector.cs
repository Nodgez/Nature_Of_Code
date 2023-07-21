using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVector
{
    public float x;
    public float y;

    public PVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static PVector Add(PVector a, PVector b)
    {
        return new PVector(a.x + b.x, a.y + b.y);
    }

    public static PVector Subtract(PVector a, PVector b)
    {
        return new PVector(a.x - b.x, a.y - b.y);
    }

    public void Multiply(float v)
    {
        x *= v;
        y *= v;
    }

    public void Divide(float v)
    {
        x /= v;
        y /= v;
    }

    public float Magnitude()
    {
        //Pythagora's theorm
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        var mag = Magnitude();
        Divide(mag);
    }

    public static PVector Normalize(PVector vector)
    {
        var normalized_v = new PVector(vector.x, vector.y);
        var mag = normalized_v.Magnitude();
        normalized_v.Divide(mag);
        return normalized_v;
    }

    public void Limit(float v)
    {
        if (Magnitude() < v)
            return;

        Normalize();
        Multiply(v);
    }

    public override string ToString()
    {
        var normalized = Normalize(this);
        return string.Format("\nX: {0}\nY:{1}\nmagnitude:{2}\nnormalized: {3}, {4}\n", x, y, Magnitude(), normalized.x, normalized.y);
    }
}
