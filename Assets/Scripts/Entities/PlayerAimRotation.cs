using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;

    //바라보는 방향이 필요
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        //마우스 움직임 구독(OnAim) -> OnAim 실행(마우스를 바라보는 방향은 이미 받음)
        //->OnAim에서 RotateArm를 호출해 실제로 활 방향을 전환
        controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        //아크 탄젠트를 구하는 공식
        //아크 탄젠트 : 어떤 벡터가 있다고 했을 때 벡터의 각도를 구함
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //스프라이트 랜더러의 y축을 기준으로 뒤집는 코드 // Mathf.Abs 절댓값
        armRenderer.flipY = Mathf.Abs(rotz) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        //Quaternion.Euler : 그냥 로테이션 값을 쓰기 쉽게 만든다고 보면 됨
        armPivot.rotation = Quaternion.Euler(0, 0, rotz);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
