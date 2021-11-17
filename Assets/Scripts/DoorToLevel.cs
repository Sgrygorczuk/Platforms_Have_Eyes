using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLevel : MonoBehaviour
{

    public bool doorOpen;

    public bool puzzleFound;

    public bool levelComplete;

    public String levelName = "Overworld";
    public Sprite closedTop;
    public Sprite closedBot;
    public SpriteRenderer top;
    public SpriteRenderer bot;

    private bool _playerIn;
    private PlayerControls _playerControls;

    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.GamePlay.Jump.performed += ctx => GoToLevel();
    }
    
    // Start is called before the first frame update
    public void Start()
    {
        _playerIn = false;
        if (doorOpen) return;
        top.sprite = closedTop;
        bot.sprite = closedBot;
    }

    private void GoToLevel()
    {
        print("A");
        if (_playerIn && doorOpen)
        {
            StartCoroutine(Wipe());
        }
    }
    
    
    private IEnumerator Wipe()
    {
       //if(!winSFX.isPlaying){
       //     winSFX.Play(0);
       // }
       // animator.Play("LeaveWipe");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
    }

    
    private void OnEnable()
    {
        _playerControls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        _playerControls.GamePlay.Disable();
    }

    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _playerIn = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
        {
            _playerIn = false;
        }
    }
}
