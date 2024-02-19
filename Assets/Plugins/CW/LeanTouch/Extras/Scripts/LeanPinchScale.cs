using UnityEngine;
using CW.Common;

namespace Lean.Touch
{
	/// <summary>This component allows you to scale the current GameObject relative to the specified camera using the pinch gesture.</summary>
	[HelpURL(LeanTouch.HelpUrlPrefix + "LeanPinchScale")]
	[AddComponentMenu(LeanTouch.ComponentPathPrefix + "Pinch Scale")]
	public class LeanPinchScale : MonoBehaviour
	{
		/// <summary>The method used to find fingers to use with this component. See LeanFingerFilter documentation for more information.</summary>
		public LeanFingerFilter Use = new LeanFingerFilter(true);

		/// <summary>The camera that will be used to calculate the zoom.
		/// None/null = MainCamera.</summary>
		public Camera Camera { set { _camera = value; } get { return _camera; } } [SerializeField] private Camera _camera;

		/// <summary>Should the scaling be performed relative to the finger center?</summary>
		public bool Relative { set { relative = value; } get { return relative; } } [SerializeField] private bool relative;
		
		/// <summary>The sensitivity of the scaling.
		/// 1 = Default.
		/// 2 = Double.</summary>
		public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } } [SerializeField] private float sensitivity = 1.0f;

		/// <summary>If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.
		/// -1 = Instantly change.
		/// 1 = Slowly change.
		/// 10 = Quickly change.</summary>
		public float Damping { set { damping = value; } get { return damping; } } [SerializeField] private float damping = -1.0f;

		[SerializeField]
		private Vector3 remainingScale;

		/// <summary>If you've set Use to ManuallyAddedFingers, then you can call this method to manually add a finger.</summary>
		public void AddFinger(LeanFinger finger)
		{
			Use.AddFinger(finger);
		}

		/// <summary>If you've set Use to ManuallyAddedFingers, then you can call this method to manually remove a finger.</summary>
		public void RemoveFinger(LeanFinger finger)
		{
			Use.RemoveFinger(finger);
		}

		/// <summary>If you've set Use to ManuallyAddedFingers, then you can call this method to manually remove all fingers.</summary>
		public void RemoveAllFingers()
		{
			Use.RemoveAllFingers();
		}

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Use.UpdateRequiredSelectable(gameObject);
		}
#endif

		protected virtual void Awake()
		{
			Use.UpdateRequiredSelectable(gameObject);
		}
		Vector3 refreshPosition = new Vector3(0,0,0);
		float MAXSCALE = 150;
		float MINSCALE = 10;

		private Vector2 startPos1;
		private Vector2 startPos2;

		protected virtual void Update()
		{

			if(refreshPosition.x == 0)
            {
				refreshPosition = transform.localPosition;
			}

			// Store
			var oldScale = transform.localPosition;

			// Get the fingers we want to use
			var fingers = Use.UpdateAndGetFingers();


			if (Input.touchCount == 2)
			{
				// Check if both touches just began, to set the start positions
				if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Began)
				{
					startPos1 = Input.GetTouch(0).position;
					startPos2 = Input.GetTouch(1).position;
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
				{
					// Calculate movement vectors based on the current touch position and start position
					Vector2 endPos1 = Input.GetTouch(0).position;
					Vector2 endPos2 = Input.GetTouch(1).position;

					bool? sameDirection = AreFingersMovingInSameDirection(startPos1, endPos1, startPos2, endPos2);
					if (sameDirection == null || sameDirection == true)
					{
						return;
						//   Debug.Log("Fingers moving in the same direction: " + sameDirection);
					} 

					// Update the start position for continuous tracking
					startPos1 = Input.GetTouch(0).position;
					startPos2 = Input.GetTouch(1).position;
				}
			}

			if (Input.touchCount >= 2)
			{
				var first = Input.GetTouch(0).position;
				var second = Input.GetTouch(1).position;
				float distance = Vector3.Distance(first, second);
				if (distance < 300)
				{
					return;
				}
			}
			// Calculate pinch scale, and make sure it's valid
			var pinchScale = LeanGesture.GetPinchScale(fingers);

			if (pinchScale != 1.0f)
			{
				pinchScale = Mathf.Pow(pinchScale, sensitivity);

				// Perform the translation if this is a relative scale
				if (relative == true)
				{
					var pinchScreenCenter = LeanGesture.GetScreenCenter(fingers);

					if (transform is RectTransform)
					{
						TranslateUI(pinchScale, pinchScreenCenter);
					}
					else
					{
						if (transform.localScale.x>MINSCALE && transform.localScale.x < MAXSCALE)
						Translate(pinchScale, pinchScreenCenter);
					}
				}

				//ZOOM OUT
				if (pinchScale > 1)
                {
					if(transform.localScale.x < MAXSCALE)
                    {
						zoom(pinchScale,oldScale);
					}
                }
				//ZOOM IN
                else
                {
					if (transform.localScale.x > MINSCALE)
					{
						zoom(pinchScale, oldScale);
					}

				}
			}
		} 

		    bool? AreFingersMovingInSameDirection(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, float threshold = 0.9f)
    {
        // Calculate movement vectors
        Vector2 movementVector1 = endPos1 - startPos1;
        Vector2 movementVector2 = endPos2 - startPos2;

        // Normalize the movement vectors
        Vector2 direction1 = movementVector1.normalized;
        Vector2 direction2 = movementVector2.normalized;
         
        // Compare directions using the dot product
        float dotProduct = Vector2.Dot(direction1, direction2);
     //   print("TAG dotProduct: " + dotProduct);
        // Check if the dot product is above the threshold
        if (dotProduct > 0) return true;
        else if (dotProduct < 0) return false;
        return null;
    }

		protected void zoom(float pinchScale,Vector3 oldScale)
        {
			transform.localScale *= pinchScale;
			remainingScale += transform.localPosition - oldScale;

			// Get t value
			var factor = CwHelper.DampenFactor(damping, Time.deltaTime);

			// Dampen remainingDelta
			var newRemainingScale = Vector3.Lerp(remainingScale, Vector3.zero, factor);

			// Shift this transform by the change in delta
			transform.localPosition = oldScale + remainingScale - newRemainingScale;

			// Update remainingDelta with the dampened value
			remainingScale = newRemainingScale;
		}

		protected virtual void TranslateUI(float pinchScale, Vector2 pinchScreenCenter)
		{
			var camera = _camera;

			if (camera == null)
			{
				var canvas = transform.GetComponentInParent<Canvas>();

				if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
				{
					camera = canvas.worldCamera;
				}
			}

			// Screen position of the transform
			var screenPoint = RectTransformUtility.WorldToScreenPoint(camera, transform.position);

			// Push the screen position away from the reference point based on the scale
			screenPoint.x = pinchScreenCenter.x + (screenPoint.x - pinchScreenCenter.x) * pinchScale;
			screenPoint.y = pinchScreenCenter.y + (screenPoint.y - pinchScreenCenter.y) * pinchScale;

			// Convert back to world space
			var worldPoint = default(Vector3);

			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.parent as RectTransform, screenPoint, camera, out worldPoint) == true)
			{
				transform.position = worldPoint;
			}
		}

		protected virtual void Translate(float pinchScale, Vector2 screenCenter)
		{
			// Make sure the camera exists
			var camera = CwHelper.GetCamera(_camera, gameObject);

			if (camera != null)
			{
				// Screen position of the transform
				var screenPosition = camera.WorldToScreenPoint(transform.position);

				// Push the screen position away from the reference point based on the scale
				screenPosition.x = screenCenter.x + (screenPosition.x - screenCenter.x) * pinchScale;
				screenPosition.y = screenCenter.y + (screenPosition.y - screenCenter.y) * pinchScale;

				// Convert back to world space
				transform.position = camera.ScreenToWorldPoint(screenPosition);
			}
			else
			{
				Debug.LogError("Failed to find camera. Either tag your cameras MainCamera, or set one in this component.", this);
			}
		}
	}

}

#if UNITY_EDITOR
namespace Lean.Touch.Editor
{
	using UnityEditor;
	using TARGET = LeanPinchScale;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(TARGET), true)]
	public class LeanPinchScale_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			TARGET tgt; TARGET[] tgts; GetTargets(out tgt, out tgts);

			Draw("Use");
			Draw("_camera", "The camera that will be used to calculate the zoom.\n\nNone/null = MainCamera.");
			Draw("relative", "Should the scaling be performed relative to the finger center?");
			Draw("sensitivity", "The sensitivity of the scaling.\n\n1 = Default.\n\n2 = Double.");
			Draw("damping", "If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.\n\n-1 = Instantly change.\n\n1 = Slowly change.\n\n10 = Quickly change.");
		}
	}
}
#endif