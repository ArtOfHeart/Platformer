using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playercontroller;
    private bool _isWalk;
    private bool _isJump;
    private bool _isFall;
    private bool _isAttackSword;
 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playercontroller = GetComponent<PlayerController>();
        
    }

    private void Update()
    {
        _isWalk = Mathf.Abs(Input.GetAxis("Horizontal")) > 0? true : false;
        _animator.SetBool("IsWalk", _isWalk);

        _isJump = !_playercontroller.Grounded && _playercontroller.RigidbodyPlayer.velocity.y > 0 ? true : false;
        _animator.SetBool("IsJump", _isJump);
        
        
        _isFall = !_playercontroller.Grounded && _playercontroller.RigidbodyPlayer.velocity.y < 0 ? true : false;
        _animator.SetBool("IsFall", _isFall);
        
        _isAttackSword = PlayerStaticClass.AttackSwordPlayer ? true : false;
        _animator.SetBool("AttackSword", _isAttackSword);




    }
}
