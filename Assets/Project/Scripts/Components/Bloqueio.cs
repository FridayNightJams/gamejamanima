using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloqueio : MonoBehaviour
{
    [SerializeField] private Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.gameObject.transform.position = pos;
        }
    }
}
