using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EjemploObjectPooling : MonoBehaviour
{
    [SerializeField] int _maxPoolSize = 10;
    private ObjectPool<GameObject> _pool;
    [SerializeField] float _tiempoSpawn = 1;
    [SerializeField] float _velocidadCaida =1f;
    [SerializeField] private GameObject _gotaAgua;
    [SerializeField] float _xSpawnMin;
    [SerializeField] float _xSpawnMax;
    [SerializeField] float _limiteInferior;
    [SerializeField] float _limiteSuperior;
    float _spawnCounter;

    List<GameObject> gotasActivas = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnCounter = 0;
        _pool = new ObjectPool<GameObject>(
            CreatePooledItem,
            OnTakeFromPool,
            OnReturnedToPool,
            collectionCheck: true,
            maxSize: _maxPoolSize
            );
        _gotaAgua.SetActive(false);



    }

    private void OnReturnedToPool(GameObject gota)
    {
        gota.SetActive( false );
        gotasActivas.Remove( gota );
    }

    private void OnTakeFromPool(GameObject gota)
    {
        gota.SetActive( true );
        gota.transform.position = new Vector3(UnityEngine.Random.Range(_xSpawnMin, _xSpawnMax), _limiteSuperior, 0f);
        gotasActivas.Add( gota );
    }

    private GameObject CreatePooledItem()
    {
        return Instantiate(_gotaAgua, new Vector3(UnityEngine.Random.Range(_xSpawnMin, _xSpawnMax), _limiteSuperior, 0f),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> gotasParaLiberar = new List<GameObject>();
        foreach (var gota in gotasActivas)
        {
            gota.transform.position += Vector3.down * _velocidadCaida * Time.deltaTime;
            if (gota.transform.position.y < _limiteInferior)
            {
                gotasParaLiberar.Add(gota);
            }    
        }
        foreach (var gota in gotasParaLiberar)
            _pool.Release(gota);

        if (_spawnCounter > _tiempoSpawn && gotasActivas.Count < _maxPoolSize)
        {
            _spawnCounter = 0;
            _pool.Get();
        }
        _spawnCounter += Time.deltaTime;
    }
}
