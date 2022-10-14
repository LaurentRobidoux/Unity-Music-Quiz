using Music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Music.Variable
{
    [CreateAssetMenu(menuName = "Variables/Playlist")]
    public class PlaylistVariable : ScriptableObject
    {
        public Playlist Value { get; set; }
    }
}