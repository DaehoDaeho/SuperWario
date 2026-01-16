using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 미션 1
        for(int i = 1; i <= 9; i++)
        {
            int result = 9 * i;
            Debug.Log("9 * " + i + " = " + result);
        }

        // 미션 2
        for(int i = 10; i >= 1; i--)
        {
            Debug.Log("i = " + i);
        }

        // 미션 3
        for (int i = 1; i <= 10; i++)
        {
            if(i % 2 == 0)
            {
                Debug.Log("i = " + i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
