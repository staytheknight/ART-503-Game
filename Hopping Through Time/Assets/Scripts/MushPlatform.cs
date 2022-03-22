using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushPlatform : MonoBehaviour
{   

    [SerializeField] float shakeAmt;                //Force of shake
    [SerializeField] float waitShake;               // wait x seconds before starting shake
    private bool shaking = false;                   // Is shaking toggle
    public Vector2 OriginalPos;                     // Original position of the platforms

    private void Start()
    {
        OriginalPos = transform.position;           // Gets the original position
        StartCoroutine("ShakeNow");                 // Starts the co-routine to shake
    }

    private void Update()
    {
        // If shaking toggle is set to True, shake the object
        if (shaking)
        {
            Vector2 newPos = OriginalPos + (Random.insideUnitCircle * (Time.deltaTime * shakeAmt));
            transform.position = newPos;            
        }
    }

    // Toggles shake after 2 seconds
    IEnumerator ShakeNow()
    {
        yield return new WaitForSeconds(waitShake);

        if (shaking == false)
        {
            shaking = true;
        }

    }
}
