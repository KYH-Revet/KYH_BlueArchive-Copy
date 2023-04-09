using UnityEngine;

namespace _Character
{
    //Character    
    [System.Serializable]
    public struct Character_Stat
    {
        //Battle
        public int maxHp;          //�ִ� ü��       (Lv�� ������ O, �����ۿ� ���� ������ O)
        public int damage;         //���ݷ�          (Lv�� ������ O, �����ۿ� ���� ������ O)
        public int defensive;      //����          (Lv�� ������ O, �����ۿ� ���� ������ O)
        public int cure;           //ġ����          (Lv�� ������ O, �����ۿ� ���� ������ O)
        public int hitRate;        //���߷�          (�����ۿ� ���� ������ O)
        public int evasionLv;      //ȸ�� ��ġ       (�����ۿ� ���� ������ O)
        public int criticalLv;     //ġ�� ��ġ       (�����ۿ� ���� ������ O)
        public int criticaldmg;    //ġ�� ������     (�����ۿ� ���� ������ O)
        public int stabillty;      //���� ��ġ       (�����ۿ� ���� ������ O)
        public int normalRange;    //�Ϲݰ��� ��Ÿ� (������ X)
        public int ccRimforce;     //�������� ��ȭ�� (������ X)
        public int ccResistance;   //�������� ���׷� (������ X)
        public int costRecovery;   //�ڽ�Ʈ ȸ����   (������ X)
        
        //public bool obscuration;  //���� ���� (������ X)
        //public uint shield;         //���� (������ X), ��ų�θ� ����Ŵϱ� Stat�� �����(��ũ��Ʈ�� ���� �߰�)

        public Character_Stat(int maxHp, int damage, int defensive, int cure, int hitRate,
                                int evasionLv, int criticalLv, int criticaldmg, int stabillty, int normalRange,
                                int ccRimforce, int ccResistance, int costRecovery)
        {
            //Battle
            this.maxHp = maxHp;                 //�ִ� ü��            
            this.damage = damage;               //���ݷ�
            this.defensive = defensive;         //����
            this.cure = cure;                   //ġ����
            this.hitRate =hitRate;              //���߷�
            this.evasionLv = evasionLv;         //ȸ�� ��ġ
            this.criticalLv = criticalLv;       //ġ�� ��ġ
            this.criticaldmg = criticaldmg;     //ġ�� ������
            this.stabillty = stabillty;         //���� ��ġ
            this.normalRange = normalRange;     //�Ϲݰ��� ��Ÿ�
            this.ccRimforce = ccRimforce;       //�������� ��ȭ��
            this.ccResistance = ccResistance;   //�������� ���׷�
            this.costRecovery = costRecovery;   //�ڽ�Ʈ ȸ����
            //this.obscuration = obscuration;   //���� ����

            //this.shield = shield;               //����
        }
    }

    //Type Enum
    public enum Type_Class          //Ŭ����(��Ʈ����Ŀ, �����)
    {
        Striker,
        Special
    }
    public enum Type_Role           //����
    {
        Tank,       //��Ŀ
        DPS,        //����
        Support,    //������
        Heal        //����
    }
    public enum Type_Positioning    //�����Ŵ�
    {
        Front,      //����
        Middle,     //�߹�
        Back        //�Ĺ�
    }
    public enum Type_Property       //����/��� �Ӽ�
    {
        Explosion,  //����&���尩
        Penetrate,  //����&���尩
        Mystery     //�ź�&Ư���尩
    }
    public enum Type_Weapon         //����
    { 
        HG,         //Hand Gun          (����)
        SMG,        //Submachine Gun    (�������)
        AR,         //Assert Rifle      (���ݼ���)
        MG,         //Machine Gun       (�����)
        SR,         //Sniper Rifle      (���ݼ���)
        GL,         //Granade Launcher  (����ź �߻��)
        RG,         //Rail Gun          (���� ��)
        RL          //Rocket Launcher   (���� ��ó)
    }
}
