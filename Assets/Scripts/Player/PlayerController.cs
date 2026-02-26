using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float accel = 1.5f;

    public float jumpPower = 10.0f;
    public Rigidbody2D rb;

    public Animator anim;

    public SpriteRenderer spriteRenderer;

    public Transform groundCheck;   // 지면 체크를 위해 레이캐스트를 수행할 중심위치.
    public float rayLength = 0.2f;  // 지면으로 쏠 광선의 길이.
    public LayerMask groundLayer;   // 지면 오브젝트만 체크하기 위한 레이어.

    public AudioClip audioJump;

    // 플레이어가 지면에 착지해 있는지 여부를 저장할 변수.
    bool isGrounded = false;

    float h = 0.0f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckGround();

        // 좌우 방향키나 A, D 키를 눌렀을 때의 입력값을 반환받는다. (-1.0 ~ 1.0)
        h = Input.GetAxis("Horizontal");

        // GetKey : 키보드의 특정 키가 눌린 상태인지를 체크하는 함수.
        // GetKeyDown : 키보드의 특정 키가 한 번 눌렸는지를 체크하는 함수.
        // GetKeyUp : 키보드의 특정 키를 눌렀다가 뗐는지를 체크하는 함수.
        bool isLeftCtrl = Input.GetKey(KeyCode.LeftControl);
        if (isLeftCtrl == true)
        {
            accel = 1.5f;
        }
        else
        {
            accel = 1.0f;
        }

        // 스페이스 키를 누르면 위쪽 방향으로 순간적인 힘을 가한다.
        // 현재 지면 위에 서 있는지 여부를 같이 체크한다.
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            AudioManager.instance.PlaySFX(audioJump);
        }

        // 방향 키를 눌렀으면 Run 애니메이션으로 전환. 누르지 않았으면 Idle 애니메이션으로 전환.
        if(h != 0.0f)
        {
            anim.SetBool("isRun", true);
        }
        else if(h == 0.0f)
        {
            anim.SetBool("isRun", false);
        }

        if(h > 0.0f)
        {
            spriteRenderer.flipX = false;
        }
        else if(h < 0.0f)
        {
            spriteRenderer.flipX = true;
        }

        anim.SetBool("isGrounded", isGrounded);
    }

    // 물리 기반 이동 처리를 할 때 이 함수에서 하는 것이 좋다.
    void FixedUpdate()
    {
        // Rigidbody2D의 속도를 변경해서 오브젝트를 이동시킨다.
        rb.linearVelocity = new Vector2(h * speed * accel, rb.linearVelocity.y);
    }

    /// <summary>
    /// 플레이어가 지면에 있는지 체크하는 함수.
    /// </summary>
    /// <returns>지면에 있는지 여부</returns>
    bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLength, groundLayer);
        if(hit.collider != null)
        {
            return true;
        }

        return false;
    }


    /// <summary>
    /// Collider2D가 부착된 오브젝트끼리 충돌했을 때 유니티가 자동으로 호출해주는 함수.
    /// </summary>
    /// <param name="collision">충돌한 대상의 각종 정보</param>
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // CompareTag : 게임 오브젝트의 태그 정보를 비교해주는 함수.
    //    if (collision.gameObject.CompareTag("Ground") == true)
    //    {
    //        isGrounded = true;
    //        Debug.Log("땅에 닿았습니다.");
    //    }
    //}

    /// <summary>
    /// 충돌했던 오브젝트가 떨어졌을 때 유니티가 자동으로 호출해주는 함수.
    /// </summary>
    /// <param name="collision">떨어진 대상의 각종 정보</param>
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") == true)
    //    {
    //        isGrounded = false;
    //        Debug.Log("땅에서 떨어졌습니다.");
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + (Vector3.down * rayLength));
    }
}
