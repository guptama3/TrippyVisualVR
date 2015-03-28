using UnityEngine;
using System.Collections;

public class FDL : MonoBehaviour {

    Vector3 OriginalPosition;
    // Use this for initialization
    void Start()
    {
        OriginalPosition = transform.position;
        StartCoroutine(move());
    }

    public void OnReset()
    {
        StopAllCoroutines();
        transform.position = OriginalPosition;
        StartCoroutine(move());
    }


    private IEnumerator move()
    {
        float startFrame;
        float endFrame;

        Vector3 startPosition;
        while (true)
        {
            startFrame = Time.time;
            endFrame = Time.time + CreateSpheres.moveFrames;
            startPosition = transform.position;
            float t;
            while (Time.time <= endFrame)
            {
                t = (float)(Time.time - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.forward * transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            yield return new WaitForSeconds(CreateSpheres.stayFrames);

            startFrame = Time.time;
            endFrame = Time.time + CreateSpheres.moveFrames;
            startPosition = transform.position;
            while (Time.time <= endFrame)
            {
                t = (float)(Time.time - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.down * transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            yield return new WaitForSeconds(CreateSpheres.stayFrames);

            startFrame = Time.time;
            endFrame = Time.time + CreateSpheres.moveFrames;
            startPosition = transform.position;
            while (Time.time <= endFrame)
            {
                t = (float)(Time.time - startFrame) / (endFrame - startFrame);
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.left * transform.localScale.x, Mathf.SmoothStep(0.0f, 1.0f, t));
                yield return null;
            }

            yield return new WaitForSeconds(CreateSpheres.stayFrames);

            transform.position = OriginalPosition;
        }
    }
}
