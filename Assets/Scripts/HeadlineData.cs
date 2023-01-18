using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Headline", menuName = "Headline", order = 51)]
public class HeadlineData : ScriptableObject
{
    
    [SerializeField]
    [TextArea(3, 5)]
    private string title;

    [SerializeField]
    [TextArea(3, 5)]
    private string time;

    [SerializeField]
    private Sprite image;




    public string Title
    {
        get
        {
            return title;
        }
    }
    public string Time 
    {
        get
        {
            return time;
        }
    }
   
    public Sprite Image
    {
        get
        {
            return image;
        }
    }

}
