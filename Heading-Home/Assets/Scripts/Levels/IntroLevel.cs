using UnityEngine;

public class IntroLevel : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Transform[] _spaceshipPath;

    [SerializeField]
    private PlayerSpaceship _playerSpaceship;

    [SerializeField]
    private Animator _playerSpaceshipAnim;

    [SerializeField]
    private LevelLoader _levelLoader;

    [SerializeField]
    private float _moveSpeed;

    #endregion

    #region Methods

    private void Start()
    {
        PlayerSpaceshipIntroAnimation(_moveSpeed);
    }

    private void Update()
    {
        PlayRocketFlamesByIntroSteps();
    }

    private void PlayerSpaceshipIntroAnimation(float speed)
    {
        _playerSpaceshipAnim.speed = speed;
        _playerSpaceshipAnim.Play("SpaceshipIntroAnim");
    }

    private void PlayRocketFlamesByIntroSteps()
    {
        if (_playerSpaceship.transform.position.y < _spaceshipPath[5].position.y && _playerSpaceship.transform.position.y > _spaceshipPath[6].position.y)
        {
            _playerSpaceship.StopRocketFlames();
            _playerSpaceship.StopSpeedEffect();
            _playerSpaceship.TriggerLeftFlame();
            _playerSpaceship.TriggerRightFlame();
        }
        else if (_playerSpaceship.transform.position.y >= _spaceshipPath[5].position.y)
        {
            _playerSpaceship.TriggerRocketFlames();
            _playerSpaceship.TriggerSpeedEffect();
        }

        else if (_playerSpaceship.transform.position.y < 1.3f)
        {
            _playerSpaceship.StopSideFlames();
            _playerSpaceshipAnim.enabled = false;
        }
    }

    #endregion
}
