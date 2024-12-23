using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dindingdetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.name == "Tanah"){
            transform.parent.GetComponent<Pemain>().isdinding = true;
        }
    }
    void OnTriggerExit2D(Collider2D obj){
        if(obj.name == "Tanah"){
            transform.parent.GetComponent<Pemain>().isdinding = false;
        }
    }
}
