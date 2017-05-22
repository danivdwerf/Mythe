using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start screen user interface handler.
/// </summary>
public class StartScreenUIHandler : MonoBehaviour 
{
    /// <summary>
    /// The buttons.
    /// </summary>
    [SerializeField]private Button[] buttons;
    /// <summary>
    /// Reference to LoadScene class.
    /// </summary>
    private LoadScene loadScene;
    /// <summary>
    /// Boolean if the stick is being hold.
    /// </summary>
    private bool hold;
    /// <summary>
    /// The current button index.
    /// </summary>
    private int index;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        loadScene = this.GetComponent<LoadScene>();
        index = 0;
        hold = false;
        selectButton();
    }

    /// <summary>
    /// Interact with a button.
    /// </summary>
    private void interact()
    {
        if(index == 0)
            loadScene.loadScene(1);

        if(index == 1)
            CloseGame.Quit();
    }

    /// <summary>
    /// Selects the button.
    /// </summary>
    private void selectButton()
    {
        if (index > buttons.Length - 1)
            index = 0;

        if (index < 0)
            index = buttons.Length - 1;
        
        buttons[index].Select();
    }
        
    /// <summary>
    /// Update this instance.
    /// </summary>
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
