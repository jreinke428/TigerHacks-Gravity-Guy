using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData")]

public class LevelData : ScriptableObject
{
    public int levelNum;
    public int attempts = 0;
    public int pushNum;
    public int pullNum;
}
