using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;   // 공격 중심점.
    public float attackRange = 0.5f;    // 공격 반경.

    public LayerMask enemyLayer;    // 공격 대상 레이어.

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) == true)
        {
            Attack();
        }
    }

    /// <summary>
    /// 공격 애니메이션 실행 함수.
    /// </summary>
    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    /// <summary>
    /// 실제 대미지를 주는 함수. (애니메이션 이벤트로 호출됨)
    /// </summary>
    public void DealDamage()
    {
        // 공격 범위 안에 있는 모든 적 감지.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        for(int i=0; i<hitEnemies.Length; ++i)
        {
            EnemyHealth enemyHealth = hitEnemies[i].GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}
