using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sound_btn : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData PointerEventData)
    {
        GameObject.Find("buttonsound").GetComponent<AudioSource>().Play();
    }
}
