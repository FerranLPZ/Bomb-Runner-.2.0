using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehavior : MonoBehaviour
{
    public float onDuration = 5f; // Laser on duration in seconds
    public float offDuration = 5f; // Laser off duration in seconds
    public GameObject laser; // The laser GameObject

    private void Start()
    {
        StartCoroutine(ToggleLaserRoutine());
    }

    private IEnumerator ToggleLaserRoutine()
    {
        while (true)
        {
            laser.SetActive(true); // Turn the laser on
            yield return new WaitForSeconds(onDuration); // Wait while the laser is on

            laser.SetActive(false); // Turn the laser off
            yield return new WaitForSeconds(offDuration); // Wait while the laser is off
        }
    }
}
