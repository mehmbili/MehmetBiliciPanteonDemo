using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paint : MonoBehaviour
{   
    public MeshRenderer meshRenderer;//boyayacaðýmýz obje
    public Texture2D brush; //fýrça texture
    public Vector2Int textureArea; // x:512 y:512
    Texture2D textures;
    public float percentage;
    public TextMeshProUGUI percentageText;
    
    private void Start()
    {
        textures = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        meshRenderer.material.mainTexture = textures;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))//sol týka basýlý tuttukça boyayacak
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hitInfo))
            {
               
                StartPaint(hitInfo.textureCoord);
            }

        }
        percentage = ((100 * GetRedPixels()) / (textures.width * textures.height));
        percentageText.text = percentage.ToString() + "/100";
        
    }
    int GetRedPixels()
    {
        var pixels = textures.GetPixels();
        var count = 0;
        foreach(var color in pixels)
        {
            if(color.r>0.7f && color.g<0.2f && color.b < 0.2f)
            {
                count++;
            }
            else
            {
                continue;
            }
        }
        return count;
    }
    void StartPaint(Vector2 coordinate) {
        coordinate.x *= textures.width;//0-1 deðerini tam nokta piksellere çevirdik
        coordinate.y *= textures.height; // 0-1024 yaptýk
        Color32[] texPixels = textures.GetPixels32();
        Color32[] brushC32 = brush.GetPixels32();



        //Fýrçanýn ortasýnýn koordinatlarý
        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        for(int x = 0; x < brush.width; x++)
        {
            int xPos = x - halfBrush.x + (int)coordinate.x;
            if (xPos < 0 || xPos >= textures.width)
                continue;
            for(int y = 0; y < brush.height; y++)
            {
                int yPos = y - halfBrush.y + (int)coordinate.y;
                if (yPos < 0 || yPos >= textures.height)
                    continue;
                if (brushC32[x + (y * brush.width)].a > 0)
                {
                    int tPos = xPos + (textures.width * yPos);
                    //if (brushC32[x+(y*brush.width)].r<texPixels[tPos].r)
                    if (brushC32[x+(y*brush.width)].r>texPixels[tPos].r)
                        texPixels[tPos] = brushC32[x + (y * brush.width)];
                }
            }
        }
        textures.SetPixels32(texPixels);
        textures.Apply();
    }
}
