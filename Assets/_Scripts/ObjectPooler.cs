using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	[SerializeField]private GameObject objectToPool;
	[SerializeField]private int poolSize;
	public int PoolSize{get{return poolSize;}}

	private List<GameObject> pooledObjects;
	public List<GameObject> Pool{get{return pooledObjects;}}
	[SerializeField]private bool shouldExpand;
	private DrawLineToBones drawer;

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

    public GameObject getObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
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