using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour, IInteractible
{
    public Crane crane;
    public void Interact()
    {
        crane.GiveWater();
    }
    public void Interact(GameObject player)
    { }
}
