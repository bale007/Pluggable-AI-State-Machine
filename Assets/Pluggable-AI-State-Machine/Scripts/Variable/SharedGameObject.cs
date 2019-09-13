using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    [System.Serializable]
    public class SharedGameObject : SharedVariable<GameObject>
    {
        public string objectTag;

        public override GameObject defaulValue
        {
            get
            {
                return GameObject.FindGameObjectWithTag(objectTag);
            }
        }
    }

}
