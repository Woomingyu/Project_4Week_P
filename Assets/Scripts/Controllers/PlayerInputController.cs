using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Move�� Look�� ���� event�� �ɾ���� TDCC�� ��ӹ޴´�.

//TopDownCharacterController �ȿ��� OnMoveEvent OnLookEvent...�̺�Ʈ���� �����Ѵ�.
//��򰡿��� '�� ~~(OnMoveEvent)�� �� �˷���' ��� �ش� �̺�Ʈ�� ���� �ɾ���´�.
//�̸� �����Ѵ� ��� �Ѵ�.
public class PlayerInputController : CharacterController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }


    //�׼ǵ��� ����Ǿ��� �� �����޴� �Լ���
    public void OnMove(InputValue value)
    {
        //normalized �ϴ� ����? �� ������ �ѹ��� ������ ���
        //1���� ū���� �����Ƿ� ���� ���ͷ� ����� �ƹ��� �� 1�̵���
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        //CallMoveEvent�� OnMoveEvent�� ȣ���ϰ� �Ǵµ�,
        //���⿡ �������ִ� �ֵ��� �� �ְԵȴ�??????? �̰� �����Ҹ���
        //*
        //Ű���� �Է��� �ϸ� OnMoveEvent�� ����� �ֵ� ���ο��� �� ������ ��������.
        //�̵��� ���ϴ� ��Ȳ�� ��ó���� ??
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>(); //���콺 ��ǥ
        //�̶� �׳� ���콺 ��ǥ�� ��ũ�� ��ǥ�ϱ� ���� ��ǥ(�÷��� ȭ��) ��ǥ�� �ٲ������
        Vector2 wordPos = camera.ScreenToWorldPoint(newAim);

        //���콺 ���� ��ǥ���� - �÷��̾� ������(��ũ��Ʈ ���� ��ü) �ϸ� 
        //ĳ���Ϳ� ���콺�� �̾��ִ� �Ÿ��� ����(�÷��̾�->���콺)���͸� ������.
        //�̸� nomalized �ϸ�??? 
        newAim = (wordPos - (Vector2)transform.position).normalized;

        //nomalized�ϸ� 1�̹Ƿ� ��ǻ� 1 >= .9f (??�� .9f���� �𸣰���)
        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }

    }

    public void OnFire(InputValue value)
    {
        //���콺 Ŭ�� -> TopDownCharacterController.cs����
        //HandleAttackDelay()���� -> IsAttackting�� ���̸� -> ���� �����ض� ���?
        //-> TopDownShooting����
        //���� ���� : ��ǲ���� �̺�Ʈ�� call�ϸ� ������ �ֵ����� ��ȣ�� �� �ش�.
        IsAttacking = value.isPressed; //���콺 ��ư Ŭ��?
    }

    public void OnJump(InputValue value)
    {        
        CallJumpEvent();
    }
}
