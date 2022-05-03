using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLobby : MonoBehaviour
{
    AsyncOperation asyncOperation;

    [SerializeField] private Image _loadBar;
    [SerializeField] private Text _barTxt;
    

    public void LoadLevel(int SceneID)
    {
        StartCoroutine(LoadSceneCor(SceneID));
    }

    private IEnumerator LoadSceneCor(int SceneID)
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        while(!asyncOperation.isDone)
            {
            float progress = asyncOperation.progress / 0.9f;
            _loadBar.fillAmount = progress;
            _barTxt.text = "Загрузка " + string.Format("{0:0}%", progress * 100f);
            yield return 0;
            }
    }
}
