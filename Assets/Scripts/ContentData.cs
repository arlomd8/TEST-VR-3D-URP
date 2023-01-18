using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Content", menuName = "Content", order = 52)]
public class ContentData : ScriptableObject
{
    [SerializeField]
    private string heading;

    [SerializeField]
    [TextArea(3, 5)]
    private string title;

    [SerializeField]
    [TextArea(3, 5)]
    private string speaker;

    [SerializeField]
    [TextArea(5, 5)]
    private string description;

    [SerializeField]
    private Sprite image;

    [SerializeField]
    private string scene;

    public string Title
    {
        get
        {
            return title;
        }
    }
    public string Heading
    {
        get
        {
            return heading;
        }
    }
    public string Speaker
    {
        get
        {
            return speaker;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
    }
    public Sprite Image
    {
        get
        {
            return image;
        }
    }

    public string Scene
    {
        get
        {
            return scene;
        }
    }

}

