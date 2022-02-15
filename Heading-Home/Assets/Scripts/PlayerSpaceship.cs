using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private float _thrustSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private int _fuel;

    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private AudioClip _thrustAudio;

    [SerializeField]
    private AudioClip _crashAudio;

    [SerializeField]
    private AudioClip _successAudio;

    [SerializeField]
    private AudioSource _audioSource;

    #endregion

    #region Methods

    private void Start()
    {

    }

    private void ProcessRotation(float rotationSpeed)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        _rigidBody.freezeRotation = false;
    }

    public void ProcessThrust()
    {
        _rigidBody.AddRelativeForce(_thrustSpeed * Time.deltaTime * Vector3.up);
    }

    public void LeftRotation()
    {
        ProcessRotation(_rotationSpeed);
    }

    public void RightRotation()
    {
        ProcessRotation(-_rotationSpeed);
    }

    public void CheckThrustSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_thrustAudio);
        }
    }

    public void CheckCrashSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_crashAudio);
        }
    }

    public void CheckSuccessSoundCondition()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_successAudio);
        }
    }

    #endregion

    #region Properties

    public float ThrustSpeed => _thrustSpeed;
    public float RotationSpeed => _rotationSpeed;
    public int Fuel => _fuel;
    public AudioSource AudioSource => _audioSource;

    #endregion
}
