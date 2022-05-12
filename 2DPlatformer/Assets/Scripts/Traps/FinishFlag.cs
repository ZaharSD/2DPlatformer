
using System;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    public static event Action EndLevel;
	
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EndLevel?.Invoke();
        }
    }
}
