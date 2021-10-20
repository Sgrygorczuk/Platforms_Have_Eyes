using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Sprite pressed;
    public Sprite unPressed;
    public Vector2 direction;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _spriteRenderer.sprite = pressed;
        }
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _spriteRenderer.sprite = unPressed;
        }
    }
    
    
}
