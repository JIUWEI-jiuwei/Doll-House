using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///¶ì
///</summary>
class Goose : MonoBehaviour
{
    /// <summary>¶ìµÄ¶¯»­</summary>
    public static Animator goose;
    private void Start()
    {
        goose = this.GetComponent<Animator>();
    }
}
