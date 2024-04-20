using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehavior : MonoBehaviour
{
    public float onDuration = 5f; // Laser on duration in seconds
    public float offDuration = 5f; // Laser off duration in seconds
    public float spriteChangeDelay = 2f;

    public GameObject laser; // The laser GameObject

    public Sprite onSprite;
    public Sprite offSprite;
    private GameObject powerBlock1;
    private GameObject powerBlock2;


    private void Start()
    {



        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        onSprite = spriteRenderer.sprite;


        StartCoroutine(ToggleLaserRoutine());
        powerBlock1 = transform.GetChild(0).gameObject;
        powerBlock2 = transform.GetChild(transform.childCount - 1).gameObject;
       
        if (powerBlock1.GetComponent<SpriteRenderer>())
            offSprite = powerBlock1.GetComponent<SpriteRenderer>().sprite;

        if (powerBlock2.GetComponent<SpriteRenderer>())
            offSprite = powerBlock2.GetComponent<SpriteRenderer>().sprite;
        

    }

    private IEnumerator ToggleLaserRoutine()
    {
        while (true)
        {
            StartCoroutine(ChangeSpriteRoutine(onSprite, spriteChangeDelay, false)); // Change sprite before laser turns on

            laser.SetActive(true); // Turn the laser on
            yield return new WaitForSeconds(onDuration); // Wait while the laser is on

            laser.SetActive(false); // Turn the laser off

            StartCoroutine(ChangeSpriteRoutine(offSprite, spriteChangeDelay, true)); // Change sprite after laser turns off
            yield return new WaitForSeconds(offDuration); // Wait while the laser is off
        }
    }

    private IEnumerator ChangeSpriteRoutine(Sprite sprite, float delay, bool postLaser)
    {
        if (postLaser) yield return new WaitForSeconds(onDuration + delay);
        else yield return new WaitForSeconds(delay);

        // Change the sprite of powerBlock1 and powerBlock2
        if (powerBlock1.GetComponent<SpriteRenderer>())
            powerBlock1.GetComponent<SpriteRenderer>().sprite = sprite;
        if (powerBlock2.GetComponent<SpriteRenderer>())
            powerBlock2.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
