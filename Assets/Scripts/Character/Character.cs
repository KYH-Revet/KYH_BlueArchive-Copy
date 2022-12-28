using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;

public abstract class Character : MonoBehaviour
{
    protected Character_Info character_Info;

    protected abstract void SetBasicStat();
}
