using UnityEngine;
using System.Collections;

public class DrawLineManager : MonoBehaviour {

    public Material lMat;

    public SteamVR_TrackedObject trackedObj;

    private MeshLineRenderer currLine;

    private int numClicks = 0;
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index); // Asks for input, whatever tracked object's index is
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {  // Checks if we've pulled the trigger
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();

            currLine.lmat = new Material(lMat);
            currLine.setWidth(.04f);

        } else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            //currLine.SetVertexCount(numClicks + 1);
            //currLine.SetPosition(numClicks, trackedObj.transform.position);

            currLine.AddPoint(trackedObj.transform.position);
            numClicks++;
        } else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            numClicks = 0;
            currLine = null;
        }

            if (currLine != null) {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor();
        }
	}
}
