using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using System.Xml;

namespace CSVData
{
    public struct User
    {
        public string id;           //로그인 아이디
        public string password;     //로그인 비밀번호
        public int uId;             //고유번호
        public string nickname;     //별명
        public int accountLv;       //계정 레벨

        public User(string id, string password, int uId, string nickname)
        {
            this.id = id;
            this.password = password;
            this.uId = uId;
            this.nickname = nickname;
            accountLv = 1;
        }
    }

    public struct User_Character
    {
        public int cId;             //캐릭터 고유번호
        public int cLv;             //캐릭터 레벨
        public int cExp;            //캐릭터 경험치
        public bool possesion;      //소유 여부
        public int star;            //성급

        public User_Character(int cId, int cLv, int cExp, bool possesion, int star) : this()
        {
            this.cId = cId;
            this.cLv = cLv;
            this.cExp = cExp;
            this.possesion = possesion;
            if(possesion)
                this.star = star;
            else
                this.star = Dictionary_CharacterInfo.Instance().dictionary_CharacterInfo[cId].star_Basic;
        }
    }

    public struct Character_Info
    {
        public string name;         //이름
        public int star_Basic;      //기본 성급
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

        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
}