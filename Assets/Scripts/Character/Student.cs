using _Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Character
{
    [Header("Variable for battle")]
    public uint maxAmmo = 10;
    public uint curAmmo;
    public uint curHp;
    public uint curShield;

    public float attDelay;

    //Unity Functions
    protected override void Start()
    {
        base.Start();
        curHp = 0;
        curShield = 0;
        curAmmo = maxAmmo;
    }
}
