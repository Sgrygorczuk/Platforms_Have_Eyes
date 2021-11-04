using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movment : MonoBehaviour
{

    public Transform respawnPoint;
    public float speed = 4;
    public float speedVertical = 4;
    public float jumpForce = 4;
    public float fallMul = 2.5f;
    public float riseMul = 2f;
    public Animator animationFade;
    public Animator animationFadeTwo;
    [SerializeField] private LayerMask platformLayerMask;
    public Text scoreText;  //Reference to the text object 
    public Image collectibleImage;
    public Sprite collectibleSprite;
    public AudioSource bounceSfx;
    public AudioSource collectSfx;
    public AudioSource puzzleSfx;
    public AudioSource checkpointSfx;
    public AudioSource deathSfx;
    public AudioSource waterSfx;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private float _xInput;
    public float _yInput;
    private bool _facingRight = true;
    private bool _isInWater;
    private int _score; 

    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        
        _playerControls.GamePlay.MoveLeft.performed += ctx => WalkLeft();
        _playerControls.GamePlay.MoveLeft.canceled +=  ctx => StandHorizontal();
        
        _playerControls.GamePlay.MoveRight.performed += ctx => WalkRight();
        _playerControls.GamePlay.MoveRight.canceled +=  ctx => StandHorizontal();
        
        _playerControls.GamePlay.MoveUp.performed += ctx => WalkUp();
        _playerControls.GamePlay.MoveUp.canceled +=  ctx => StandVertical();
        
        _playerControls.GamePlay.MoveDown.performed += ctx => WalkDown();
        _playerControls.GamePlay.MoveDown.canceled +=  ctx => StandVertical();
        
        _playerControls.GamePlay.Jump.performed += ctx => Jump();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _yInput = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded() && _yInput < 0)
        {
            _animator.SetBool($"inAir", false);
        }

        if (_isInWater)
        {
            UpdateWaterRotation();
        }
    }

    private void UpdateWaterRotation()
    {
        if (_xInput == speed && _yInput == speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (_xInput == speed && _yInput == -speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, -135);
        }
        else if (_xInput == -speed && _yInput == speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (_xInput == -speed && _yInput == -speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (_xInput == speed && _yInput == 0)
        {
            _transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (_xInput == -speed && _yInput == 0)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (_xInput == 0 && _yInput == speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_xInput == 0 && _yInput == -speedVertical)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    private void WalkLeft()
    {
        _xInput = -speed;
        if (_isInWater)
        {
            
        }
        else
        {
            //UpdateRotation(-speed);
            _animator.SetBool($"isWalking", true);
        }
    }

    private void WalkRight()
    {
        _xInput = speed;
        if (_isInWater)
        {
            
        }
        else
        {
            //UpdateRotation(speed);
            _animator.SetBool($"isWalking", true);
        }
    }

    private void WalkUp()
    {
        if (_isInWater)
        {
            _yInput = speedVertical;
        }
    }

    private void WalkDown()
    {
        if (_isInWater)
        {
            _yInput = -speedVertical;
        }
    }

    private void StandHorizontal()
    {
        _xInput = 0;
        _animator.SetBool($"isWalking", false);
    }
    
    private void StandVertical()
    {
        _yInput = 0;
    }

    private void Jump()
    {
        if (_animator.GetBool($"inAir") || _isInWater) return;
        _yInput = Vector2.up.y * jumpForce;
        _animator.SetBool($"inAir", true);
    }


    private void OnEnable()
    {
        _playerControls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        _playerControls.GamePlay.Disable();
    }


    private void FixedUpdate()
    {
        if (!_isInWater)
        {
            if (IsGrounded() && !_animator.GetBool($"inAir"))
            {
                _yInput = 0;
            }
            else if (_rigidbody2D.velocity.y <= 0 || (!IsGrounded() && _rigidbody2D.velocity.y == 0))
            {
                _yInput += Vector2.up.y * Physics2D.gravity.y * (fallMul - 1) * Time.deltaTime;
            }
            else if (_rigidbody2D.velocity.y > 0)
            {
                _yInput += Vector2.up.y * Physics2D.gravity.y * (riseMul - 1) * Time.deltaTime;
            }  
        }

        _rigidbody2D.velocity = new Vector2(_xInput, _yInput);
    }
    

    private void UpdateRotation(float direction)
    {
        switch (_facingRight)
        {
            case true when direction < 0:
                StartCoroutine(TurnLeft());
                _facingRight = false;
                break;
            case false when direction > 0:
                StartCoroutine(TurnRight());
                _facingRight = true;
                break;
        }
    }

    private bool IsGrounded()
    {
        const float extraHeightTest = 0.1f;
        var bounds = _boxCollider2D.bounds;
        var raycast = Physics2D.BoxCast(bounds.center, bounds.size, 0, Vector2.down, extraHeightTest, platformLayerMask);
        var isNotNull = raycast.collider != null;
        DrawJumpDebug(isNotNull, extraHeightTest);
        return isNotNull;
    }

    private void DrawJumpDebug(bool isNotNull, float extraHeightTest)
    {
        //Ray colors 
        var rayColor  = Color.red;
        if (isNotNull) { rayColor = Color.green; }

        //Simplifying variables 
        var bounds = _boxCollider2D.bounds;
        var center = bounds.center;
        var x = bounds.extents.x;
        var y = bounds.extents.y;
        
        //Draws the bottom of the box which can be seen when Gizmos is turned on
        //Left 
        Debug.DrawRay(center + new Vector3(x,  -y + extraHeightTest), Vector2.down * extraHeightTest, rayColor);
        //Right 
        Debug.DrawRay(center - new Vector3(x,  y - extraHeightTest), Vector2.down * extraHeightTest, rayColor);
        //Bottom
        Debug.DrawRay(center - new Vector3(x, y, 1f), Vector2.right * (2 * x), rayColor);
    }
    

    private IEnumerator TurnLeft()
    {
        transform.localEulerAngles = new Vector3(0,45,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,89,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,135,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,180,0);
    } 
    
    private IEnumerator TurnRight()
    {
        transform.localEulerAngles = new Vector3(0,135,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,89,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,45,0);
        yield return new WaitForSeconds(0.05f);
        transform.localEulerAngles = new Vector3(0,0,0);
    } 

    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Spike"))
        {
            StartCoroutine(Respawn());
        }
        else if (hitBox.CompareTag($"Water"))
        {
            _isInWater = true;
            StartCoroutine(WaterDip());
            if(_animator.GetBool($"inAir"))
            {
                _animator.SetBool($"inAir", false);
            }
            _animator.SetBool($"inWater", true);
            waterSfx.Play();
        }
        else if (hitBox.CompareTag($"Checkpoint"))
        {
            if(respawnPoint.position != hitBox.transform.position){checkpointSfx.Play();}
            respawnPoint.position = hitBox.transform.position;
        }
        else if (hitBox.CompareTag($"BouncePad"))
        {
            _animator.SetBool($"inAir", true);
            var data = hitBox.gameObject.GetComponent<BouncePad>();
            if (data.direction.x != 0)
            {
                _xInput = data.direction.x * jumpForce; 
            }
            if(data.direction.y != 0){
                _yInput = data.direction.y * jumpForce;
            }
            bounceSfx.Play();
        }
        else if (hitBox.CompareTag($"Collectible"))
        {
            var data = hitBox.gameObject.GetComponent<Collectible>();
            _score += data.score;
            Destroy(data.gameObject);
            scoreText.text = _score.ToString();
            collectSfx.Play();
        }
        else if (hitBox.CompareTag($"Puzzle"))
        {
            Destroy(hitBox.gameObject);
            collectibleImage.sprite = collectibleSprite;
            puzzleSfx.Play();
        }
    }

    /**
    * Input: hitBox
    * Purpose: Check if the player enters into any triggering hitBoxes   
    */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Water"))
        {
            _isInWater = false;
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            _yInput = Vector2.up.y * jumpForce;
            _animator.SetBool($"inWater", false);
            waterSfx.Play();
        }
    }
    
    

    private IEnumerator WaterDip()
    {
        _yInput = Vector2.down.y * jumpForce;
        yield return new WaitForSeconds(0.3f);
        _yInput = 0;
    }

    

    private IEnumerator Respawn()
    {
        deathSfx.Play();
        OnDisable();
        animationFade.Play("fade");
        _rigidbody2D.velocity = new Vector2(0, 0);
        
        yield return new WaitForSeconds(0.3f);
        
        animationFadeTwo.Play("fade");
        yield return new WaitForSeconds(0.4f);
        
        OnEnable();
        var position = respawnPoint.position;
        _rigidbody2D.position = new Vector2(position.x, position.y);
    }
    

}
