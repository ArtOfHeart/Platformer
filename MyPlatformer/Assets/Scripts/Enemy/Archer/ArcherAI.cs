using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherAI : MonoBehaviour, IAi
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PoolArrow _poolArrow;
    [SerializeField] private float _archeryCoolDownTime;
    [SerializeField] private Transform _pointForArrow;
    [SerializeField] private Transform _pointForArrowLow;

    private bool _archeryCoolDown;

    public float DistanseToPlayer { get; private set; }
    public float HeightToPlayer { get; private set; }
    public bool archery { get; private set; }
    public bool ArcheryLow { get; private set; }
    void Update()
    {
        CheckPlayerPosition();
        Archery();
    }


    private void CheckPlayerPosition()
    {
        DistanseToPlayer = transform.position.x - _player.transform.position.x;
        HeightToPlayer = transform.position.y - _player.transform.position.y;
        UpdateLook();
    }

    private void UpdateLook()
    {
        transform.localScale = new Vector2(Mathf.Sign(DistanseToPlayer), 1);
    }
    private void Archery()
    {
        if (Mathf.Abs(DistanseToPlayer) <= 11 && Mathf.Abs(DistanseToPlayer) > 2  && !_archeryCoolDown)
        {
            _poolArrow.SetPointForArrow(HeightToPlayer > 5 ? _pointForArrowLow : _pointForArrow);
            StartCoroutine(CoolDownArchery());
            _archeryCoolDown = true;
            if (HeightToPlayer > 5)
            {
                ArcheryLow = true;
                return;
            }
            archery = true;
        }
        else
        {
            ArcheryLow = false;
            archery = false;
        }
    }

    private IEnumerator CoolDownArchery()
    {
        yield return new WaitForSeconds(0.34f);
        _poolArrow.CreatedArrow(DistanseToPlayer, HeightToPlayer);
        yield return new WaitForSeconds(_archeryCoolDownTime);
        _archeryCoolDown = false;
    }

    public void Shutdown(bool shutdown)
    {
        this.GetComponent<ArcherAI>().enabled = shutdown;
    }
}
