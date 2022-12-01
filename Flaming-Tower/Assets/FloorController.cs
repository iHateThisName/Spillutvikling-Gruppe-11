using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public TextMeshPro floorText;
   
   public void setFloorText(string newText) {
    floorText.text = newText;
   }
}
