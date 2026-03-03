using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // 흔들림 보정용 변수.
    private Vector3 shakedOffset = Vector3.zero;
    
    void LateUpdate()
    {
        // null : 없는 데이터, 아무것도 아닌 데이터.
        if(target == null)
        {
            return;
        }

        // 타겟(플레이어)의 위치 정보를 가져온다.
        Vector3 targetPos = target.position;

        // 타겟의 위치의 z 좌료를 카메라 자신의 z좌표로 갱신해 준다.(캐릭터로부터 거리를 유지하기 위해)
        targetPos.z = transform.position.z;

        // 카메라의 위치를 최종적으로 갱신.
        transform.position = targetPos + shakedOffset;
    }

    /// <summary>
    /// 카메라 흔들기 함수.
    /// </summary>
    /// <param name="duration">흔들림 지속 시간</param>
    /// <param name="magnitude">흔들림의 강도</param>
    /// <returns></returns>
    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            // Random.insideUnitcircle : 반지름이 1인 원에서 무작위르 2D 좌표를 뽑아낸다. (x, y)
            // magnitude를 곱해서 흔들림의 강도를 조절한다.
            Vector2 randomPoint = Random.insideUnitCircle * magnitude;

            shakedOffset = new Vector3(randomPoint.x, randomPoint.y, 0.0f);

            elapsed += Time.deltaTime;

            // 다음 프레임까지 대기.
            yield return null;
        }

        shakedOffset = Vector3.zero;
    }
}
