using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Headline : MonoBehaviour
{
    public HeadlineData headlineData;
    public ContentData contentData;
    public Button button;

    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI date;

    public void Start()
    {
        button = GetComponent<Button>();

        image.sprite = headlineData.Image;
        title.text = headlineData.Title;
        date.text = headlineData.Date;

        button.onClick.AddListener(delegate
        {
            UIManager.instance.ShowPanelData(contentData);
        });

    }
}
