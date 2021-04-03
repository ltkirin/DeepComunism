using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public abstract class ComponentBase : MonoBehaviour
    {
        [SerializeField]
        private bool isActive = false;

        public bool IsActive => isActive; 

        public virtual void Activate()
        {
            isActive = true;
        }
        public virtual void Deactivate()
        {
            isActive = false;
        }
    }
}
