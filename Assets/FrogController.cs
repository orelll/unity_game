using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject Player;
    private Transform _playerTransform;
    private Transform _frogTransform;
    private SpriteRenderer _frogRenderer;
    private int _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = 1;
        _playerTransform = Player.GetComponent<Transform>();
        _frogTransform = GetComponent<Transform>();
        _frogRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DetermineDirection();
        SetAnimationDirection();
    }

    private void SetAnimationDirection(){
        _frogRenderer.flipX = _direction < 0;
    }

    private void DetermineDirection(){
        if(_frogTransform.position.x < _playerTransform.position.x)
        {
            _direction = -1;
        }
        else{
            _direction = 1;
        }
    }
}
