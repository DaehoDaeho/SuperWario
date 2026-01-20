using UnityEngine;

public class MethodTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 함수를 호출한다.
        AddNumbers();

        AddNumbers(10, 5);

        int result = AddNumbers2(100, 100);
        Debug.Log(result);
    }

    void AddNumbers()
    {
        int result = 1 + 2;
        Debug.Log(result);
    }

    void AddNumbers(int aaa, int bbb)
    {
        int result = aaa + bbb;
        Debug.Log(result);
    }

    int AddNumbers2(int ccc, int ddd)
    {
        int result = ccc + ddd;
        return result;
    }
}
