using UnityEngine;

namespace _Character
{
    //Character    
    public struct Character_Stat
    {
        //Battle
        public uint maxHp;          //�ִ� ü��
        public uint shield;         //����
        public uint damage;         //���ݷ�
        public uint defensive;      //����
        public uint cure;           //ġ����
        public uint hitRate;        //���߷�
        public uint evasionLv;      //ȸ�� ��ġ
        public uint criticalLv;     //ġ�� ��ġ
        public uint criticaldmg;    //ġ�� ������
        public uint stabillty;      //���� ��ġ
        public uint nomalRange;     //�Ϲݰ��� ��Ÿ�
        public uint ccRimforce;     //�������� ��ȭ��
        public uint ccResistance;   //�������� ���׷�
        public uint costRecovry;    //�ڽ�Ʈ ȸ����
        //public bool obscuration;    //���� ����
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
