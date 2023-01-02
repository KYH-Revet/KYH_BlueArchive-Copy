using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;

namespace CSVData
{
    public struct User
    {
        public uint uid;            //고유번호
        public string nickname;     //별명
        public uint accountLv;      //계정 레벨
    }

    public struct User_Character
    {
        public uint uid;            //유저 고유번호
        public uint cid;            //캐릭터 고유번호
        public uint cLv;            //캐릭터 레벨
        public uint cExp;           //캐릭터 경험치
    }

    public struct Character_Info
    {
        public uint cid;            //고유 번호
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

        //public uint star;           //N성
        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}