using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCubePool : MonoBehaviour
{
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private LCube cubePrefab;
    [SerializeField] private int count = 4;

    private PoolMonoBehavior<LCube> pool;

    private void Start()
    {
        pool = new PoolMonoBehavior<LCube>(cubePrefab, count, transform);
        pool.AutoExpand = _autoExpand;
    }

    private void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            StartCoroutine(enumerator());
        }
    }

    private IEnumerator enumerator()
    {
        CreateCube();
        yield return null;
    }

    private void CreateCube()
    {
        var rX = Random.Range(5, -5);
        var rZ = Random.Range(5, -5);
        var rY = 0;

        var rPosition = new Vector3(rX, rZ, rY);
        var Cube = pool.GetFreeElement();
        Cube.transform.position = rPosition;
    }
}
