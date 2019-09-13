using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bale007.PASM
{
    [System.Serializable]
    public abstract class SharedVariable<T>
    {
        public T value { get; protected set; }
        public abstract T defaulValue { get; }

        public string searchKey;

        AIBrain brain;

        public void Init(AIBrain brain)
        {
            this.brain = brain;

            value = TryGet();
        }

        public void Overwrite()
        {
            ThrowExceptionIfNotInitialized();

            brain.StoreParam(searchKey, value, true);
        }

        public void Dispose()
        {
            ThrowExceptionIfNotInitialized();

            brain = null;
        }

        T TryGet()
        {
            ThrowExceptionIfNotInitialized();

            object value = brain.GetParam(searchKey, false);

            if (value == null)
            {
                brain.StoreParam(searchKey, (object)defaulValue, true);

                return defaulValue;
            }
            else
            {
                return (T)value;
            }
        }

        void ThrowExceptionIfNotInitialized()
        {
            if (brain == null || string.IsNullOrEmpty(searchKey))
            {
                throw new System.Exception("Shared Variable Not Initialized");
            }
        }
    }
}

