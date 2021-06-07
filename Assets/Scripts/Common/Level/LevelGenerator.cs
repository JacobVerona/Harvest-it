using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private static readonly Vector3[] _rotationEulers = new Vector3[]
    {
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 0f, 0f)
    };


    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _sceneGround;

    [SerializeField] private float _partScale;

    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _player;

    private Dictionary<char, GameObject> _gameObjects = new Dictionary<char, GameObject>();

    private void Awake ()
    {
        _gameObjects['g'] = _ground;
        _gameObjects['w'] = _wall;
        _gameObjects['p'] = _player;

        var level = ApplicationContext.Instance.CurrentLevel;
        var sizeX = level.Objects.GetLength(0);
        var sizeY = level.Objects.GetLength(1);

        for (int x = 0; x < sizeX + 2; x++)
        {
            for (int y = 0; y < sizeY + 2; y++)
            {
                if (x != 0 && y != 0 && x < sizeX + 1 && y < sizeY + 1)
                {
                    var gameObject = _gameObjects[level.Objects[x - 1, y - 1]];
                    Instantiate(gameObject, new Vector3(x * _partScale, 0, y * _partScale),
                        Quaternion.Euler(_rotationEulers[Random.Range(0, _rotationEulers.Length)]), transform);
                }
                else
                {
                    Instantiate(_wall, new Vector3(x * _partScale, 0, y * _partScale),
                        Quaternion.identity, transform);
                }
            }
        }

        var bounds = new Bounds(
             new Vector3((sizeX + 2) * _partScale / 2 - _partScale / 2, 1,
            (sizeY + 2) * _partScale / 2 - _partScale / 2),
             new Vector3((sizeX + 2) * _partScale,
            1, (sizeY + 2) * _partScale)
            );

        _camera.transform.position = bounds.center;
        _camera.transform.position = new Vector3(_camera.transform.position.x, bounds.size.x * 2f, -_camera.transform.position.z);

        _sceneGround.position = new Vector3(bounds.center.x, _sceneGround.position.y, bounds.center.z);
        _sceneGround.localScale = new Vector3(sizeX + 3, _sceneGround.localScale.y, sizeY + 3) ;
    }
}
