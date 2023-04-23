using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour { 
    //Raw image used for UV Rect and because image is non interactable 
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

   
  //Using UV rect to repeat the image on the y axis 
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,_img.uvRect.size);
    }
}
