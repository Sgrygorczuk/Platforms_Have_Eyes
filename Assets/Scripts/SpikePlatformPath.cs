using System.Collections;
using UnityEngine;

/*
 * Spike Platform Path make the platform with spikes moving between given amount of points 
 */
public class SpikePlatformPath : MonoBehaviour
{
    private Transform _transform;

    //================ Movement 
    public Transform[] patrolPoints; //Holds all the positions that the platform will travel
    public float speed;              //Speed of the platform 
    private int _currentPointIndex;  //Which point are they at right now
    
    //================== Pause 
        //Timer before the platform goes down 
    private float _waitTimeDown;   //Timer 
    public float startWaitTimeDown; //What timer resets to 
    
        //Timer before the platforms goes up 
    private float _waitTimeUp;   //Timer 
    public float startWaitTimeUp; //What timer resets to 

    public float delay;
    
    // Start is called before the first frame update
    public void Start()
    {
        //Gets the transform 
        _transform = GetComponent<Transform>();
        //Sets the platform to be at the first index and hold of all it's data 
        _currentPointIndex = 1;
        _transform.position = patrolPoints[0].position;
        _transform.rotation = patrolPoints[0].rotation;
        //Sets up the wait times 
        _waitTimeDown = startWaitTimeDown;
        _waitTimeUp = startWaitTimeUp;
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(Delay());
    }
    
    /*
     * Moves the platforms on a Delay, allowing different platforms to move up and down on different timings,
     * then checks if the pause timer is done. 
     */
    private IEnumerator Delay()
    {
        //Wait till delay is done 
        yield return new WaitForSeconds(delay);
        //Tells it to move from currently standing in point, to given point at the given speed 
        _transform.position = Vector2.MoveTowards(_transform.position, patrolPoints[_currentPointIndex].position,
            speed * Time.deltaTime);
        _transform.rotation = patrolPoints[_currentPointIndex].rotation;
        //Checks if we're at the first point or the other 
        if (_currentPointIndex == 0)
        {
            //If we're going up timer
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
            //If we're going down timer 
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
