using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

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
        transform.position = targetPos;
    }
}
