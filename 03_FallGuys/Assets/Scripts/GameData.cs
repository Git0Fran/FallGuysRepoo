using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    [Serializable]
    public class UnlockedCharacter
    {

        public string Name = "";
        public bool isUnlocked = false;
    }
    public float FastestTime = 0.0f;
    public int TimesPlayed =0;
    public List<float> TopFiveTimes = new List<float>();
    public List<UnlockedCharacter> UnlockedCharacters = new List<UnlockedCharacter>();

}
