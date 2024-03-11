using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Weapon;

    private IAttack _iAttack;

    private void Start()
    {
        _iAttack = Weapon.GetComponent<IAttack>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            _iAttack.Attack();
        }
    }
}
