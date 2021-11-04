using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private TextMeshPro _textMeshPro;
    public Vector2 padding = new Vector2(2f, 2f);
    public String text = "Hello World";
    
    private void Awake()
    {
        _spriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        _textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        _textMeshPro.SetText(text);
        _textMeshPro.ForceMeshUpdate();
        var textSize = _textMeshPro.GetRenderedValues(false);
        textSize = new Vector2(textSize.y, textSize.x);
        _spriteRenderer.size = textSize + padding;

        _spriteRenderer.color = new Color(1, 1, 1, 0);
        _textMeshPro.color = new Color(1, 1, 1, 0);
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _spriteRenderer.color = new Color(1, 1, 1, 0);
            _textMeshPro.color = new Color(1, 1, 1, 0);
        }
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _spriteRenderer.color = new Color(0, 0, 0, 1);
            _textMeshPro.color = new Color(1, 1, 1, 1);
        }
    }
}
