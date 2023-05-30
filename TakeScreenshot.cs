using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using System;
using System.IO;
using OVR;


public class TakeScreenshot : MonoBehaviour
{
  public Camera targetCamera;
    public Transform barrel;
public float raycastDistance = 10f;
    public int captureWidth = 1920;
  public int captureHeight = 1080;
  public string captureFileName = "screenshot.png";
 RaycastHit hit;
  private void Update() {
    // Capture screenshot when the 'One' button on the Oculus Touch controller is pressed or the 'R' key is pressed
    if (OVRInput.GetUp(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.R))
      { 
       CaptureScreenshot();
       ShootRay();
       print("shoot");
      }
  }


  void ShootRay()
  {
        Debug.DrawRay(transform.position, barrel.forward * 1000, Color.green) ;
        if (Physics.Raycast(barrel.position, barrel.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Animal"))
            {
                print(hit);
                // If the ray hits an object with the specified layer, increase the score
                Destroy(hit.collider.gameObject);
                ScoreManager.main.addToList(hit.collider.name);
            }
        }

  }

  public void CaptureScreenshot() { 
   
    /**
     * Set the camera's target texture to a new RenderTexture with the desired size
     * Also keeps track of the texture before snapshot. This is so we can get the visual back to before the snapshot was made
     * else the camera breaks
     */
    RenderTexture oldTexture = targetCamera.targetTexture;
    RenderTexture newTexture = new RenderTexture(captureWidth, captureHeight, 24);
    targetCamera.targetTexture = newTexture;

    // Create a new texture with the size of the screen
    Texture2D screenTexture = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);

    // Render the camera's view to the target texture
    targetCamera.Render();

    // Read the pixels from the target texture into the screen texture.
    RenderTexture.active = newTexture;
    screenTexture.ReadPixels(new Rect(0, 0, captureWidth, captureHeight), 0, 0);
    RenderTexture.active = null;

    // Apply the texture to the material of the object this script is attached to
    screenTexture.Apply();

    // Convert the texture to a PNG file
    byte[] bytes = screenTexture.EncodeToPNG();

    // Creates Pictures directory if it doesn't exist
    string directoryPath = Path.Combine(Application.persistentDataPath, "Pictures");
    if (!Directory.Exists(directoryPath)) {
      Directory.CreateDirectory(directoryPath);
    }

    //Sets, and then Writes .png to Path location
    string filePath = Path.Combine(directoryPath, DateTime.Now.ToString("yyyyMMddHHmmss") + captureFileName);
    File.WriteAllBytes(filePath, bytes);
 
    Debug.Log("Screenshot saved to " + filePath);      
    newTexture.Release();
    targetCamera.targetTexture = oldTexture;
   
  }
}