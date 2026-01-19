using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    // 문자열 데이터를 저장할 배열 선언. 배열 변수를 선언하고 크기는 3을 할당.
    string[] weaponSlots = new string[3];

    // 문자열 데이터를 저장할 리스트 선언.
    List<string> bagItem = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("배열 연습 - 무기 슬롯");

        // 배열에 데이터 넣기.
        weaponSlots[0] = "Short Sword";
        weaponSlots[1] = "Long Bow";
        weaponSlots[2] = "Magic Staff";

        Debug.Log("현재 2번째 슬롯의 무기: " + weaponSlots[1]);
        weaponSlots[1] = "Golden Bow";
        Debug.Log("새로운 2번째 슬롯의 무기: " + weaponSlots[1]);

        for(int i=0; i<weaponSlots.Length; i++)
        {
            Debug.Log("슬롯 " + i + ": " + weaponSlots[i]);
        }

        Debug.Log("리스트 연습 - 아이템 가방");

        bagItem.Add("Potion");
        bagItem.Add("Map");
        bagItem.Add("Coin");

        Debug.Log("현재 가방의 개수: " + bagItem.Count);

        bagItem.Remove("Map");

        for(int i=0; i<bagItem.Count; i++)
        {
            Debug.Log("가방 아이템: " + bagItem[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
