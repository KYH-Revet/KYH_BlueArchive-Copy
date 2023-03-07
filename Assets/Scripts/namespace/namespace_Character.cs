using UnityEngine;

namespace _Character
{
    //Character    
    [System.Serializable]
    public struct Character_Stat
    {
        //Battle
        public int maxHp;          //최대 체력
        public int damage;         //공격력
        public int defensive;      //방어력
        public int cure;           //치유력
        public int hitRate;        //명중력
        public int evasionLv;      //회피 수치
        public int criticalLv;     //치명 수치
        public int criticaldmg;    //치명 데미지
        public int stabillty;      //안정 수치
        public int normalRange;    //일반공격 사거리 (증가량 X)
        public int ccRimforce;     //군중제어 강화력 (증가량 X)
        public int ccResistance;   //군중제어 저항력 (증가량 X)
        public int costRecovery;   //코스트 회복력 (증가량 X)
        
        //public bool obscuration;  //엄폐 여부 (증가량 X)
        //public uint shield;         //쉴드 (증가량 X), 스킬로만 생길거니까 Stat에 없어도됨(스크립트에 따로 추가)

        public Character_Stat(int maxHp, int damage, int defensive, int cure, int hitRate,
                                int evasionLv, int criticalLv, int criticaldmg, int stabillty, int normalRange,
                                int ccRimforce, int ccResistance, int costRecovery)
        {
            //Battle
            this.maxHp = maxHp;                 //최대 체력            
            this.damage = damage;               //공격력
            this.defensive = defensive;         //방어력
            this.cure = cure;                   //치유력
            this.hitRate =hitRate;              //명중력
            this.evasionLv = evasionLv;         //회피 수치
            this.criticalLv = criticalLv;       //치명 수치
            this.criticaldmg = criticaldmg;     //치명 데미지
            this.stabillty = stabillty;         //안정 수치
            this.normalRange = normalRange;     //일반공격 사거리
            this.ccRimforce = ccRimforce;       //군중제어 강화력
            this.ccResistance = ccResistance;   //군중제어 저항력
            this.costRecovery = costRecovery;   //코스트 회복력
            //this.obscuration = obscuration;   //엄폐 여부

            //this.shield = shield;               //쉴드
        }
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
