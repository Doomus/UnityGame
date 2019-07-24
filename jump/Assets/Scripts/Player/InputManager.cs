using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode activate { get; set; }

    public static InputManager inputManager;

    private void Awake()
    {
        inputManager = this;
        activate = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("activate", "E"));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
