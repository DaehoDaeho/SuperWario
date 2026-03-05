using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //public Transform posA;
    //public Transform posB;
    public Transform[] pos;
    public float speed = 2.0f;

    private Vector3 targetPos;
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        targetPos = pos[index].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.MoveTowards : 목표지점으로 오브젝트를 이동시켜주는 함수.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Vector3.Distance : 두 지점 사이의 거리를 반환해 주는 함수.
        float distance = Vector3.Distance(transform.position, targetPos);

        // 거리 값이 0,1보다 작으면 목표에 도착했다고 간주.
        if(distance < 0.1f)
        {
            // index를 하나 증가.
            // 만약 index가 배열의 마지막 순서를 가리키는 값이면
            // index를 다시 0으로 되돌리기.
            // 갱신된 index를 이용해서 목표지점을 다시 설정.
            //index++;
            //if(index == pos.Length)
            //{
            //    index = 0;
            //}

            //index = (index + 1) % pos.Length;
            index = (int)Mathf.Repeat(index + 1, pos.Length);

            targetPos = pos[index].position;

            //if(targetPos == posB.position)
            //{
            //    targetPos = posA.position;
            //}
            //else
            //{
            //    targetPos = posB.position;
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
