using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class Goose : MonoBehaviour
{
    public static Animator goose;
    private void Start()
    {
        goose = this.GetComponent<Animator>();
    }
}
