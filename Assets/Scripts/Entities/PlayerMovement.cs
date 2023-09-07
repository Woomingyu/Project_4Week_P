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
        //플레이어에는 PlayerInputController가 있고 TopDownCharacterController를 부모로 가짐
        //그래서 플레이어에서도 문제없이 TopDownCharacterController 호출가능
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move; //OnMoveEvent에 구독(호출 시 정보 받는 메서드 추가)
        //키보드 누름 -> PlayerInputController -> 부모인 TopDownCharacterController에 전달
        //TopDownCharacterController에 구독하고있는 TopDownMovement가 실행됨
        controller.OnJumpEvent += Jump;
    }

    //물리 처리가 끝난 이후에 호출
    private void FixedUpdate()
    {
        ApplyMovment(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    //실제 이동
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * playerSpeed;

        //가속도를 받아 rigidbody 이동
        rigidbody.velocity = direction;
    }

    //실제 이동
    private void Jump()
    {
        Debug.Log("W 입력");
        //rigidbody.velocity = new Vector2(rigidbody.velocity.y, jumpDistance);
    }
}
