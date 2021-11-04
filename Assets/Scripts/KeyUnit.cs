using UnityEngine;

public class KeyUnit : MonoBehaviour
{

    public SpriteRenderer box;
    public new GameObject gameObject;
    private SpriteRenderer _spriteRenderer;
    private Material _material;
    private bool _isDissolving = false;
    private bool _isDone = false;
    public float fade = 1f;
    public Color color = new Color(1f, 1f, 1f, 1f);
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        box.color = color;
        _spriteRenderer.color = color;
        _material = box.material;
        _material.SetFloat($"_Fade",fade);
    }

    private void Update()
    {
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
        if (_isDone)
        {
            Destroy(gameObject);
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
            _spriteRenderer.color =  new Color(1f, 1f, 1f, 0f);
            _isDissolving = true;
            audioSource.Play();
        }
    }
}
