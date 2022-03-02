using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushPlatformSpawn : MonoBehaviour
{

    [SerializeField] GameObject mushplatform;
    [SerializeField] int platformAmount = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && platformAmount != 0)
        {
            Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Vector2 for spawn position is to reset the Z co-ordinates to not be tied to those of the camera
            GameObject platform = Instantiate(mushplatform, spawnPosition, Quaternion.identity);
            StartCoroutine("removePlatform", platform);

        }

    }

    // Removes platform after 3 seconds, and changes count of how many platforms are available
    IEnumerator removePlatform(GameObject platform)
    {
        platformAmount -= 1;

        yield return new WaitForSeconds(3f);
        Destroy(platform);

        platformAmount += 1;
    }

}
