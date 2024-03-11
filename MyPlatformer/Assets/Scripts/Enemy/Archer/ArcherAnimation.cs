using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] ArcherAI _ai;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
  
    public void Update()
    {
        _animator.SetBool("Archery", _ai.archery);
        _animator.SetBool("ArcheryLow", _ai.ArcheryLow);
    }
}
