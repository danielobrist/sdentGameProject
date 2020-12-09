using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings shapeSettings;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.shapeSettings = settings;
    }

    public Vector3 CalculatePointOnAsteroid(Vector3 pointOnUnitshpere)
    {
        return pointOnUnitshpere * shapeSettings.asteroidRadius;
    }
}
