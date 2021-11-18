using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disc : MonoBehaviour
{
    public String levelName = "Overworld";
    public SpriteRenderer discBackground;
    public int currentColorChange = 0; //Which transition of color change we 
    private Color _color = new Color(0, 0, 0, 1);
    private float _r = 1;
    private float _g = 0; 
    private float _b = 0;


    // Update is called once per frame
    public void Update()
    {
        /*
     *0: R is 255, G is 0, but increaseing, B is 0 
     *1: R is 255 Decreaseing G is 255, B is 0
     *2: R is 0 Decreaseing G is 255, B is 0 increaseing
     *3: R is 0, G is 255 Decreaseing, B is 255
     *4: R is 0 increaseing G is 0, B is 255
     *5: R is 255, G is 0, B is 255 Decreaseing
     */
        switch(currentColorChange){
            case 0:{
                _g += 0.05f;
                if(_g >= 1){
                    _g = 1;
                    currentColorChange++;
                }
                break;
            }
            case 1:{
                _r -= 0.05f;
                if(_r <= 0){
                    _r = 0;
                    currentColorChange++;
                }
                break;
            }
            case 2:{
                _b += 0.05f;
                if(_b >= 1){
                    _b = 1;
                    currentColorChange++;
                }
                break;
            }
            case 3:{
                _g -= 0.05f;
                if(_g <= 0 ){
                    _g = 0;
                    currentColorChange++;
                }
                break;
            }
            case 4:{
                _r += 0.05f;
                if(_r >= 1){
                    _r = 1;
                    currentColorChange++;
                }
                break;
            }
            case 5:{
                _b -= 0.05f;
                if(_b <= 0){
                    _b = 0;
                    currentColorChange = 0;
                }
                break;
            }
        }

        _color = new Color(_r, _g, _b, 1f); 
        discBackground.color = _color;
    }
    
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.CompareTag($"Player"))
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
}
