using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour, IDamaging
{
    [SerializeField] private float _forse;
    [SerializeField] private float _lifeTime;

    private float _distanse;
    private float _height;
    private Rigidbody2D _rigidbody2DArrow;
    private float _direction;
    private float _startRotation;
    private float _offset;


    private void Awake()
    {
        _rigidbody2DArrow = GetComponent<Rigidbody2D>();

    }
    public void SetAngleDirection(float Distanse, float Height)
    {
        _distanse = Distanse;
        _height = Height;
    }

    private void OnEnable()
    {
        StartCoroutine(StartFlying());

    }
    private IEnumerator StartFlying()
    {
        yield return null;
        _offset = _height > 5 ? 1: 0;
        _direction = Mathf.Sign(_distanse);
        SetStartRotation();

        _rigidbody2DArrow.velocity = Vector2.zero;
        _rigidbody2DArrow.simulated = true;

        SetForse();
        _rigidbody2DArrow.AddForce(transform.right * _forse);

        yield return new WaitForSeconds(_lifeTime);

        gameObject.SetActive(false);
    }

    private void SetStartRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0 + (180 * Mathf.Clamp01(_distanse)) + (_offset * 45 * _direction));       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponPlayer"))
        {
            _rigidbody2DArrow.velocity = Vector2.zero;
            _rigidbody2DArrow.AddForce(transform.up * _direction * UnityEngine.Random.Range(380, 500));
            return;
        }
        if (collision.CompareTag("Player"))
        {
            CauseDamage(collision);
            return;
        }

        Invoke("GetStuck", 0.02f);
    }

    private void GetStuck()
    {
        _rigidbody2DArrow.simulated = false;
    }

    private void Update()
    {
        AngleFlying();
    }


    private void AngleFlying()
    {
        float AngleZ = _direction > 0 ? Vector3.Angle(_rigidbody2DArrow.velocity, Vector3.left) + 180 : -Vector3.Angle(_rigidbody2DArrow.velocity, Vector3.right) - 360;
        transform.rotation = Quaternion.Euler(0, 0, AngleZ);
    }

    private void SetForse()
    {
        _forse = 150 * Mathf.Abs(_distanse);
    }

    public void CauseDamage(Collider2D collision = null)
    {
        collision.gameObject.TryGetComponent(out IDamageable health);
        health?.GetDamage();
    }

}
