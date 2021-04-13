using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    bool spawned = false;
    void OnBecameVisible() 
    {
        if(!spawned)
        {
            GameManager.Instance.SpawnRandomStack(transform.position);
            spawned = true;
        }
        
    }
}
