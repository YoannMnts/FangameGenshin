using System;
using Project.Core.Scripts.Mappers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    public abstract class ScriptableData : ScriptableObject
    {
        [SerializeField, ReadOnly, HideLabel]
        private string guidText;

        public Guid ID
        {
            get
            {
                if (guid == Guid.Empty)
                    guid = Guid.Parse(guidText);

                return guid;
            }
            private set
            {
                guidText = value.ToString();
                guid = value;
            }
        }

        private Guid guid = Guid.Empty;

        protected virtual void Reset()
        {
            guidText = string.Empty;
            OnValidate();
        }

        protected virtual void OnValidate()
        {
            if(string.IsNullOrEmpty(guidText))
                SetNewGuid();
        }

        internal void SetNewGuid() =>  ID = Guid.NewGuid();
    }
}