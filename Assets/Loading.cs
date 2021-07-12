using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
Image loadingImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsyc());
    }

    // Update is called once per frame
    IEnumerator LoadSceneAsyc()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone){
            //loadingImage.fillAmount = operation.progress;

            if (operation.progress >= 0.9f){
            operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
