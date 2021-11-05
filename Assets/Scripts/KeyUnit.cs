using UnityEngine;

/*
 * Has a Key and Lock when player collects the key the block goes away 
 */
public class KeyUnit : MonoBehaviour
{

    public SpriteRenderer box;                              //The spriteRender of the block 
    public new GameObject gameObject;                       //The game object will be used to destroy this 
    public float fade = 1f;                                 //The number fade is on the box 
    public Color color = new Color(1f, 1f, 1f, 1f);  //Color of the box and the key 
    
    private AudioSource _audioSource;                       //The SFX that plays when key is picked up
    private SpriteRenderer _spriteRenderer;                 //The key sprite renderer 
    private BoxCollider2D _boxCollider2D;
    private Material _material;                             //The material for the box 
    private bool _isDissolving;                             //Tells us if the box is dissolving  
    private bool _isDone;                                   //Tells us if we're done and can destroy the game object  

    // Start is called before the first frame update
    private void Start()
    {
        //Get the objects 
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        //Set the color of the key and box 
        box.color = color;
        _spriteRenderer.color = color;
        //Set the material to the box 
        _material = box.material;
        _material.SetFloat($"_Fade",fade);
    }

    /*
     * When the key is touched the block dissolves and once that's done the object destroys itself 
     */
    private void Update()
    {
        //If player touched the key box starts dissolving  
        if (_isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0)
            {
                fade = 0;
                _isDone = true;
            }
            _material.SetFloat($"_Fade",fade);
        }
        //If the block has dissolved it destroys itself 
        if (_isDone)
        {
            Destroy(gameObject);
        }
    }

    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes, when he enters the key goes invisible, the
     * box starts to dissolve and plays the sound effect 
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _boxCollider2D.enabled = false;
        _spriteRenderer.color =  new Color(1f, 1f, 1f, 0f);
        _isDissolving = true;
        _audioSource.Play();
    }
}
