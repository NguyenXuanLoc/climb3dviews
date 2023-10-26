//
// Fingers Lite Gestures
// (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// Please see license.txt file
// 


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DigitalRubyShared
{
    public class DemoScript : MonoBehaviour
    {
        public GameObject Earth;
        private RotateGestureRecognizer rotateGesture;

        private void RotateGestureCallback(GestureRecognizer gesture)
        {
            print("TAG gesture.State: " + gesture.State);
            if (gesture.State == GestureRecognizerState.Executing)
            {
                Earth.transform.Rotate(0.0f, 0.0f, rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg);
            }
        }
         
        private void CreateRotateGesture()
        {
            rotateGesture = new RotateGestureRecognizer();
            rotateGesture.StateUpdated += RotateGestureCallback;
            FingersScript.Instance.AddGesture(rotateGesture);
        }

         
        private void Start()
        {
          
            CreateRotateGesture();
        }
    }
}
