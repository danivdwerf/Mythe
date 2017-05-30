using UnityEngine;
/// <summary>
/// Spawn bone.
/// </summary>
public class SpawnBone : MonoBehaviour 
{
    /// <summary>
    /// The spawn off set y.
    /// </summary>
	[SerializeField]private float spawnOffSetY;
    /// <summary>
    /// Reference to DrawLineToBones class.
    /// </summary>
	private DrawLineToBones bones;
    /// <summary>
    /// Reference to ObjectPooler class.
    /// </summary>
    private ObjectPooler bonePool;
    /// <summary>
    /// The player.
    /// </summary>
	private GameObject player;
    /// <summary>
    /// The amount of bones.
    /// </summary>
	private int amountOfBones;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		player = this.gameObject;
        bones = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<DrawLineToBones>();
        bonePool = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectPooler>();
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
			spawnBone ();
	}

    /// <summary>
    /// Adds a bone.
    /// </summary>
	public void addBone()
	{
		amountOfBones++;
	}

    /// <summary>
    /// Spawns the bone.
    /// </summary>
	private void spawnBone()
	{
		if (amountOfBones < 1)
			return;
		
		var newBone = bonePool.getObject ();
		if (newBone == null)
			return;
		
		amountOfBones--;
		newBone.transform.position = player.transform.position - new Vector3(0, spawnOffSetY, 0);
		newBone.SetActive (true);
		bones.drawLines ();
	}
}
