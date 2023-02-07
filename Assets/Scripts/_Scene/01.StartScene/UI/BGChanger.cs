using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGChanger : MonoBehaviour
{
    //Image Viewer
    Image imgViewer;

    //Sprites
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    int spriteIdx;

    //Timer
    [SerializeField] float delay = 2f;
    bool delayDone;

    void Start()
    {
        //Set Image viewer
        imgViewer = GetComponent<Image>();
        spriteIdx = 0;

        //Delay is done, ready to change sprite
        delayDone = true;

        StartCoroutine("SpriteChange");
    }

    void Update()
    {
        if(delayDone)
            StartCoroutine("SpriteChange");
    }

    //Class Functions
    void NextSprite()
    {
        //Next sprite
        imgViewer.sprite = sprites[spriteIdx];

        //Increase or Reset the Sprite index
        spriteIdx = spriteIdx + 1 >= sprites.Count ? 0 : spriteIdx + 1;
        
        //Start delay
        delayDone = false;
    }

    IEnumerator SpriteChange()
    {
        NextSprite();
        yield return new WaitForSeconds(delay);
        delayDone = true;
    }
}
