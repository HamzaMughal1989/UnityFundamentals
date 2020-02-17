using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
	public LayerMask clickableLayer;

	public Texture2D texturePointer;
	public Texture2D textureTarget;
	public Texture2D textureDoor;
	public Texture2D textureCombat;

	public EventVector3 OnClickEnvironment;

    void Update()
    {
		RaycastHit hit;
		// if mouse click is clicking the clickable layer
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, clickableLayer.value))
		{
			bool isDoor = false;
			if (hit.collider.gameObject.tag == "Doorway")
			{
				Cursor.SetCursor(textureDoor, new Vector2(16, 16), CursorMode.Auto);
				isDoor = true;
			}
			else
			{
				Cursor.SetCursor(textureTarget, new Vector2(16, 16), CursorMode.Auto);
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (isDoor)
				{
					OnClickEnvironment.Invoke(hit.collider.gameObject.transform.position);
				}
				else
				{
					OnClickEnvironment.Invoke(hit.point);
				}
			}
		}
		else
		{
			Cursor.SetCursor(texturePointer, Vector2.zero, CursorMode.Auto);
		}
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }
