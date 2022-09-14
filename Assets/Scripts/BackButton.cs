using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button bckbtn;
    // Start is called before the first frame update
    void Start()
    {
        bckbtn = GetComponent<Button>();
        bckbtn.onClick.AddListener(CloseHelpWindow);
    }

    void CloseHelpWindow()
    {
        transform.parent.parent.Find("HelpScrollView").gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.Find("HelpButton").gameObject.SetActive(true);
    }
}
