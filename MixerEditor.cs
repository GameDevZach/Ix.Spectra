using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;

namespace Ix
{
    namespace Spectra
    {
        [CustomEditor(typeof(Mixer))]
        public class MixerEditor : Editor
        {
            Mixer m;
            GUIStyle style;

            void OnEnable()
            {
                m = (Mixer)target;

                style = new GUIStyle();
                int p = 10;
                style.padding = new RectOffset(p, p, p, p);
                style.normal = EditorStyles.helpBox.normal;
                style.border = EditorStyles.helpBox.border;
            }


            public override void OnInspectorGUI()
            {

                //DrawDefaultInspector();

                EditorGUILayout.BeginVertical(style);
                m.p = (Palette)EditorGUILayout.ObjectField("Palette:", m.p, typeof(Palette), true);

                if (GUILayout.Button("Next", GUILayout.Height(30)))
                {
                    Undo.RecordObject(target, "Next color scheme");
                    m.RandomizeGradient();
                    m.SetColors();
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.Separator();

                if (m.p)
                {

                    EditorGUILayout.Separator();
                    EditorGUILayout.BeginVertical(style);

                    if (m.p.gradient != null)
                    {
                        EditorGUILayout.GradientField(m.p.gradient, GUILayout.Height(40));
                    }

                    m.hMin = EditorGUILayout.Slider("Min Hue", m.hMin, 0, 1);
                    m.hMax = EditorGUILayout.Slider("Max Hue", m.hMax, 0, 1);
                    m.nKeys = EditorGUILayout.IntSlider("Keys", m.nKeys, 1, 8);
                    EditorGUILayout.MinMaxSlider("Saturation range", ref m.sMin, ref m.sMax, 0, 1);
                    EditorGUILayout.MinMaxSlider("Value range", ref m.vMin, ref m.vMax, 0, 1);
                    EditorGUILayout.Separator();
                    if (GUILayout.Button("Randomize Gradient", GUILayout.Height(30)))
                    {
                        Undo.RecordObject(target, "Randomize Gradient");
                        m.RandomizeGradient();
                    }


                    EditorGUILayout.EndVertical();

                    EditorGUILayout.Separator();

                    EditorGUILayout.BeginVertical(style);
                    m.nColors = EditorGUILayout.IntSlider("Colors", m.nColors, 1, 10);

                    if (m.p.colors != null)
                    {
                        for (int i = 0; i < m.p.colors.Length; i++)
                        {
                            m.p.colors[i] = EditorGUILayout.ColorField(m.p.colors[i]);
                        }
                    }

                    EditorGUILayout.Separator();
                    if (GUILayout.Button("Set Colors", GUILayout.Height(30)))
                    {
                        Undo.RecordObject(target, "Set Colors");
                        m.SetColors();

                    }

                    EditorGUILayout.EndVertical();
                }
            }

        }
    }
}
