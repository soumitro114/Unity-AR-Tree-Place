using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_clear : MonoBehaviour
{
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
