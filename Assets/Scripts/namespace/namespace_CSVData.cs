using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;

namespace CSVData
{
    public struct User
    {
        public int uId;             //고유번호
        public string nickname;     //별명
        public int accountLv;      //계정 레벨
    }

    public struct User_Character
    {
        public int uId;             //유저 고유번호
        public int cId;             //캐릭터 고유번호
        public int cLv;            //캐릭터 레벨
        public int cExp;           //캐릭터 경험치
    }

    public struct Character_Info
    {
        public string name;         //이름

        public Character_Stat stat; //스탯

        //Stage 
        public string cityLv;       //시가지 전투력
        public string outdoorLv;    //야외 전투력
        public string insideLv;     //실내 전투력

        //Types
        public Type_Class tClass;
        public Type_Role tRole;
        public Type_Positioning tPositioning;
        public Type_Property tProperty_att;
        public Type_Property tProperty_def;

        //public int star;           //N성
        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}