using UnityEngine;

namespace _Character
{
    //Character
    public struct Character_Info
    {
        public uint no;             //고유 번호
        public string name;         //이름
        public uint lv;             //레벨
        public uint exp;            //경험치
        
        public Character_Stat stat;      //스탯

        //Stage 
        public string cityLv;       //시가지 전투력
        public string outdoorLv;    //야외 전투력
        public string insideLv;     //실내 전투력

        //Types
        public Type_Role type;
        public Type_Positioning positioning;
        public Type_Property property_att;
        public Type_Property property_def;

        //public uint star;           //N성
        //public Sprite profileImg;   //2D Image
        //public GameObject model;    //3D model
    }
    public struct Character_Stat
    {
        //Battle
        public uint maxHp;          //최대 체력
        public uint shield;         //쉴드
        public uint damage;         //공격력
        public uint defensive;      //방어력
        public uint cure;           //치유력
        public uint hitRate;        //명중력
        public uint evasionLv;      //회피 수치
        public uint criticalLv;     //치명 수치
        public uint criticaldmg;    //치명 데미지
        public uint stabillty;      //안정 수치
        public uint nomalRange;     //일반공격 사거리 
        //public uint ccRimforce;     //군중제어 강화력
        //public uint ccResistance;   //군중제어 저항력
        public uint costRecovry;    //코스트 회복력
        public bool obscuration;    //엄폐 여부
    }

    //Type Enum
    public enum Type_Class          //클래스(스트라이커, 스페셜)
    {
        Striker,
        Special
    }
    public enum Type_Role           //역할
    {
        Tank,       //탱커
        DPS,        //딜러
        Support,    //서포터
        Heal        //힐러
    }
    public enum Type_Positioning    //포지셔닝
    {
        Front,      //전방
        Middle,     //중방
        Back        //후방
    }
    public enum Type_Property       //공격/방어 속성
    {
        Explosion,  //폭발&경장갑
        Penetrate,  //관통&중장갑
        Mystery     //신비&특수장갑
    }
    public enum Type_Weapon         //무기
    { 
        HG,         //Hand Gun          (권총)
        SMG,        //Submachine Gun    (기관단총)
        AR,         //Assert Rifle      (돌격소총)
        MG,         //Machine Gun       (기관총)
        SR,         //Sniper Rifle      (저격소총)
        GL,         //Granade Launcher  (수류탄 발사기)
        RG,         //Rail Gun          (레일 건)
        RL          //Rocket Launcher   (로켓 런처)
    }

}
