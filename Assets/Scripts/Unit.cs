using UnityEngine;

public class Unit
{
    public string unitName;
    public int currentHp;
    public int attackPower;

    // 생성자. 클래스 이름과 똑같은 이름의 함수.
    public Unit(string name, int hp, int power)
    {
        unitName = name;
        currentHp = hp;
        attackPower = power;
    }

    public void TakeDamage(int damage)
    {
        currentHp = currentHp - damage;
        Debug.Log(unitName + "가(이) " + damage + " 만큼 대미지를 입었다! 남은 HP = " + currentHp);
    }

    public void Attack(Unit target)
    {
        Debug.Log(unitName + "가(이) " + target.unitName + "를(을) 공격!!");

        // 상대에게 대미지 적용.
        target.TakeDamage(attackPower);
    }

    public bool IsDead()
    {
        if(currentHp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {
        currentHp = currentHp + amount;
        Debug.Log(unitName + "가(이) " + amount + "만큼의 체력을 회복했다!!!");
    }
}
