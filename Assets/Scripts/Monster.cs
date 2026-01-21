using UnityEngine;

public class Monster
{
    public string monsterName;
    public int hp;
    public int attackPower;

    public void Attack()
    {
        Debug.Log(monsterName + " 공격!!! 대미지 = " + attackPower);
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        Debug.Log(monsterName + "가(이) 공격 당했다!!! " + damage + "만큼의 대미지를 받았다!!!. 현재 HP = " + hp);
    }
}
