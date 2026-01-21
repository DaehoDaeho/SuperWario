using UnityEngine;

public class OOPTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("OOP Test Start!!!");
        Monster orc = new Monster();

        orc.monsterName = "Angry Orc";
        orc.hp = 100;
        orc.attackPower = 15;

        orc.Attack();

        Monster slime = new Monster();

        slime.monsterName = "Cute Slime";
        slime.hp = 20;
        slime.attackPower = 5;

        Debug.Log("전투 시작!!!!!");

        slime.TakeDamage(orc.attackPower);

        Debug.Log("오크의 체력 = " + orc.hp);
        Debug.Log("슬라임의 체력 = " + slime.hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
