using System.Collections.Generic;
using UnityEngine;

namespace Music.Utils
{
    public class ItemPool<t> where t : UnityEngine.Object
    {
        private List<t> list = new List<t>();

        public t Get(t prefab, int index, Transform container)
        {
            if (list.Count > index)
            {
                return list[index];
            }
            else
            {
                t item = GameObject.Instantiate<t>(prefab, container);
                list.Add(item);
                return item;
            }
        }
    }
}