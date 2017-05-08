using UnityEngine;
using UnityEngine.UI;

public class StartScreenUIHandler : MonoBehaviour 
{
    [SerializeField]private Button[] buttons;
    private LoadScene loadScene;
    private bool hold;
    private int index;

    private void Start()
    {
        loadScene = this.GetComponent<LoadScene>();
        index = 0;
        hold = false;
        selectButton();
    }

    private void interact()
    {
        if(index == 0)
            loadScene.loadScene(1);

        if(index == 1)
            CloseGame.Quit();
    }

    private void selectButton()
    {
        if (index > buttons.Length - 1)
            index = 0;

        if (index < 0)
            index = buttons.Length - 1;
        
        buttons[index].Select();
    }
        
    private void Update()
    {
        var xAxis = Input.GetAxisRaw (Controller.RightStickX);

        if (xAxis >= 0.01f && !hold)
        {
            index++;
            selectButton ();
            hold = true;
        }

        if (xAxis <= -0.01f && !hold)
        {
            index--;
            selectButton ();
            hold = true;
        }

        if (xAxis < 0.01f && xAxis > -0.01f)
            hold = false;

        if (Input.GetButtonDown(Controller.Cross))
            interact();
    }
}
