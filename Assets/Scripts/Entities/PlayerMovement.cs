using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 movementDirection = Vector2.zero;
    private Rigidbody2D rigidbody;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpDistance;
    private void Awake()
    {
        //�÷��̾�� PlayerInputController�� �ְ� TopDownCharacterController�� �θ�� ����
        //�׷��� �÷��̾���� �������� TopDownCharacterController ȣ�Ⱑ��
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move; //OnMoveEvent�� ����(ȣ�� �� ���� �޴� �޼��� �߰�)
        //Ű���� ���� -> PlayerInputController -> �θ��� TopDownCharacterController�� ����
        //TopDownCharacterController�� �����ϰ��ִ� TopDownMovement�� �����
        controller.OnJumpEvent += Jump;
    }

    //���� ó���� ���� ���Ŀ� ȣ��
    private void FixedUpdate()
    {
        ApplyMovment(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    //���� �̵�
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * playerSpeed;

        //���ӵ��� �޾� rigidbody �̵�
        rigidbody.velocity = direction;
    }

    //���� �̵�
    private void Jump()
    {
        Debug.Log("W �Է�");
        //rigidbody.velocity = new Vector2(rigidbody.velocity.y, jumpDistance);
    }
}
