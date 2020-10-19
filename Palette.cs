using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ix
{
    namespace Spectra
    {
        [CreateAssetMenu(fileName = "New Palette", menuName = "Spectra Palette", order = 51)]

        public class Palette : ScriptableObject
        {
            public Gradient gradient;
            public Color[] colors;
        }
    }
}
