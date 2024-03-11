using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _invulnerabilityTime;
    [SerializeField] private int _health = 100;

    private bool _invulnerability;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void GetDamage(int damage = 1)
    {
        if (!_invulnerability)
        {
            _health -= damage;
            StartCoroutine(GetingDamage());

        }
    }

    private IEnumerator GetingDamage()
    {
        _invulnerability = true;
        var time = new WaitForSeconds(_invulnerabilityTime);
        for (int i = 0; i < 5; i++)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
            yield return time;
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 255);
            yield return time;
        }
        _invulnerability = false;
    }
}
