using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Click : MonoBehaviour
{
    //公共
    public TextMeshProUGUI clickCountText;
    public ParticleSystem clickEffect;
    public AudioClip WoodAudio;

    public bool canAutoPlay = false;
    //私有
    private int clickCount = 0;

    private float clickToScaleSpeed = 1.1f;
    private float stayToScaleSpeed = 0.999f;
    private float autoPlaySpeed = 1;
    private float autoPlayTime;

    //other
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckClick();
        CheckAutoPlay();
    }
    private void CheckClick()
    {
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            if (clickPosition.x >= -1 && clickPosition.x <= 1 && clickPosition.y >= -1 && clickPosition.y <= 1)
            {
                ClickWoodFish();
            }
        }
        else
        {
            StayWoodFish();
        }
    }
    private void StayWoodFish(){
            if (transform.localScale.x >= 2)
            {
                transform.localScale = new Vector3(transform.localScale.x * stayToScaleSpeed, transform.localScale.y * stayToScaleSpeed, transform.localScale.z);
            }
    }
    private void ClickWoodFish()
    {
        Instantiate(clickEffect, transform.position, Quaternion.identity);
        if(transform.localScale.x < 6)
            transform.localScale = new Vector3(transform.localScale.x * clickToScaleSpeed, transform.localScale.y * clickToScaleSpeed, transform.localScale.z);
        clickCount++;
        clickCountText.text = "功德:" + clickCount;
        VoiceManager.instance.playClip(WoodAudio);
    }
    public void CheckAutoPlay(){
        if(canAutoPlay){
            autoPlayTime -= Time.deltaTime;
            if(autoPlayTime < 0){
                ClickWoodFish();
                autoPlayTime = autoPlaySpeed;
            }
        }
    }
    public void AutoPlaySpeedUp(){
        autoPlaySpeed /= 2;
    }
    public int GetCount(){
        return clickCount;
    }
    public void HellJoke(int count){
        clickCount -= count;
    }
}
