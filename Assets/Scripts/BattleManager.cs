using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Unit hero;
    public Unit demon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 유니티가 자동으로 호출해 주는 함수.
    // 게임이 시작되면 자동으로 한 번 호출.
    void Start()
    {
        Debug.Log("전투 시뮬레이터 초기화");

        hero = new Unit("Hero", 100, 20);
        demon = new Unit("Demon King", 300, 10);

        Debug.Log("마왕 " + demon.unitName + "가(이) 나타났다!!!");
    }

    // Update is called once per frame
    // 유니티가 자동으로 호출해 주는 함수.
    // 매 프레임마다 호출.
    void Update()
    {
        // 키보드의 스페이스 키를 눌렀는지 체크. 
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            // 영웅과 마왕이 둘 다 살아있는지 먼저 체크.
            if(hero.IsDead() == false && demon.IsDead() == false)
            {
                // 전투 실행.
                ProcessTurn();
            }
            else
            {
                Debug.Log("전투는 이미 끝났어!!!!");
            }
        }

        if(Input.GetKeyDown(KeyCode.H) == true)
        {
            hero.Heal(50);
        }
    }

    /// <summary>
    /// 한 턴의 전투 진행.
    /// </summary>
    void ProcessTurn()
    {
        Debug.Log("턴 시작!!!");

        // 영웅 공격!! 마왕을 매개변수로 전달.
        hero.Attack(demon);

        if(demon.IsDead() == true)
        {
            Debug.Log("승리!!!! " + demon.unitName + " 을(를) 물리쳤다!!");
            return; // 함수 밖으로 빠져나감. 더 이상 전투를 할 필요가 없으므로.
        }

        // 마왕 공격!! 영웅을 매개변수로 전달.
        demon.Attack(hero);

        if(hero.IsDead() == true)
        {
            Debug.Log("꾸에에엑!!!");
            Debug.Log("게임 오버!! " + hero.unitName + " 사망~~~");
        }

        Debug.Log("턴 종료!!!!");
    }
}
