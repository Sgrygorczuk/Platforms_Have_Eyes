using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public Sprite unbroken;
    public Sprite broken;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D boxCollider2DTrigger;
    public Material _material;
    public bool isDissolving = false;
    public float fade = 1f;

    private SpriteRenderer _spriteRenderer;
    private int _state = 0;
    
    //================== Pause 
    private float _waitTime;   //Timer 
    public float startWaitTime; //What timer resets to 
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = GetComponent<SpriteRenderer>().material;
        _material.SetFloat("_Fade",fade);
        _waitTime = startWaitTime;
    }

    // Update is called once per frame
    public void Update()
    {
        print(_state);
        switch (_state)
        {
            case 1:
                _spriteRenderer.sprite = broken;
                break;
            case 2:
            {
                boxCollider2D.enabled = false;
                boxCollider2DTrigger.enabled = false;
                _state++;
                break;
            }
            case 3:
            {
                fade -= Time.deltaTime;
                if (fade <= 0)
                {
                    fade = 0;
                    _spriteRenderer.sprite = unbroken;
                    _state++;
                }
                _material.SetFloat("_Fade",fade);
                break;
            }
            case 4:
            {
                if (_waitTime <= 0)
                {
                    fade += Time.deltaTime;
                    if (fade >= 1)
                    {
                        fade = 1;
                         _waitTime = startWaitTime;
                         _state = 0;
                         boxCollider2D.enabled = true;
                         boxCollider2DTrigger.enabled = true;
                    }
                    _material.SetFloat("_Fade",fade);
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
                break;
            }
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
            _state++;
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
            _state++;
        }
    }
}
