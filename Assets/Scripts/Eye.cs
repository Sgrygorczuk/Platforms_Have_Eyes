using UnityEngine;

public class Eye : MonoBehaviour
{
    
    public SpriteRenderer eye;
    public  Transform playerPosition;
    public float moveSpeed = 0.1f;
    public float yAboveAdjustment = 0;
    public float yBelowAdjustment = 0;
    public float xLeftAdjustment = 0;
    public float xRightAdjustment = 0; 
    private Vector2 _position;
    private Transform _transform;
    private Transform _firstTransform;
    private float _yAdjustment = 0;
    private float _xAdjustment = 0;
    public bool print = false;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _firstTransform = _transform; 
    }

    
    // Update is called once per frame
    public void Update()
    {
        if (playerPosition.position.y > _firstTransform.position.y)
        {
            _yAdjustment = yAboveAdjustment;
        }
        else if (playerPosition.position.y < _firstTransform.position.y)
        {
            _yAdjustment = yBelowAdjustment;
        }
        else
        {
            _yAdjustment = 0;
        }
        
        if(playerPosition.position.x > _firstTransform.position.x)
        {
            _xAdjustment = xRightAdjustment;
        }
        else if (playerPosition.position.x < _firstTransform.position.x)
        {
            _xAdjustment = xLeftAdjustment;
        }
        else
        {
            _xAdjustment = 0;
        }

        if (gameObject.GetComponentInParent<Transform>().rotation.y == 1)
        {
            _xAdjustment *= -1;
        }
        
        _position = Vector2.MoveTowards(_firstTransform.position, playerPosition.position, moveSpeed);
        
        _position = new Vector2(_position.x + _xAdjustment, _position.y + _yAdjustment);
        eye.transform.position = _position;
    }
}
