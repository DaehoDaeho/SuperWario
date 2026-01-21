using System.ComponentModel;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    int currentHp = 50;
    int attackPower = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("게임 시작!!!!");

        SayHello();

        Heal(30);

        Heal(10);

        int finalDamage = CalculateDamage(attackPower, 2);

        Debug.Log("크리티컬!!! 최종 대미지: " + finalDamage);

        Levelup();
    }

    void SayHello()
    {
        Debug.Log("나는 싸울 준비가 됐다!!!!");
    }

    void Heal(int amount)
    {
        currentHp = currentHp + amount;
        Debug.Log("체력을 " + amount + "만큼 회복!!! 현재 HP = " + currentHp);

        if(currentHp > 100)
        {
            currentHp = 100;
            Debug.Log("체력 만땅!!!");
        }
    }

    int CalculateDamage(int damage, int multiplier)
    {
        int result = damage * multiplier;
        return result;
    }

    void Levelup()
    {
        Debug.Log("레벨 업!!!!!");
        attackPower = attackPower + 5;
    }

    int AddNumbers(int number1, int number2)
    {
        int result = number1 + number2;
        return result;
    }

    int SubNumbers(int number1, int number2)
    {
        int result = number1 - number2;
        return result;
    }

    int MulNumbers(int number1, int number2)
    {
        int result = number1 * number2;
        return result;
    }

    int DivNumbers(int number1, int number2)
    {
        int result = number1 / number2;
        return result;
    }

    int ModNumbers(int number1, int number2)
    {
        int result = number1 % number2;
        return result;
    }

    float AddNumbers(float number1, float number2)
    {
        float result = number1 + number2;
        return result;
    }
}
