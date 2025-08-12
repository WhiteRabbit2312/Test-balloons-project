using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avatar : MonoBehaviour
{
    [SerializeField] private Button _takePicture;
    [SerializeField] private Button _pickImage;
    [SerializeField] private Image _avatarImage;
    private const int MaxSize = 512;
    private void Awake()
    {
        _takePicture.onClick.AddListener(TakePicture);
        _pickImage.onClick.AddListener(PickImage);
    }

    private void PickImage()
    {
        NativeGallery.GetImageFromGallery( ( path ) =>
        {
            if( path != null )
            {
                Texture2D texture = NativeGallery.LoadImageAtPath( path, MaxSize );
                if( texture == null )
                {
                    return;
                }

                _avatarImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        } );
    }
    
    private void TakePicture()
    {
        NativeCamera.TakePicture( ( path ) =>
        {
            if( path != null )
            {
                Texture2D texture = NativeCamera.LoadImageAtPath( path, MaxSize );
                if( texture == null )
                {
                    return;
                }

                _avatarImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        });
    }
}
