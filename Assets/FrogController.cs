using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject Player;

    // JumpInterval
    // JumpForce
    // JumpXSpeed
    public float JumpMaxInterval;
    public float JumpMinInterval;
    public float JumpForce;
    public float JumpXSpeed;

    private float _currentInterval;


    private Transform _playerTransform;
    private Transform _frogTransform;
    private Rigidbody2D _frogRigidbody;
    private SpriteRenderer _frogRenderer;
    private Animator _frogAnimator;
    private bool _grounded;
    private int _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = 1;
        JumpForce = 4.5f;
        JumpXSpeed = 3.5f;
        JumpMaxInterval = 3;
        JumpMinInterval = 1;
        _grounded = true;

        _currentInterval = Random.Range(JumpMaxInterval, JumpMinInterval);

        _playerTransform = Player.GetComponent<Transform>();
        _frogTransform = GetComponent<Transform>();
        _frogRenderer = GetComponent<SpriteRenderer>();
        _frogRigidbody = GetComponent<Rigidbody2D>();
        _frogAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetermineDirection();
        SetAnimationDirection();

        _currentInterval -= Time.deltaTime;
        if (_currentInterval <= 0.01f)
        {
            Debug.Log("Ready to jump!");
            Jump();
            _currentInterval = Random.Range(JumpMinInterval, JumpMaxInterval);
        }
        else if (_frogRigidbody.velocity.y < 0)
        {
            _frogAnimator.SetBool("jump", false);
            _frogAnimator.SetBool("fall", true);
        }
    }

    private void Jump()
    {
        _frogAnimator.SetBool("jump", true);
        _frogAnimator.SetBool("fall", false);

        var currentXSpeed = JumpXSpeed;
        currentXSpeed *= -_direction;

        _frogRigidbody.velocity = new Vector2(_frogRigidbody.velocity.x + currentXSpeed, _frogRigidbody.velocity.y + JumpForce);
    }

    private void SetAnimationDirection()
    {
        _frogRenderer.flipX = _direction < 0;
    }

    private void DetermineDirection()
    {
        if (_frogTransform.position.x < _playerTransform.position.x)
        {
            _direction = -1;
        }
        else
        {
            _direction = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Tilemap")
        {
            _frogAnimator.SetBool("jump", false);
            _frogAnimator.SetBool("fall", false);
        }
    }
}
