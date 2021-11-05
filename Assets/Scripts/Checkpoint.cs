using UnityEngine;

/*
 * Checkpoint indicates to the player that they will respawn at a this point 
 */
public class Checkpoint : MonoBehaviour
{

    public Sprite checkedFlag;                  //The flag up image 
    
    private SpriteRenderer _spriteRenderer;     //The sprite render attached to this object
    private AudioSource _checkpointSfx;         //The audio file that's attached to this object
    
    /*
     * Connects the _spriteRenderer and _checkpointSfx 
     */
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _checkpointSfx = GetComponent<AudioSource>();
    }

    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes, if they do and it's a respawn point is
     * different from the current one 
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        //If it's a player that walks into the collision box change the sprite to be the up one 
        if (!hitBox.CompareTag($"Player")) return;
        _spriteRenderer.sprite = checkedFlag;
        
        //Checks if the respawn position is same as this checkpoint if not update the position and make the sound
        if (hitBox.gameObject.GetComponent<Movement>().respawnPoint.transform.position == transform.position) return;
        _checkpointSfx.Play();
        hitBox.gameObject.GetComponent<Movement>().respawnPoint = transform.transform;
    }
}
