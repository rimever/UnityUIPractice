using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] public InputField _nameField;

    [SerializeField] private Image _playerImage;

    [SerializeField] private Slider _playerImageScaleSlider;

    [SerializeField] private Sprite _monsterSprite;

    [SerializeField] private Sprite _mermanSprite;

    [SerializeField] private Sprite _robotSprite;

    private PlayerType _playerType = PlayerType.Monster;

    private bool _isFlipPlayerImage;
    private float _playerImageScale = 1.0f;
    
    public bool IsFlipPlayerImage
    {
        set
        {
            _isFlipPlayerImage = value;
            UpdatePlayerImageScale();
        }
    }

    private void UpdatePlayerImageScale()
    {
        var scale = Vector3.one * (_playerImageScale * 0.4f + 0.6f);
        if (_isFlipPlayerImage) scale.x *= -1.0f;
        _playerImage.transform.localScale = scale;
    }

    public void ChangePlayerImageScale(float scale)
    {
        _playerImageScale = scale;
        UpdatePlayerImageScale();
    }

    public void Back()
    {
        Debug.Log("Back");
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void Submit()
    {
        Debug.Log($"Player Name: {_nameField.text}");
        Debug.Log($"Player Type: {_playerType}");
        Debug.Log($"Main Image Scale: {_playerImage.transform.localScale}");
    }

    public void ChangePlayerType(int index)
    {
        ChangePlayerType((PlayerType) index);
    }

    public void ChangePlayerType(PlayerType playerType)
    {
        if (playerType == _playerType) return;
        _playerType = playerType;
        switch (_playerType)
        {
            case PlayerType.Monster:
                _playerImage.sprite = _monsterSprite;
                break;
            case PlayerType.Merman:
                _playerImage.sprite = _mermanSprite;
                break;
            case PlayerType.Robot:
                _playerImage.sprite = _robotSprite;
                break;
        }

        _playerImage.SetNativeSize();
    }

    public enum PlayerType
    {
        Monster,
        Merman,
        Robot
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}