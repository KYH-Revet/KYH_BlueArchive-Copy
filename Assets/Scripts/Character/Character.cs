using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CSVData;
using _Character;

public abstract class Character : MonoBehaviour
{
    //Character infomation
    protected Character_Info characterInfo;
    protected Character_Stat stat { get { return characterInfo.stat; } }

    [Header("2D Images")]
    //public Sprite sprite_FullBody;
    public Sprite sprite_Profile;
}
