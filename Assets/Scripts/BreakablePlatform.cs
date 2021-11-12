using UnityEngine;

/*
 * Breakable platform crack when the player steps on them and evaporate when the player steps off, with a timer
 * they come back.
 */
public class BreakablePlatform : MonoBehaviour
{
    public Sprite unbroken;                     //Sprite of the unbroken block 
    public Sprite broken;                       //Sprite of the broken block 
    public BoxCollider2D boxCollider2D;         //The Box collider on which the player stands 
    public BoxCollider2D boxCollider2DTrigger;  //The Box collider that checks if the player stepped on the block 
    public float fade = 1f;                     //The fade percentage goes between 0 and 1
    public AudioSource audioSourceOne;          //The audio that plays when player steps on block
    public AudioSource audioSourceTwo;          //The audio of the block breaking after player walks off

    private Material _material;                 //Material of the sprite that will let us fade it in and out 
    private SpriteRenderer _spriteRenderer;     //The sprite renderer 
    private int _state;                         //Tells us how the block should be behaving 
    private float _waitTime;                    //Timer 
    public float startWaitTime;                 //What timer resets to 
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = GetComponent<SpriteRenderer>().material;
        _material.SetFloat($"_Fade",fade);
        _waitTime = startWaitTime;
    }

    // Update is called once per frame
    public void Update()
    {
        //Changes how the block behaves based on the different state 
        switch (_state)
        {
            //Player stepped on it and the sprite changes to the broken one 
            case 1:
                _spriteRenderer.sprite = broken;
                break;
            //Player steps of the platform and you can't collide with it anymore 
            case 2:
            {
                boxCollider2D.enabled = false;
                boxCollider2DTrigger.enabled = false;
                _state++;
                audioSourceTwo.Play();
                break;
            }
            //The block fades away
            case 3:
            {
                fade -= Time.deltaTime;
                if (fade <= 0)
                {
                    fade = 0;
                    _spriteRenderer.sprite = unbroken;
                    _state++;
                }
                _material.SetFloat($"_Fade",fade);
                break;
            }
            //The block waits till the timer is over and the block fades back into existence 
            case 4:
            {
                if (_waitTime <= 0)
                {
                    fade += 2 * Time.deltaTime;
                    if (fade >= 1)
                    {
                        fade = 1;
                         _waitTime = startWaitTime;
                         _state = 0;
                         boxCollider2D.enabled = true;
                         boxCollider2DTrigger.enabled = true;
                    }
                    _material.SetFloat($"_Fade",fade);
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
    * Purpose: Check if the player enters into any triggering hitBoxes, updates the state of the block
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
    * Purpose: Check if the player enters into any triggering hitBoxes, updates the state of the block 
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        _state++;
        audioSourceOne.Play();
    }
}
