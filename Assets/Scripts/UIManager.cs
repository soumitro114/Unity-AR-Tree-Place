using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster _raycaster;
    private PointerEventData pointerData;
    private EventSystem eventSystem;


    public Transform selectionPoint;
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pointerData = new PointerEventData(eventSystem);
        /*Clear_Button.clearbutton.clrbtn.gameObject.SetActive(false);*/
        pointerData.position = selectionPoint.position;
    }


    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _raycaster.Raycast(pointerData, results);

        foreach (var result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
}
