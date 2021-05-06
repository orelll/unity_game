using System.Collections.Generic;
using UnityEngine;

public class FrogAreaController : MonoBehaviour
{
    public GameObject PlayerReference;
    public GameObject FrogPrefab;
    public GameObject SpawnArea;
    private PolygonCollider2D _spawnerCollider;
    private List<GameObject> _frogsList;

    private Bounds _bounds;
    // Start is called before the first frame update
    void Start()
    {
        _frogsList = new List<GameObject>();
        _spawnerCollider = GetComponent<PolygonCollider2D>();
        _bounds = _spawnerCollider.bounds;
        SpawnGem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnGem()
    {
        var newX = Random.Range(_bounds.min.x, _bounds.max.x);
        var newY = Random.Range(_bounds.min.y, _bounds.max.y);

        var newPosition = new Vector3(newX, newY, _bounds.min.z);

        //stworzyć instancję prefaba na pozycji XYZ
        var newGem = Instantiate(FrogPrefab, newPosition, new Quaternion());

        //przypisać gem do GemSpawnera
        newGem.transform.parent = SpawnArea.transform;
        _frogsList.Add(newGem);
    }
}
