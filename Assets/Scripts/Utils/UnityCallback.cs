using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Utils
{
    public class UnityCallback : MonoBehaviour
    {
        public UnityEvent onEnable;

        private void OnEnable()
        {
            onEnable.Invoke();
        }
    }
}