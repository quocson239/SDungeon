using UnityEngine;


public class SimpleJoystick : MonoBehaviour
{
    public GameObject player;
    public GameObject joystickHandle;
    public GameObject joystickBackground;

    Vector2 coreBG;    
    Vector2 direct;

    void Start()
    {
        //MobileScreen
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    Vector3 mousePos;
    Vector3 mouseWPos;

    private void Update()
    {
        coreBG = joystickBackground.transform.position;
        mousePos = Input.mousePosition;
        mouseWPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWPos.z = 0;        
        if(!player.GetComponent<PlayerMovement>().isDash && !player.GetComponent<PlayerLife>().isDead) PlayerController();
    }

    public void OnPointerDown()
    {
        
    }

    public void OnDrag()
    {
        float x = Mathf.Clamp(mouseWPos.x, coreBG.x - 0.5f, coreBG.x + 0.5f);
        float y = Mathf.Clamp(mouseWPos.y, coreBG.y - 0.5f, coreBG.y + 0.5f);        
        joystickHandle.transform.position = new Vector2(x, y);                
    }

    public void OnPointerUp()
    {
        joystickHandle.transform.position = coreBG;
    }

    void PlayerController()
    {
        direct = (Vector2)joystickHandle.transform.position - coreBG;
        player.GetComponent<PlayerMovement>().move = direct;

        if ((player.GetComponent<PlayerMovement>().move.x == 0 && player.GetComponent<PlayerMovement>().move.y == 0))
        {
            player.GetComponent<PlayerMovement>().isRun = false;
        }
        else
        {
            player.GetComponent<PlayerMovement>().isRun = true;
            player.GetComponent<PlayerMovement>().lastX = direct.x;
            player.GetComponent<PlayerMovement>().lastY = direct.y;
        }
    }

     
   
}