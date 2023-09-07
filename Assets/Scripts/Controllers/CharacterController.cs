using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;

public class CharacterController : MonoBehaviour
{
    //event �ܺο����� ȣ������ ���ϰ� ���´�.
    //Action : ���߿� ã�ƺ���* �Լ��� ��� => ��ϵ� �Լ��� ��� ȣ��
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    public event Action OnJumpEvent;

    private float tiemSinceLastAttack = float.MaxValue;

    //Attack�� ���� ������Ƽ //������Ƽ == ���� | ���������� ��������
    protected bool IsAttacking { get; set; }

    //�̵�
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ���� ������ null�� �ƴҶ��� �۵� Invoke == �Լ�ȣ��
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }


    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }

    //������Ʈ�� Ŭ�������� ���� ���̴� �������̵��ؼ� �� �� �ֵ��� �ؾ���
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        //������
        if(tiemSinceLastAttack <= 0.2f) //TODO
        {
            tiemSinceLastAttack += Time.deltaTime;
        }

        if(IsAttacking && tiemSinceLastAttack > 0.2f)
        {
            tiemSinceLastAttack = 0;
            CallAttackEvent();
        }
    }

}
