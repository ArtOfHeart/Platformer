using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour , IAttack , IDamaging
{
    [SerializeField] private SpriteRenderer _spriteRendererPlayer;
    [SerializeField] private float _attackDuration;
    [SerializeField] private float _attackDelay;

    private Transform _transform;
    private BoxCollider2D _boxCollider;
    public void Attack()
    {
        StartCoroutine(BeginCharge());
    }

    private IEnumerator BeginCharge()
    {
         PlayerStaticClass.AttackSwordPlayer = true;
        yield return new WaitForSeconds(_attackDelay);
        _boxCollider.enabled = true;
        yield return new WaitForSeconds(_attackDuration);
        _boxCollider.enabled = false;
        PlayerStaticClass.AttackSwordPlayer = false;
    }

    void Start()
    {
        _transform = transform;
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        FlipXColliderSword();
    }

    private void FlipXColliderSword()
    {
        _transform.localScale = _spriteRendererPlayer.flipX ? new Vector2(-1,1) : new Vector2(1,1);    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            CauseDamage(collision);
        }
    }
    public void CauseDamage(Collider2D collision = null)
    {
        collision.gameObject.TryGetComponent(out IDamageable health);
        health?.GetDamage();
    }
}
