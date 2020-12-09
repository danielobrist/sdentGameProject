using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings shapeSettings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.shapeSettings = settings;
        noiseFilter = new NoiseFilter(settings.noiseSettings);
    }

    public Vector3 CalculatePointOnAsteroid(Vector3 pointOnUnitshpere)
    {
        float noisyElevation = noiseFilter.Evaluate(pointOnUnitshpere);
        return pointOnUnitshpere * shapeSettings.asteroidRadius * (1 + noisyElevation);
    }
}
