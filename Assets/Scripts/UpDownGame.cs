using UnityEngine;

public class UpDownGame : MonoBehaviour
{
    int targetNumber;   // 컴퓨터가 뽑은 숫자를 저장할 변수.

    int guessNumber = 50;    // 플레이어가 선택한 숫자.

    int tryCount = 0;   // 시도한 회수.

    bool isGameClear = false;   // 게임 클리어 여부.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 무작위로 숫자 뽑기. 1부터 100 사이의 숫자 하나를 뽑는다.
        targetNumber = Random.Range(1, 101);

        Debug.Log("Up & Down 게임 시작!!!!");
        Debug.Log("1부터 100 사이의 숫자를 선택해라!");
        Debug.Log("상하 방향키로 숫자를 추리하고, 스페이스 키로 답을 제출해라!");
    }

    // Update is called once per frame
    void Update()
    {
        // 게임이 이미 클리어 상태면 진행하지 않음.
        if(isGameClear == true)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            guessNumber = guessNumber + 1;

            if(guessNumber > 100)
            {
                guessNumber = 100;
            }

            Debug.Log("내가 선택한 숫자 = " + guessNumber);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            guessNumber = guessNumber - 1;

            if (guessNumber < 1)
            {
                guessNumber = 1;
            }

            Debug.Log("내가 선택한 숫자 = " + guessNumber);
        }

        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            CheckAnswer();
        }
    }

    /// <summary>
    /// 정답 확인.
    /// </summary>
    void CheckAnswer()
    {
        // 시도 회수 증가.
        tryCount = tryCount + 1;

        Debug.Log("시도 회수 = " + tryCount + ", 내가 생각한 숫자 = " + guessNumber);

        if(guessNumber == targetNumber)
        {
            Debug.Log("정답!!! 답은 바로 " + targetNumber);
            Debug.Log("너의 승리!!! " + tryCount + "번 만에 해냈어!!!");
            isGameClear = true;
        }
        else if(guessNumber < targetNumber)
        {
            Debug.Log("네가 생각한 숫자보다 크다!!");
        }
        else if(guessNumber > targetNumber)
        {
            Debug.Log("네가 생각한 숫자보다 작다!!");
        }
    }
}
