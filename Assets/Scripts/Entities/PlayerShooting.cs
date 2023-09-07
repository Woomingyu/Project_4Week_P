using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private Transform projectileSpawnposition;

    //Vector2.right ���͸� ��� ������ ���� �����ض�
    private Vector2 aimDirection = Vector2.right;

    public GameObject testPrefab;

    //Awake���� ������Ʈ�� ��������
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    //�Ѿ��� ���ư� ����
    private void OnAim(Vector2 newAimDirection)
    {
        aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        Createprojectile();
    }


    private void Createprojectile()
    {
        Instantiate(testPrefab, projectileSpawnposition.position,Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
