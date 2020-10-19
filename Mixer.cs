using UnityEngine;

namespace Ix
{
    namespace Spectra
    {
        [ExecuteAlways]
        public class Mixer : MonoBehaviour
        {

            public Palette p;

            public float hMin;
            public float hMax;
            public float sMin;
            public float sMax;
            public float vMin;
            public float vMax;
            public int nKeys;

            public int nColors;

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
                for (int i = 0; i < nColors + 1; i++)
                {
                    float t = (i * (1.0f / (nColors + 1)));
                    p.colors[i] = p.gradient.Evaluate(t);
                }
            }

        }
    }
}
