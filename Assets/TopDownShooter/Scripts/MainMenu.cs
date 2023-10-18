using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MainMenu : MonoBehaviour {

    private void Awake() {
        transform.Find("playBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        //transform.Find("websiteBtn").GetComponent<Button_UI>().ClickFunc = () => Application.OpenURL("https://unitycodemonkey.com");
        transform.Find("StartHost").GetComponent<Button_UI>().ClickFunc = () => GameManager.Instance.OnStartHostBtnClick();
        transform.Find("StartServer").GetComponent<Button_UI>().ClickFunc = () => GameManager.Instance.OnStartServerBtnClick();
        transform.Find("StartClient").GetComponent<Button_UI>().ClickFunc = () => GameManager.Instance.OnStartClientBtnClick();
    }

}
