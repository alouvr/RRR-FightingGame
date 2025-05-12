using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public int HP;
    public int MaxHP;
    public int newHP;

    [SerializeField]
    private HealthBar _health;

    [SerializeField]
    private RectTransform _barRect;

    [SerializeField]
    private RectMask2D _mask;

    [SerializeField]
    private TMP_Text _hpIndicator;

    private float _maxRightMask;
    private float _initialRightMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //x = left, w = top, y = bottom, z = right
        _maxRightMask = _barRect.rect.width - _mask.padding.x - _mask.padding.z;
        _hpIndicator.SetText($"{_health.HP}/{_health.MaxHP}");
        _initialRightMask = _mask.padding.z;

    }

    public void SetValue(int newValue)
    {
        float targetWidth = newValue * _maxRightMask / _health.MaxHP;
        float newRightMask = _maxRightMask + _initialRightMask - targetWidth;
        var padding = _mask.padding;
        padding.z = newRightMask;
        _mask.padding = padding;
        _hpIndicator.SetText($"{newValue}/{_health.MaxHP}");
    }

    // Update is called once per frame
    void Update()
    {
        //SetValue(newHP);
    }
}
