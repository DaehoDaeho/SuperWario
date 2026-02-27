using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip audioCoin;

    /// <summary>
    /// Trigger가 켜진 오브젝트와 겹쳤을 때 호출되는 함수.
    /// </summary>
    /// <param name="other">충돌한 대상의 정보</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 플레이어가 맞는지 확인.
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("동전 획득!!!");
            GameManager.instance.AddScore(100);
            GameManager.instance.AddCoinCount(1);
            AudioManager.instance.PlaySFX(audioCoin);
            
            Destroy(gameObject);
        }
    }
}
