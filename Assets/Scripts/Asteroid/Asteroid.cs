﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;
    public bool autoUpdate = true;

    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colorSettingsFoldout;

    ShapeGenerator shapeGenerator; 

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    AsteroidFace[] asteroidFaces;

    private void Awake()
    {
        //GenerateAsteroid();
    }
    void Initialize()
    {
        
        shapeGenerator = new ShapeGenerator(shapeSettings);
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];  //one for each terrain face
        }
        asteroidFaces = new AsteroidFace[6];  //one for each terrain face

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null )
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard")); //default mat for nw
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            asteroidFaces[i] = new AsteroidFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    public void GenerateAsteroid()
    {
        Initialize();
        GenerateMesh();
        GenerateColors();
    }

    public void OnShapeSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialize();
            GenerateMesh();
        }
    }

    public void OnColorSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialize();
            GenerateColors();
        }
    }

    void GenerateMesh()
    {
        foreach (AsteroidFace face in asteroidFaces)
        {
            face.ConstructMesh();
        }
    }

    void GenerateColors()
    {
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.asteroidColor;
        }
    }

}
