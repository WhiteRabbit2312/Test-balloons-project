using UnityEngine;
using System.IO;

namespace TestProject
{
    public class AvatarStorage
    {
        private readonly string FilePath = Path.Combine(Application.persistentDataPath, "playerAvatar.png");
        
        public void SaveAvatar(Texture2D texture)
        {
            if (texture == null)
            {
                return;
            }
            try
            {
                byte[] bytes = texture.EncodeToPNG();
                File.WriteAllBytes(FilePath, bytes);
            }
            catch (System.Exception e)
            {
                Debug.LogError("error to save: " + e.Message);
            }
        }
        
        public Sprite LoadAvatarAsSprite()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(FilePath);
                    Texture2D texture = new Texture2D(2, 2); 
                
                    if (ImageConversion.LoadImage(texture, bytes))
                    {
                        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Exception: " + e.Message);
                }
            }
            return null;
        }
    }
}