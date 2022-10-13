using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Music.Entities;

[CreateAssetMenu]
public class PlaylistRepository : ScriptableObject
{
    [SerializeField]
    private string filename;

    public List<Playlist> playlists;

    public void Load()
    {
        string json = Resources.Load<TextAsset>(filename).text;
        playlists = JsonConvert.DeserializeObject<List<Playlist>>(json);
    }
}