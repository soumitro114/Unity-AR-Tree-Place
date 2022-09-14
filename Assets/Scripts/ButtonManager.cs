using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] private RawImage buttonImage;

    private int _itemId;
    private Sprite _buttonTexture;

    public int ItemId
    {
        set => _itemId = value;
    }
    public Sprite ButtonTexture 
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.3f);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            //transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
        //DataHandler.Instance.treez = tree;
        DataHandler.Instance.SetTrees(_itemId);
    }
}
