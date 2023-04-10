using UnityEngine;
using UnityEngine.EventSystems;

public class PinchToZoomAndShrink : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isDragging;
    private float _currentScale, _scaleRate, _temp;
    private float minScale, maxScale;

    void Start()
    {
        _currentScale = transform.localScale.x;
    }

    void Update()
    {
        if (_isDragging)
        {
            if (Input.touchCount == 2)
            {
                transform.localScale = new Vector3(_currentScale, _currentScale);
                float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (_temp > distance)
                {
                    if (_currentScale < minScale)
                    {
                        return;
                    }
                    else
                    {
                        _currentScale -= (Time.deltaTime) * _scaleRate;
                    }
                }
                else if (_temp < distance)
                {
                    if (_currentScale >= minScale)
                    {
                        return;
                    }
                    else
                    {
                        _currentScale += (Time.deltaTime) * _scaleRate;
                    }
                }
                _temp = distance;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 2)
        {
            _isDragging = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }
}