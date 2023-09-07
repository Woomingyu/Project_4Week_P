using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Move와 Look에 대한 event만 걸어놓은 TDCC를 상속받는다.

//TopDownCharacterController 안에는 OnMoveEvent OnLookEvent...이벤트들이 존재한다.
//어딘가에서 '나 ~~(OnMoveEvent)할 때 알려줘' 라고 해당 이벤트에 줄을 걸어놓는다.
//이를 구독한다 라고 한다.
public class PlayerInputController : CharacterController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }


    //액션들이 실행되었을 때 돌려받는 함수들
    public void OnMove(InputValue value)
    {
        //normalized 하는 이유? 두 방향을 한번에 누르는 경우
        //1보다 큰값이 나오므로 단위 백터로 만들어 아무리 길어도 1이도록
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        //CallMoveEvent가 OnMoveEvent를 호출하게 되는데,
        //여기에 구독해있는 애들은 다 주게된다??????? 이게 무슨소리야
        //*
        //키보드 입력을 하면 OnMoveEvent와 연결된 애들 전부에게 그 정보가 전해진다.
        //이동을 안하는 상황에 대처가능 ??
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>(); //마우스 좌표
        //이때 그냥 마우스 좌표는 스크린 좌표니까 월드 좌표(플레이 화면) 좌표로 바꿔줘야함
        Vector2 wordPos = camera.ScreenToWorldPoint(newAim);

        //마우스 월드 좌표에서 - 플레이어 포지션(스크립트 부착 객체) 하면 
        //캐릭터와 마우스를 이어주는 거리와 방향(플레이어->마우스)백터를 가진다.
        //이를 nomalized 하면??? 
        newAim = (wordPos - (Vector2)transform.position).normalized;

        //nomalized하면 1이므로 사실상 1 >= .9f (??왜 .9f인지 모르겠음)
        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }

    }

    public void OnFire(InputValue value)
    {
        //마우스 클릭 -> TopDownCharacterController.cs에서
        //HandleAttackDelay()실행 -> IsAttackting이 참이면 -> 공격 실행해라 어디서?
        //-> TopDownShooting에서
        //최종 정리 : 인풋에서 이벤트를 call하면 구독된 애들한테 신호를 다 준다.
        IsAttacking = value.isPressed; //마우스 버튼 클릭?
    }

    public void OnJump(InputValue value)
    {        
        CallJumpEvent();
    }
}
