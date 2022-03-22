using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGraphic : MonoBehaviour
{
    [SerializeField] Sprite wind;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpriteSwap"); 
    }

    // Update is called once per frame
    void Update()
    {
        
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
