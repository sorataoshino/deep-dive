using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [SerializeField] RawImage _compassImage;
    [SerializeField] Transform _player;
    [SerializeField] Transform _mainCamera;
    [SerializeField] GameObject _iconPrefab;

    public float MarkMaxDistance = 150;

    List<CompassMark> _marks = new List<CompassMark>();

    float compassUnit;

    public void Initialize()
    {
        compassUnit = _compassImage.rectTransform.rect.width / 360f;

        var marks = FindObjectsOfType(typeof(CompassMark));

        foreach (CompassMark mark in marks)
        {
            AddCompassMark(mark);
        }
    }

    private void Update()
    {
        foreach (CompassMark mark in _marks)
        {
            mark.Image.rectTransform.anchoredPosition = GetPositionOnCompass(mark);

            float dst = Vector2.Distance(new Vector2(_player.transform.position.x, _player.transform.position.z), mark.position);
            float scale = 0f;

            if (dst < MarkMaxDistance)
            {
                scale = 1f - (dst / MarkMaxDistance);
            }

            mark.Image.rectTransform.localScale = Vector3.one * scale;
        }    
    }

    void AddCompassMark(CompassMark mark)
    {
        GameObject newMark = Instantiate(_iconPrefab, _compassImage.transform);
        mark.Image = newMark.GetComponent<Image>();
        mark.Image.sprite = mark.Icon;

        _marks.Add(mark);
    }

    Vector2 GetPositionOnCompass(CompassMark mark)
    {
        Vector2 playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 cameraFwd = new Vector2(_mainCamera.transform.forward.x, _mainCamera.transform.forward.z);

        float angle = Vector2.SignedAngle(mark.position - playerPos, cameraFwd);

        return new Vector2(compassUnit * angle, 0f);
    }

    public void RemoveCompassMark(CompassMark mark)
    {
        _marks.Remove(mark);
    }
}
