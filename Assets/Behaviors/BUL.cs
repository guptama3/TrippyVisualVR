using UnityEngine;
using System.Collections;

public class BUL : MonoBehaviour {

    Vector3 OriginalPosition;
    // Use this for initialization
    void Start()
    {
        OriginalPosition = transform.position;
        StartCoroutine(move());
    }

    private IEnumerator move()
    {
        int startFrame;
        int endFrame;

        Vector3 startPosition;
        while (true)
        {
            startFrame = Time.frameCount;
            endFrame = startFrame + CreateSpheres.moveFrames;
            startPosition = transform.position;
            float t;
            while (Time.frameCount <= endFrame)
            {
                t = (float)(Time.frameCount - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.back*transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            for (int i = 0; i < CreateSpheres.stayFrames; i++)
                yield return null;

            startFrame = Time.frameCount;
            endFrame = startFrame + CreateSpheres.moveFrames;
            startPosition = transform.position;
            while (Time.frameCount <= endFrame)
            {
                t = (float)(Time.frameCount - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            for (int i = 0; i < CreateSpheres.stayFrames; i++)
                yield return null;

            startFrame = Time.frameCount;
            endFrame = startFrame + CreateSpheres.moveFrames;
            startPosition = transform.position;
            while (Time.frameCount <= endFrame)
            {
                t = (float)(Time.frameCount - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.left * transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            for (int i = 0; i < CreateSpheres.stayFrames; i++)
                yield return null;

            transform.position = OriginalPosition;
        }
    }
}
