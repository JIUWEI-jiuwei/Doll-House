using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��
///</summary>
class Goose : MonoBehaviour
{
    /// <summary>��Ķ���</summary>
    public static Animator goose;
    private void Start()
    {
        goose = this.GetComponent<Animator>();
    }
}
