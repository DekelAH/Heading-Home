using System;
using System.Collections;
using UnityEngine;

public class CubeFallingApart : MonoBehaviour
{
    #region Events

    public event Action IsFalling;

    #endregion

    #region Editor

    [SerializeField]
    private int _cubeNumPerAxis = 8;

    [SerializeField]
    private float _force = 300f;

    [SerializeField]
    private float _radius = 2f;

    [SerializeField]
    private float _delayToFallingApart;

    [SerializeField]
    private ParticleSystem _collapseSmoke;

    #endregion

    #region Fields

    private AudioManager _audioManager;
    private const string EARTHQUAKE_CLIP_NAME = "EarthQuakeAudio";

    #endregion

    #region Methods

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                CinemachineShaker.Instance.ShakeCamera(2f, 0.2f);
                _collapseSmoke.Play();
                StartCoroutine(SetFallingApartSurface(_delayToFallingApart));
                break;
        }
    }

    private IEnumerator SetFallingApartSurface(float waitForCollapse)
    {
        yield return new WaitForSeconds(waitForCollapse);
        _audioManager.PlaySound(EARTHQUAKE_CLIP_NAME);
        CinemachineShaker.Instance.ShakeCamera(5f, 0.5f);

        yield return new WaitForSeconds(3f);
        SetCubesSize();
        _collapseSmoke.Play();
        _audioManager.StopSound(EARTHQUAKE_CLIP_NAME);
        IsFalling?.Invoke();
    }

    private void SetCubesSize()
    {
        for (int x = 0; x < _cubeNumPerAxis; x++)
        {
            for (int y = 0; y < _cubeNumPerAxis; y++)
            {
                for (int z = 0; z < _cubeNumPerAxis; z++)
                {
                    CreateInternalCubesBySize(new Vector3(x, y, z));
                }
            }
        }

        gameObject.SetActive(false);
    }

    private void CreateInternalCubesBySize(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.tag = "Friendly";

        Renderer rndrr = cube.GetComponent<Renderer>();
        rndrr.material = GetComponent<Renderer>().material;

        cube.transform.localScale = transform.localScale / _cubeNumPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(_force, transform.position, _radius);
    }

    #endregion
}
