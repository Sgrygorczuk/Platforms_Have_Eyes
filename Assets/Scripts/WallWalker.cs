using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWalker : MonoBehaviour
{
    
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    public AudioSource deathSfx;
    public float x;
    private float _spawnTime;   //The timer
    private const float StartSpawn = 3; //Max time the timer can be a

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _spawnTime = StartSpawn;
    }

    // Update is called once per frame
    public void Update()
    {
        _rigidbody2D.velocity = new Vector2(x, _rigidbody2D.velocity.y);
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Wall"))
        {
            x *= -1;
        }
        if (!hitBox.CompareTag($"Spike")) return;
        x = 0;
        _animator.SetBool($"Dead", true);
        deathSfx.Play();
    }

    private void Jump()
    {
        if (_spawnTime <= 0)
        {
            _rigidbody2D.velocity = 2*Vector2.up;
            //Resets the spawn timer 
            _spawnTime = StartSpawn;
        }
        else
        {
            //Updates the spawn timer 
            _spawnTime -= Time.deltaTime;
        }
    }
}
