using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 5.0f;

    float accel = 1.5f;

    float h = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector3.zero;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 방향키나 A, D 키를 눌렀을 때의 입력값을 반환받는다. (-1.0 ~ 1.0)
        h = Input.GetAxis("Horizontal");

        // GetKey : 키보드의 특정 키가 눌린 상태인지를 체크하는 함수.
        // GetKeyDown : 키보드의 특정 키가 한 번 눌렸는지를 체크하는 함수.
        // GetKeyUp : 키보드의 특정 키를 눌렀다가 뗐는지를 체크하는 함수.
        bool isLeftCtrl = Input.GetKey(KeyCode.LeftControl);
        if(isLeftCtrl == true)
        {
            accel = 1.5f;
        }
        else
        {
            accel = 1.0f;
        }
    }

    // 물리 기반 이동 처리를 할 때 이 함수에서 하는 것이 좋다.
    void FixedUpdate()
    {
        // Rigidbody2D의 속도를 변경해서 오브젝트를 이동시킨다.
        rb.linearVelocity = new Vector2(h * speed * accel, rb.linearVelocity.y);
    }
}
