using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatformPath : MonoBehaviour
{
    private Transform _transform;

    //================ Movement 
    public Transform[] patrolPoints; //Holds all the postions that the enemy will travel
    public float speed; //Speed of the enemy 
    private int _currentPointIndex; //Which point are they at right now
    
    //================== Pause 
    private float _waitTimeDown;   //Timer 
    public float startWaitTimeDown; //What timer resets to 
    
    private float _waitTimeUp;   //Timer 
    public float startWaitTimeUp; //What timer resets to 

    public float delay = 0;
    
    // Start is called before the first frame update
    public void Start()
    {
        _transform = GetComponent<Transform>();
        _currentPointIndex = 1;
        _transform.position = patrolPoints[0].position;
        _transform.rotation = patrolPoints[0].rotation;
        _waitTimeDown = startWaitTimeDown;
        _waitTimeUp = startWaitTimeUp;
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(Delay());
    }
    
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        //Tells it to move from currently standing in point, to given point at the given speed 
        _transform.position = Vector2.MoveTowards(_transform.position, patrolPoints[_currentPointIndex].position,
            speed * Time.deltaTime);
        _transform.rotation = patrolPoints[_currentPointIndex].rotation;
        if (_currentPointIndex == 0)
        {
            if (_waitTimeUp <= 0)
            {
                _currentPointIndex++;
                _waitTimeUp = startWaitTimeUp;
            }
            else
            {
                _waitTimeUp -= Time.deltaTime;
            }
        }
        else
        {
            if (_waitTimeDown <= 0)
            {
                _currentPointIndex = 0;
                _waitTimeDown = startWaitTimeDown;
            }
            else
            {
                _waitTimeDown -= Time.deltaTime;
            }
        }
    }

}
