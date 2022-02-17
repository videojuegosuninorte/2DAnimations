using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickLogic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image Image;
    public Sprite DefaultSprite, PressedSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        Image.sprite = PressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Image.sprite = DefaultSprite;
    }

}
