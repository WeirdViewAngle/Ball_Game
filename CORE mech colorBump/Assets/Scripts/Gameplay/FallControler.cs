using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallControler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "BigCube")
        {
            PoolManager.Pool.ReturnStack(other.gameObject, other.gameObject.name);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
