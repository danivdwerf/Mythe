using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pooler.
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    /// <summary>
    /// The object to pool.
    /// </summary>
	[SerializeField]private GameObject objectToPool;
    /// <summary>
    /// The size of the pool.
    /// </summary>
	[SerializeField]private int poolSize;
	public int PoolSize{get{return poolSize;}}
    /// <summary>
    /// The pooled objects.
    /// </summary>
	private List<GameObject> pooledObjects;
	public List<GameObject> Pool{get{return pooledObjects;}}
    /// <summary>
    /// Boolean if pool should expand.
    /// </summary>
	[SerializeField]private bool shouldExpand;
    /// <summary>
    /// Reference to DrawLineToBones class.
    /// </summary>
	private DrawLineToBones drawer;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake()
    {
		drawer = this.GetComponent<DrawLineToBones> ();
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
			var obj = Instantiate (objectToPool) as GameObject;
			obj.name = "bone " + i;
			obj.transform.position = Vector3.zero;
			obj.transform.eulerAngles = new Vector3 (0, 0, 0);
			obj.SetActive (false);
			pooledObjects.Add (obj);
        }
    }

    /// <summary>
    /// Gets the object.
    /// </summary>
    /// <returns>The object.</returns>
    public GameObject getObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] == null)
                continue;
            
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (shouldExpand)
        {
			var obj = Instantiate(objectToPool) as GameObject;
			obj.name = "bone " + (pooledObjects.Count-1);
			obj.transform.position = Vector3.zero;
			obj.transform.eulerAngles = new Vector3 (0, 0, 0);
            obj.SetActive(false);
            pooledObjects.Add(obj);
			poolSize++;
			drawer.addToList (obj);
            return obj;
        }
        return null;
    }
}