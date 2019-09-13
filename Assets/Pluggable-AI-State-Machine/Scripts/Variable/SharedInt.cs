using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    [System.Serializable]
    public class SharedInt : SharedVariable<int>
    {
        public int defaultValue = 0;

        public override int defaulValue
        {
            get
            {
                return defaultValue;
            }
        }
    }

}
