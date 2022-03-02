using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushPlatformSpawn : MonoBehaviour
{

    [SerializeField] GameObject mushplatform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Vector2 for spawn position is to reset the Z co-ordinates to not be tied to those of the camera
            GameObject g = Instantiate(mushplatform, (Vector2)spawnPosition, Quaternion.identity);
        }
    }
}
