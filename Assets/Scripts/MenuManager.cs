using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject startMenu;
    public InputField usernameField;
    private Button joinServerButton;
    private GameObject canvas;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }
        #endregion

        joinServerButton = GameObject.Find("JoinServerButton").GetComponent<Button>();
        canvas = gameObject;
    }

    private void Start()
    {
        joinServerButton.onClick.AddListener(() => { 
            this.ConnectToServer();
            canvas.SetActive(false);
        });
    }

    public void ConnectToServer()
    {
        Client.instance.ConnectToServer();
    }
}
