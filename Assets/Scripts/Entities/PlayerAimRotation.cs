using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;

    //�ٶ󺸴� ������ �ʿ�
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        //���콺 ������ ����(OnAim) -> OnAim ����(���콺�� �ٶ󺸴� ������ �̹� ����)
        //->OnAim���� RotateArm�� ȣ���� ������ Ȱ ������ ��ȯ
        controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        //��ũ ź��Ʈ�� ���ϴ� ����
        //��ũ ź��Ʈ : � ���Ͱ� �ִٰ� ���� �� ������ ������ ����
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //��������Ʈ �������� y���� �������� ������ �ڵ� // Mathf.Abs ����
        armRenderer.flipY = Mathf.Abs(rotz) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        //Quaternion.Euler : �׳� �����̼� ���� ���� ���� ����ٰ� ���� ��
        armPivot.rotation = Quaternion.Euler(0, 0, rotz);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
