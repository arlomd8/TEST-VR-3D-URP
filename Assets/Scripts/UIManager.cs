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
    public TextMeshProUGUI dateText;
    public Image imageHeadline;

    [Header("Content")]
    public TextMeshProUGUI headingText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI descText;
    public string sceneText;
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


    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "ChooseMode")
        {
            forward.transform.eulerAngles = new Vector3(0, camera.eulerAngles.y, 0);
        }
    }
    public void ShowPanelData()
    {
        panelContent.transform.eulerAngles = new Vector3(0, forward.eulerAngles.y, 0);

        panelContent.SetActive(true);
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HidePanelData()
    {
        panelContent.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit(0);
    }


}
