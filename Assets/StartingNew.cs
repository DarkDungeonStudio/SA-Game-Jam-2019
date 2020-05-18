using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingNew : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DisableAll", 2f);
    }

    // Update is called once per frame
    public void DisableAll()
    {
        gameObject.SetActive(false);
    }
}
