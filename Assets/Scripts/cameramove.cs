using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{

    public Transform target;

	void Start() {
        StartCoroutine(ParentCoroutine());
        
    }

    IEnumerator ParentCoroutine()
    {
        yield return new WaitForSeconds(2);
        transform.parent = target.transform;
        
    }
}


