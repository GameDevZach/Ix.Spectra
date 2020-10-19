using UnityEngine;

namespace Ix
{
    namespace Spectra
    {
        [ExecuteAlways]
        public class Mixer : MonoBehaviour
        {

            public Palette p;

            public float hMin = 0;
            public float hMax = 1;
            public float sMin = 0;
            public float sMax = 1;
            public float vMin = 0;
            public float vMax = 1;
            public int nKeys = 5;

            public int nColors = 3;

            public void RandomizeGradient()
            {
                p.gradient = new Gradient();

                GradientColorKey[] c = new GradientColorKey[nKeys];
                GradientAlphaKey[] a = new GradientAlphaKey[nKeys];

                var rand = new System.Random();

                for (int i = 0; i < nKeys; i++)
                {
                    float h = (float)rand.NextDouble() * (hMax - hMin) + hMin;
                    float s = (float)rand.NextDouble() * (sMax - sMin) + sMin;
                    float v = (float)rand.NextDouble() * (vMax - vMin) + vMin;

                    Color nc = Color.HSVToRGB(h, s, v);

                    c[i].color = nc;
                    a[i].time = c[i].time = (i * (1.0f / nKeys));
                    a[i].alpha = 1.0f;
                }

                p.gradient.SetKeys(c, a);
            }

            public void SetColors()
            {
                p.colors = new Color[nColors];
                for (int i = 0; i < nColors; i++)
                {
                    float t = (i * (1.0f / nColors));
                    p.colors[i] = p.gradient.Evaluate(t);
                }
            }

        }
    }
}
