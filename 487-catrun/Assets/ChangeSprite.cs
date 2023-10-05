  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite newSprite;
  
    // Update is called once per frame
    void Update()
    {
        
        GetComponent<SpriteRenderer>().sprite = newSprite;

    }
}
