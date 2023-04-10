using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_rotate : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public Toggle selectedToggle;
    // Start is called before the first frame update
    void Start()
    {
        selectedToggle.onValueChanged.AddListener(delegate {
            ToggleValueChangedOccured(selectedToggle);
        });
        
    }
    void ToggleValueChangedOccured(Toggle tglValue)
    {
        Utils.setRotate(tglValue.isOn);
      //  if(tglValue.isOn == true) camera.transform.Translate(new Vector3(0, 0 ,0));
    }
}
