using UnityEngine;


[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public enum ControlMethod { Keyboard_Mouse1, Keyboard, Keyboard_Mouse2, Keyboard_Mouse3 };
    public ControlMethod control;
    [Range(1, 10)]
    public float mouseXSpeed = 5;
    [Range(1, 10)]
    public float mouseYSpeed = 5;
    public float minDist = 5;
    public float maxDist = 10;
    GamePlay game;
    Player player;
    CamFollow cam;
    float moveH, moveV, mouseX, mouseY, mouseSW = 5;
    bool jump;

    void Start()
    {
        game = FindObjectOfType<GamePlay>();
        player = GetComponent<Player>();
        cam = Camera.main.GetComponent<CamFollow>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            game.SetGameState(GamePlay.State.MapEdit);
    }
    void FixedUpdate()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");
        mouseX += Input.GetAxis("Mouse X") * mouseXSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * mouseYSpeed;
        if (mouseX > 360) mouseX -= 360;
        else if (mouseX < 0) mouseX += 360;
        if (mouseY > 90) mouseY = 90;
        else if (mouseY < 0) mouseY = 0;

        player.MoveAndJump((int)control, mouseX, moveH, moveV, jump);
    }
    void LateUpdate()
    {
        if (cam != null)
        {
            mouseSW -= Input.GetAxis("Mouse ScrollWheel") * 5;
            mouseSW = Mathf.Clamp(mouseSW, minDist, maxDist);
            if (control == 0)
                cam.MouseView(transform, mouseX, mouseY, mouseSW);
            else
                cam.SmoothFollow(transform.position, mouseSW, mouseSW / 2, true, true);
        }
    }
}

