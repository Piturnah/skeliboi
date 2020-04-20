using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public List<GameObject> bgTiles;
    public List<GameObject> hazards;
    public List<Sprite> floorTiles;
}
