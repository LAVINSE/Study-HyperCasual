using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 변수
    [SerializeField] VariableJoystick joystick;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigid;
    private Vector3 moveVecter;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    /** 초기화 => 상태를 갱신한다 */
    private void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        // 이동 벡터 계산, 이동속도와 시간 곱
        moveVecter = new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;
        // 현재 위치에서 이동 벡터만큼 이동
        rigid.MovePosition(rigid.position + moveVecter);

        // 이동 벡터가 0이면 X
        if(moveVecter.sqrMagnitude == 0) { return; }

        // 이동 방향으로 회전 계산
        Quaternion directionQuaternion = Quaternion.LookRotation(moveVecter);
        // 부드러운 회전
        Quaternion moveQuaternion = Quaternion.Slerp(rigid.rotation, directionQuaternion, 0.3f);
        // 물리 회전
        rigid.MoveRotation(moveQuaternion);
    }
    #endregion // 함수
}
