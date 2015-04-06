using UnityEngine;
using System.Collections;
using Vuforia;

public class FocusMode : MonoBehaviour {
	
	private bool mVuforiaStarted = false;
	
	// Use this for initialization
	void Start () {
		QCARAbstractBehaviour qcar = (QCARAbstractBehaviour)FindObjectOfType( typeof(QCARAbstractBehaviour) );
		if (qcar) {
			qcar.RegisterQCARStartedCallback( OnQCARStarted );
		}
		else {
			Debug.Log ("Failed to find QCARBehaviour in current scene");
		}
	}
	
	private void OnQCARStarted()
	{
		Debug.Log ("Vuforia has started.");
		mVuforiaStarted = true;
		
		// Enable focus mode:
		bool autofocusOK = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		if (autofocusOK) {
			Debug.Log ("Successfully enabled Continuous Autofocus mode");
		}
		else {
			// set a different focus mode (for example, FOCUS_NORMAL):
			CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
			
			// Other possible options:
			// CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_MACRO);
			// CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_INFINITY);
		}
	}
}
