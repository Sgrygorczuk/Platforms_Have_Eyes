using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite checkedFlag;
    private SpriteRenderer _spriteRenderer;

    private void Start()
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
            _spriteRenderer.sprite = checkedFlag;
        }
    }
}
