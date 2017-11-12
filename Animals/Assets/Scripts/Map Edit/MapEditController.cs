using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MapEdit))]
public class MapEditController : MonoBehaviour
{
    GamePlay game;
    CamFollow cam;
    Vector3 startLook, movement;

    bool hasObject;
    MapEdit map;

    void Start()
    {
        game = FindObjectOfType<GamePlay>();
        cam = Camera.main.GetComponent<CamFollow>();
        map = GetComponent<MapEdit>();
    }
    void Update ()
    {
        movement += new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * Time.deltaTime * 10;
        if (Input.GetKeyDown("e"))
            game.SetGameState(GamePlay.State.Paly);
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//左
            hasObject = map.ClickObject();
        if  (Input.GetMouseButton(0)&& hasObject)//左
            map.DragObject();
        if (Input.GetMouseButtonUp(0) && hasObject)//左
            hasObject = false;
        if ( Input.GetMouseButtonUp(1))//右
            map.RotateObject();
        if ( Input.GetMouseButtonUp(2))//中
            map.DestroyObject();
    }

    void LateUpdate()
    {
        if (cam != null)
            cam.SmoothFollow(startLook + movement, 20, 3, true, true);
    }
}

