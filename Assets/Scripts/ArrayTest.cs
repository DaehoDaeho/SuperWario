using UnityEngine; // 네임 스페이스(이름 공간)
using System.Collections.Generic;

public class ArrayTest : MonoBehaviour
{
    int[] arrays;
    int[,] arrays2;

    List<int> lists;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrays = new int[100];
        arrays[0] = 10;
        arrays[99] = 1;

        Debug.Log(arrays[49]);

        arrays2 = new int[4, 4];
        arrays2[3, 3] = 5;

        lists = new List<int>();
        lists.Add(5);
        lists.Add(10);
        lists.Add(15);

        Debug.Log(lists[0]);
        Debug.Log(lists[2]);

        lists.Remove(15);
        lists.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
