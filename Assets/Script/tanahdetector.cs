using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanahdetector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.name == "Tanah"){
            transform.parent.GetComponent<Pemain>().istanah = true;
        }
    }
    void OnTriggerExit2D(Collider2D obj){
        if(obj.name == "Tanah"){
            transform.parent.GetComponent<Pemain>().istanah = false;
        }
    }
}
