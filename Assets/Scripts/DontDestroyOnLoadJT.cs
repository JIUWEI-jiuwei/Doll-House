using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
class DontDestroyOnLoadJT : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
