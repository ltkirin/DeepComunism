using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllerScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
