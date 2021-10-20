using UnityEngine;

public class Eye : MonoBehaviour
{
    
    public SpriteRenderer eye;
    public  Transform playerPosition;
    public float moveSpeed = 0.1f;
    private float _yAdjuster = 0;
    private Vector2 _position;
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    
    // Update is called once per frame
    public void Update()
    {
        if (playerPosition.position.y > _position.y)
        {
            _yAdjuster = 0.04f;
        }
        else if (playerPosition.position.y < _position.y)
        {
            _yAdjuster = -0.01f;
        }
        else
        {
            _yAdjuster = 0;
        }

        _position = Vector2.MoveTowards(_transform.position, playerPosition.position, moveSpeed);

        _position = new Vector2(_position.x, _position.y + _yAdjuster);
        eye.transform.position = _position;
    }
}
