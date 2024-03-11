using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolArrow : MonoBehaviour
{
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private int count = 6;

    private Transform _pointForArrow;
    private PoolMonoBehavior<Arrow> pool;

    public void SetPointForArrow(Transform PointForArrow)
    {
        _pointForArrow = PointForArrow;
    }

    private void Awake()
    {
        pool = new PoolMonoBehavior<Arrow>(_arrowPrefab, count, transform);
        pool.AutoExpand = _autoExpand;
    }
    public void CreatedArrow(float DistanseToPlayer, float HeightToPlayer)
    {
        var arrow = pool.GetFreeElement();
        arrow.SetAngleDirection(DistanseToPlayer, HeightToPlayer);
        arrow.transform.position = _pointForArrow.position;
    }
}
