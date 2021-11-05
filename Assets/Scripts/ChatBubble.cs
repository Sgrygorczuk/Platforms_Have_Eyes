using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Chat Bubble create a NPC that will say a line to the player if they are within vicinity. 
 */
public class ChatBubble : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;             //The image of the background bubble    
    private TextMeshPro _textMeshPro;                   //The text processing object 
    public Vector2 padding = new Vector2(2f, 2f);   //The padding that the background would have around the text
    public String text = "Hello World";                 //The text 
    
    /*
     * Connects the _spriteRenderer and _textMeshPro to the objects 
     */
    private void Awake()
    {
        _spriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        _textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    /*
     * Processes the given text, updating the size of the background bubble to fit around it, makes them both
     * invisible till player walks in 
     */
    private void Start()
    {
        //Updates the text 
        _textMeshPro.SetText(text);
        _textMeshPro.ForceMeshUpdate();
        //Gets Text Size 
        var textSize = _textMeshPro.GetRenderedValues(false);
        textSize = new Vector2(textSize.y, textSize.x);
        //Updates the size of the text bubble 
        _spriteRenderer.size = textSize + padding;
        //Sets them to invisible 
        _spriteRenderer.color = new Color(1, 1, 1, 0);
        _textMeshPro.color = new Color(1, 1, 1, 0);
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player exits into any triggering hitBoxes, if they make the text and bubble invisible 
    */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _spriteRenderer.color = new Color(1, 1, 1, 0);
        _textMeshPro.color = new Color(1, 1, 1, 0);
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes , if they make the text and bubble visable    
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _spriteRenderer.color = new Color(0, 0, 0, 1);
        _textMeshPro.color = new Color(1, 1, 1, 1);
    }
}
