using UnityEngine;

public class MoveTest : MonoBehaviour
{
    float speed = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate : 현재 위치에서 좌표를 더해주는 유니티 함수.
        // new Vector2(x, y) : C#의 구조체 생성 (이동할 방향과 크기)
        transform.Translate(new Vector2(speed, 0.0f));

        // 만약 x 좌표가 5를 넘어가면 다시 0으로 되돌리기 (반복 이동)
        if(transform.position.x > 5.0f)
        {
            // transform.position 값을 직접 수정할 수 없도록 막아놨기 때문에
            // 새로운 벡터를 대입해서 세팅해야 한다. (이 내용은 나중에 자세히 다룰 것임)
            transform.position = new Vector2(0.0f, 0.0f);
        }
    }
}
