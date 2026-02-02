using UnityEngine;

public class LifecycleTest : MonoBehaviour
{
    int frameCount = 0;

    private void Awake()
    {
        Debug.Log("1. Awake 기상!!!! 데이터 준비 중...");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("2. Start 준비 완료!!! 전투 준비 태세.");
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;

        // 60 프레임마다 frameCount 값을 출력
        if(frameCount % 60 == 0)
        {
            Debug.Log("3. Update 게임이 돌아가는 중... frame = " + frameCount);
        }
    }
}
