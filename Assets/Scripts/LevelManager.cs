using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelTile;
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    [SerializeField] private float tileLength;
    private Vector3 _spawnPoint => transform.position + transform.forward * offset;
    private List<GameObject> _activeTiles = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tile in _activeTiles)
        {
            tile.transform.Translate(-transform.forward * (speed * Time.deltaTime));
            if (tile.transform.position.z <= (transform.position - transform.forward * tileLength).z)
            {
                _activeTiles.Remove(tile);
                Destroy(tile);
                Spawn();
            }
        }
    }

    void Spawn()
    {
        var tile = Instantiate(levelTile, _spawnPoint, Quaternion.identity, transform);
        _activeTiles.Add(tile);
    }
    
    
    
}
