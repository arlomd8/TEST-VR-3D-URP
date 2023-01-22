using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Transform camera, forward;

    [Header("Headline")]
    public TextMeshProUGUI headlineTitleText;
    public List<GameObject> headlines;
    public Transform parentHeadline;
    public GameObject headlinePanel;

    [Header("Content")]
    public Transform parentContent;
    public TextMeshProUGUI headingText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI descText;
    public string sceneText;
    public int sceneIndex;
    public Image imageContent;

    public GameObject joinButton, panelContent;

    public ContentData contentData;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < headlines.Count; i++)
        {
            Transform child = Instantiate(headlines[i].transform, parentHeadline.transform.position, parentHeadline.transform.rotation, parentHeadline);
            child.transform.SetParent(parentHeadline.transform);
        }
    }
    public void ShowPanelData(ContentData content)
    {
       
        contentData = content;
        descText.text = content.Description;
        headingText.text = content.Heading;
        titleText.text = content.Title;
        speakerText.text = content.Speaker;
        sceneText = content.Scene;
        sceneIndex = content.SceneIndex;
        imageContent.sprite = content.Image;

        panelContent.SetActive(true);
        headlinePanel.SetActive(false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(parentContent as RectTransform);
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    //public void JoinButton() { ChangeScene(sceneText); }

    public void HidePanelData()
    {
        panelContent.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit(0);
    }


}
