using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastOperations : MonoBehaviour
{
    public GameObject blackHole;
    public GameObject createdImage;
    public GameObject backButton;
    public GameObject canvas;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    private bool isBlackHoleVisible=false;

    void Start()
    {
        blackHole.SetActive(false);
        createdImage.SetActive(false);
        backButton.SetActive(false);
    }

    public void blackHoleOperations()
    {
        if(!isBlackHoleVisible)
        {
            isBlackHoleVisible=true;
            blackHole.SetActive(true);
        }
        else
        {
            isBlackHoleVisible=false;
            blackHole.SetActive(false);
        }
    }

    bool GravCast(Vector3 startPos, Vector3 direction, Vector3 gravDir, int killAfter, int speed, out RaycastHit hit)
	{
        hit=new RaycastHit();
		Vector3[] vectors = new Vector3[killAfter];
        Vector3 normalizedD = (direction - startPos).normalized;
        Vector3 change=direction;
		Ray ray = new Ray(startPos, normalizedD);
		for (int i = 0; i < killAfter; i++)
		{
            //Debug.DrawRay(ray.origin, ray.direction, Color.blue, 10);
            if(Physics.Raycast(ray,out hit,1f))
			{
                //Debug.DrawRay(ray.origin, ray.direction, Color.blue, 10);
				return true;
			}
            change=(change*(speed-1)+gravDir)/speed;
            Vector3 normalizedChange=(change - ray.origin).normalized;
			ray = new Ray(ray.origin + ray.direction, normalizedChange);
			vectors[i] = ray.origin;

		}
		return false;
	}

    public void createImage()
    {
        if(isBlackHoleVisible)
        {
            for(int i=0; i<640; i++)
            {
                for(int j=0; j<480; j++)
                {
                    Color newPixelColor=Color.black;
                    float xPos=(float)i/640f;
                    float yPos=(float)j/480f;
                    Vector3 start = gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(xPos, yPos, 5));
                    Vector3 end = gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(xPos, yPos, 200));
                    Vector3 grav= blackHole.transform.position;
                    RaycastHit hit;
                    bool result=GravCast(start, end, grav, 500, 17, out hit);
                    if (result)
                    {
                        Renderer rend = hit.transform.GetComponent<Renderer>();
                        if (rend != null && rend.material.mainTexture != null)
                        {
                            Texture2D tex = rend.material.mainTexture as Texture2D;
                            Color pixelColor = tex.GetPixelBilinear( hit.textureCoord.x, hit.textureCoord.y );
                            var lightAppliedColor=pixelColor;
                            RaycastHit hit1;
                            RaycastHit hit2;
                            RaycastHit hit3;
                            if(!Physics.Raycast(hit.point, light1.transform.position, out hit1))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            if(!Physics.Raycast(hit.point, light2.transform.position, out hit2))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            if(!Physics.Raycast(hit.point, light3.transform.position, out hit3))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            newPixelColor=lightAppliedColor;
                        }
                    }
                    
                    createdImage.GetComponent<Image>().sprite.texture.SetPixel(i,j, newPixelColor);
                }
            }
            createdImage.GetComponent<Image>().sprite.texture.Apply();
        }
        else
        {
            for(int i=0; i<640; i++)
            {
                for(int j=0; j<480; j++)
                {
                    Color newPixelColor=new Color(0.1921569f, 0.3019608f, 0.4745098f);

                    float xPos=(float)i/640f;
                    float yPos=(float)j/480f;
                    Vector3 target = gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(xPos, yPos, 4000));
                    RaycastHit hit;
                    if (Physics.Raycast(gameObject.transform.position, target, out hit))
                    {
                        Renderer rend = hit.transform.GetComponent<Renderer>();
                        if (rend != null && rend.material.mainTexture != null)
                        {
                            Texture2D tex = rend.material.mainTexture as Texture2D;
                            Color pixelColor = tex.GetPixelBilinear( hit.textureCoord.x, hit.textureCoord.y );
                            var lightAppliedColor=pixelColor;
                            RaycastHit hit1;
                            RaycastHit hit2;
                            RaycastHit hit3;
                            if(!Physics.Raycast(hit.point, light1.transform.position, out hit1))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            if(!Physics.Raycast(hit.point, light2.transform.position, out hit2))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            if(!Physics.Raycast(hit.point, light3.transform.position, out hit3))
                                 lightAppliedColor=new Color(lightAppliedColor.r * 1.12f, lightAppliedColor.g * 1.12f, lightAppliedColor.b * 1.12f);
                            else
                                lightAppliedColor=new Color(lightAppliedColor.r * 0.9f, lightAppliedColor.g * 0.9f, lightAppliedColor.b * 0.9f);
                            newPixelColor=lightAppliedColor;
                        }
                    }
                    
                    createdImage.GetComponent<Image>().sprite.texture.SetPixel(i,j, newPixelColor);
                }
            }
            createdImage.GetComponent<Image>().sprite.texture.Apply();
        }

        createdImage.SetActive(true);
        backButton.SetActive(true);
    }

    public void onBackButtonPressed()
    {
        createdImage.SetActive(false);
        backButton.SetActive(false);
    }
}
