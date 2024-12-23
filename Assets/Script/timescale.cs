using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class timescale : MonoBehaviour, IPointerDownHandler
{
    public int time;
    public void OnPointerDown(PointerEventData PointerEventData)
    {
        Time.timeScale = time;
    }
}