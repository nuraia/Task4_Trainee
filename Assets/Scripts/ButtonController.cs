using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;


public class ButtonWorks : MonoBehaviour
{
    public DictionaryBasics db;
    public Canvas canvas;
    public RectTransform panel;
    public Image MainImage;
    public Button buttonprefab;
    private TextMeshProUGUI buttonText;
    private Image buttonImage;
    public TextMeshProUGUI invalidText;
    private Vector3 targetScale = new Vector3(1, 1, 1);
    private Vector3 initialScale = new Vector3(0, 0, 0);
    private void Start()
    {

        for(int i = 0; i < db.Name.Count; i++)
        {
           ButtonCreate(i);
        }
        Button extraButton = Instantiate(buttonprefab, panel);
        extraButton.onClick.AddListener(() => OnClick(null));
    }


    [ContextMenu("ButtonCreate")]

    public void ButtonCreate(int index)
    {
        Button button = Instantiate(buttonprefab, panel);

        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonImage = button.GetComponentInChildren<Image>();

        buttonImage.sprite = db.Image[index];
        buttonText.text = db.Name[index];

        button.onClick.AddListener(() => OnClick(db.Image[index]));
    }
   public void OnClick(Sprite buttonImage)
    {
        if (buttonImage != null)
        {
            MainImage.sprite = buttonImage;
        }
        else
        {
            invalidText.gameObject.SetActive(true);
            invalidText.transform.DOScale(targetScale, 1)
            .OnComplete(() => {
                StartCoroutine(ScaleDown());
            });
        }
    }

    IEnumerator ScaleDown()
    {
        yield return new WaitForSeconds(1.5f);
        invalidText.transform.DOScale(initialScale, 1);
        invalidText.gameObject.SetActive(false);

    }
}
