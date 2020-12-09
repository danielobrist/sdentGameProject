using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    NoiseSettings noiseSettings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = (noise.Evaluate(point * noiseSettings.roughness + noiseSettings.center) + 1) * 0.5f;
        return noiseValue * noiseSettings.strength;
    }
}
