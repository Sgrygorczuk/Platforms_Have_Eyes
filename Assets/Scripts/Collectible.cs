using System.Collections;
using UnityEngine;

/*
 * The collectible that adds to the score the player get when collectd
 */
public class Collectible : MonoBehaviour
{
    public int score;                           //How much the item is worth
    
    private AudioSource _collectSfx;            //The SFX played if we 
    private SpriteRenderer _spriteRenderer;     //The SpriteRenderer 
    private BoxCollider2D _boxCollider2D;       //The box collider 
    
    /*
     * Connects the _spriteRenderer and _checkpointSfx 
    */
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collectSfx = GetComponent<AudioSource>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes,
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        //If it's a player that walks into the collision box change the sprite to be the up one 
        if (!hitBox.CompareTag($"Player")) return;
        //Plays sound and makes it invisible  
        _boxCollider2D.enabled = false;
        _collectSfx.Play();
        _spriteRenderer.color = new Color(1, 1, 1, 0);
        //Updates the score in player and set to destroy this object once the sound is done 
        hitBox.gameObject.GetComponent<Movement>().UpdateScore(score);
        StartCoroutine(DestroyOnceSFXDone());
    }
    
    /*
     * Waiting for the SFX to be done playing then destroys this object 
     */
    private IEnumerator DestroyOnceSFXDone()
    {
        yield return new WaitForSeconds(_collectSfx.clip.length);
        Destroy(gameObject);
    } 
}
