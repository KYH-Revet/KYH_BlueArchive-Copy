using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CSVData;
using _Character;

public abstract class Character : MonoBehaviour
{
    //Character infomation
    [Header("Infomation")]
    [SerializeField]
    public int cId;
    [SerializeField]
    public int level;

    [SerializeField]
    protected Character_Info characterInfo;
    public Character_Info info { get { return characterInfo; } }
    public Character_Stat stat { get { return characterInfo.stat; } }

    [Header("2D Images")]
    public Sprite sprite_FullBody;
    public Sprite sprite_Profile;

    public abstract void LoadCharacterInfo();
}
