using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Asteroid))]
public class AsteroidEditor : Editor
{
    Asteroid asteroid;
    Editor shapeEditor;
    Editor colorEditor;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                asteroid.GenerateAsteroid();
            }
        }

        if (GUILayout.Button("Generate Asteroid"))
        {
            asteroid.GenerateAsteroid();
        }

        DrawSettingsEditor(asteroid.shapeSettings, asteroid.OnShapeSettingsUpdated, ref asteroid.shapeSettingsFoldout, ref shapeEditor);
        DrawSettingsEditor(asteroid.colorSettings, asteroid.OnColorSettingsUpdated, ref asteroid.colorSettingsFoldout, ref colorEditor);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);  // only creates a new editor when it acutally has to
                    editor.OnInspectorGUI();

                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        asteroid = (Asteroid)target;
    }
}
