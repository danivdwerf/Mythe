using UnityEngine;
/// <summary>
/// Throw axe.
/// </summary>
public class ThrowAxe : MonoBehaviour 
{
    /// <summary>
    /// The throw power.
    /// </summary>
	[SerializeField]private float throwPower;
    /// <summary>
    /// The axe.
    /// </summary>
	[SerializeField]private GameObject axe;
    [SerializeField]private GameObject hand;
    private Animator anim;
    static readonly int _inHand = Animator.StringToHash("inHand");
    /// <summary>
    /// Reference to the Rigidbody.
    /// </summary>
	private Rigidbody rigid;
    /// <summary>
    /// Boolean if axe is in hand.
    /// </summary>
	private bool inHand;

    private AudioManager audioManager;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
        anim = hand.GetComponent<Animator>();
		rigid = axe.GetComponent<Rigidbody> ();
        audioManager = this.GetComponent<AudioManager>();
        inHand = true;
		rigid.useGravity = false;
		rigid.isKinematic = true;
        anim.SetBool(_inHand, true);
	}

    /// <summary>
    /// Throws the axe.
    /// </summary>
	public void throwAxe()
	{
		if (!inHand)
			return;
        
		inHand = false;
		axe.transform.SetParent (null);
		rigid.useGravity = true;
		rigid.isKinematic = false;
		var dir = Camera.main.transform.forward + new Vector3 (0, 0.3f, 0);
		rigid.AddForce (dir  * throwPower, ForceMode.Impulse);
        audioManager.playSound("AxeThrow");
        anim.SetBool(_inHand, false);
	}

    /// <summary>
    /// Resets the axe to be in the hand.
    /// </summary>
	public void axeInHand()
	{
		inHand = true;
		rigid.useGravity = false;
		rigid.isKinematic = true;
		rigid.velocity = Vector3.zero;
        anim.SetBool(_inHand, true);
	}
}
