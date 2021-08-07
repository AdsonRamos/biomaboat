using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{
    public RawImage start;
    public RawImage quit;

    public Texture[] startTextures = new Texture[2];
    public Texture[] quitTextures = new Texture[2];

    // 0 - start; 1 - quit;
    public static int currentItem = 0;


    // Start is called before the first frame update
    void Start()
    {
        start.rectTransform.sizeDelta = currentItem == 0 ? new Vector2(110, 110) : new Vector2(100, 100);
        start.texture = startTextures[currentItem == 0 ? 0 : 1];
        quit.rectTransform.sizeDelta = currentItem == 0 ? new Vector2(100, 100) : new Vector2(110, 110);
        quit.texture = quitTextures[currentItem == 0 ?  1 : 0];
    }

    // Update is called once per frame
    void Update()
    {   
        start.rectTransform.sizeDelta = currentItem == 0 ? new Vector2(110, 110) : new Vector2(100, 100);
        start.texture = startTextures[currentItem == 0 ? 0 : 1];
        quit.rectTransform.sizeDelta = currentItem == 0 ? new Vector2(100, 100) : new Vector2(110, 110);
        quit.texture = quitTextures[currentItem == 0 ? 1 : 0];

        // if (Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        // {
        //     currentItem = currentItem == 0 ? 1 : 0;
        // }
    }
}
