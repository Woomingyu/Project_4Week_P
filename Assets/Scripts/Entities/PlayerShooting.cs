using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private Transform projectileSpawnposition;

    //Vector2.right 벡터를 계속 만들지 말고 재사용해라
    private Vector2 aimDirection = Vector2.right;

    public GameObject testPrefab;

    //Awake에서 컴포넌트를 가져오고
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    //총알이 날아갈 방향
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
