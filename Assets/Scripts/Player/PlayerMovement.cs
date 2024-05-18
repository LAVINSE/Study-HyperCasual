using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region ����
    [SerializeField] VariableJoystick joystick;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigid;
    private Vector3 moveVecter;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    /** �ʱ�ȭ => ���¸� �����Ѵ� */
    private void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        // �̵� ���� ���, �̵��ӵ��� �ð� ��
        moveVecter = new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;
        // ���� ��ġ���� �̵� ���͸�ŭ �̵�
        rigid.MovePosition(rigid.position + moveVecter);

        // �̵� ���Ͱ� 0�̸� X
        if(moveVecter.sqrMagnitude == 0) { return; }

        // �̵� �������� ȸ�� ���
        Quaternion directionQuaternion = Quaternion.LookRotation(moveVecter);
        // �ε巯�� ȸ��
        Quaternion moveQuaternion = Quaternion.Slerp(rigid.rotation, directionQuaternion, 0.3f);
        // ���� ȸ��
        rigid.MoveRotation(moveQuaternion);
    }
    #endregion // �Լ�
}
