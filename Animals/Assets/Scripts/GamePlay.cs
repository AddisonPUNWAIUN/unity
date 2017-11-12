using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Transform UI;
    public enum State { Paly,MapEdit };
    PlayerController playCtrl;
    MapEditController mapCtrl;

    void Awake()
    {
        playCtrl = FindObjectOfType<PlayerController>();
        mapCtrl = FindObjectOfType<MapEditController>();
        //player = FindObjectOfType<Player>();
        //cam = FindObjectOfType<CamFollow>();
    }

    void Start()
    {
        SetGameState(State.Paly);
    }

    void Update()
    {

    }
    public void SetGameState(State state)
    {
        if (UI != null)
            if (state == State.Paly) 
            {
                playCtrl.gameObject.SetActive(true);
                mapCtrl.enabled = false;
                UI.Find("Mode/Text").GetComponent<Text>().text = "測試...";
                UI.Find("Info/Play").GetComponent<Text>().enabled = true;
                UI.Find("Info/Edit").GetComponent<Text>().enabled = false;
                UI.Find("Model List").gameObject.SetActive(false);
            }
            else if (state == State.MapEdit)
            {
                playCtrl.gameObject.SetActive(false);
                mapCtrl.enabled = true;
                UI.Find("Mode/Text").GetComponent<Text>().text = "編輯地圖...";
                UI.Find("Info/Play").GetComponent<Text>().enabled = false;
                UI.Find("Info/Edit").GetComponent<Text>().enabled = true;
                UI.Find("Model List").gameObject.SetActive(true);
            }
    }
}