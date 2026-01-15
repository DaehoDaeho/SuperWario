using UnityEngine;

public class TestCode : MonoBehaviour
{
    string characterName = "Hero";
    int characterLevel = 1;
    float moveSpeed = 5.5f;
    bool isPlayerAlive = true;

    // 공격력, 방어력, 성별, 나이, 출신지.
    float attackPower = 10.0f;
    float defensePower = 5.0f;
    int gender = 0;
    int age = 10;
    string born = "중간계";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Name = " + characterName);
        Debug.Log("Level = " + characterLevel);
        Debug.Log("Speed = " + moveSpeed);
        Debug.Log("Alive = " + isPlayerAlive);

        characterLevel = 2;
        moveSpeed = 7.0f;
        isPlayerAlive = false;

        Debug.Log("Level = " + characterLevel);
        Debug.Log("Speed = " + moveSpeed);
        Debug.Log("Alive = " + isPlayerAlive);

        Debug.Log("공격력 = " + attackPower);
        Debug.Log("방어력 = " + defensePower);
        Debug.Log("성별 = " + gender);
        Debug.Log("나이 = " + age);
        Debug.Log("출신지 = " + born);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
