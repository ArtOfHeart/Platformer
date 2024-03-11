using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private Animator _animator;
    private CapsuleCollider2D _capsuleCollider;
    private IAi _ai;
    
    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _ai = GetComponent<IAi>();
    }
    public void GetDamage(int damage = 1)
    {
        _animator.SetBool("IsDeath", true);
        _capsuleCollider.enabled = false;
        _ai.Shutdown(false);
    }
}
