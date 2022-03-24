using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGraphic : MonoBehaviour
{
    [SerializeField] Sprite wind;


    // TODO: Commented out code is to try and fix the wind sprite not following the player
    //GameObject player; 
    //Vector3 spriteLoc;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpriteSwap"); 
        //player = GameObject.Find("Player"); 
        //spriteLoc = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //spriteLoc += player.transform.position;
        //gameObject.transform.position = new Vector2(spriteLoc.x, spriteLoc.y);
    }

    IEnumerator SpriteSwap() 
    {
        yield return new WaitForSeconds(1f);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = wind; 

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
