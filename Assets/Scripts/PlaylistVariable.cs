using Music.Entities;
using UnityEngine;

namespace Music.Variable
{
    [CreateAssetMenu(menuName = "Variables/Playlist")]
    public class PlaylistVariable : ScriptableObject
    {
        public Playlist Value { get; set; }
    }
}