using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpButton : MonoBehaviour
{
    private Button hlpbtn;
    // Start is called before the first frame update
    void Start()
    {
        hlpbtn = GetComponent<Button>();
        hlpbtn.onClick.AddListener(helpshow);
    }

    
    void helpshow()
    {
        transform.parent.Find("ButtonPanel").gameObject.SetActive(true);
        transform.parent.Find("HelpScrollView").gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
