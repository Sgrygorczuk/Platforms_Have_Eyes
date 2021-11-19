using UnityEngine;

public class PlatformPath : MonoBehaviour
{
    private Transform _transform;

    //================ Movement 
    public Transform[] patrolPoints; //Holds all the postions that the enemy will travel
    public float speed; //Speed of the enemy 
    private int _currentPointIndex; //Which point are they at right now
    public Transform currentPoint;
    public bool steppingOnByUser;
    private bool isSteppedOn;

    //================== Pause 
    private float _waitTime;   //Timer 
    public float startWaitTime; //What timer resets to 
    
    // Start is called before the first frame update
    public void Start()
    {
        _transform = GetComponent<Transform>();
        _currentPointIndex = 1;
        _transform.position = patrolPoints[0].position;
        _transform.rotation = patrolPoints[0].rotation;
        _waitTime = startWaitTime;
        currentPoint = _transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (steppingOnByUser)
        {
            SteppedOnMove();
        }
        else
        {
            RegularMovement();
        }
    }

    private void SteppedOnMove()
    {
        var index = 0;
        if (isSteppedOn)
        {
            index = 1;
        }
        _transform.position = Vector2.MoveTowards(_transform.position, patrolPoints[index].position,
            speed * Time.deltaTime);
        _transform.rotation = patrolPoints[index].rotation;
    }

    private void RegularMovement()
    {
        //Tells it to move from currently standing in point, to given point at the given speed 
        _transform.position = Vector2.MoveTowards(_transform.position, patrolPoints[_currentPointIndex].position,
            speed * Time.deltaTime);
        _transform.rotation = patrolPoints[_currentPointIndex].rotation;
        if (transform.position != patrolPoints[_currentPointIndex].position) return;
        if (_waitTime <= 0)
        {
            if (_currentPointIndex == patrolPoints.Length - 1)
            {
                _currentPointIndex = 0;
                currentPoint = patrolPoints[_currentPointIndex];
            }
            else
            {
                _currentPointIndex++;
            }

            _waitTime = startWaitTime;
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform,true);
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }
    
    /**
    * Input: hitBox
         * Purpose: Check if the player enters into any triggering hitBoxes,
         */
         private void OnTriggerEnter2D(Collider2D hitBox)
         {
             if (!hitBox.CompareTag($"Player")) return;
             isSteppedOn = true;
         }
    
    /**
    * Input: hitBox
         * Purpose: Check if the player enters into any triggering hitBoxes,
         */
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Player")) return;
        isSteppedOn = false;
    }
}
