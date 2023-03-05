using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Battle : Character
{    
    [Header("Variable for battle")]
    public uint maxAmmo = 10;
    public uint curAmmo
    {
        get { return curAmmo; }
        set { if (maxAmmo <= value) curAmmo = value; }
    }
    public uint curHp
    {
        get { return curHp; }
        set { if (value <= characterInfo.stat.maxHp) curHp = value; }
    }
    public uint curShield
    {
        get { return curShield; }
        set { if (value <= characterInfo.stat.shield) curHp = value; }
    }
    
    public float attDelay
    {
        get { return attDelay; }
    }


    //Unity Functions
    protected void Start()
    {
        curHp = characterInfo.stat.maxHp;
        curShield = 0;
        curAmmo = maxAmmo;
    }
}
