using UnityEngine;

/*
 * Bounce pads can be stepped on by the player and sent flying in the given direction 
 */
public class BouncePad : MonoBehaviour
{
    public Sprite pressed;                  //The sprite of the pressed button
    public Sprite unPressed;                //The sprite of the unpressed button
    public Vector2 direction;               //The velocity direction the player will be sent in 
    private SpriteRenderer _spriteRenderer; //The SpriteRenderer that will change 
    private AudioSource _audioSource;       //The audio will play when player steps on button 
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes, if they do update the sprite render and
     * give the player velocity of the button 
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _spriteRenderer.sprite = pressed;
        hitBox.gameObject.GetComponent<Movement>().BouncePadUpdate(direction);
    }
    
    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes, change the sprite renderer back to unpressed
     * and play the sound 
    */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _spriteRenderer.sprite = unPressed;
        _audioSource.Play();
    }
    
    
}
