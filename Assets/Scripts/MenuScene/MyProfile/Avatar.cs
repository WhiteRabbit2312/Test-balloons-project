using System;
using System.Collections;
using System.Collections.Generic;
using TestProject;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private Button _takePicture;
        [SerializeField] private Button _pickImage;
        [SerializeField] private Image _avatarImage;
        private const int MaxSize = 512;
        public Texture2D NewAvatarTexture { get; private set; }

        private AvatarStorage _avatarStorage;

        [Inject]
        public void Construct(AvatarStorage avatarStorage)
        {
            _avatarStorage = avatarStorage;
        }

        private void Awake()
        {
            _takePicture.onClick.AddListener(TakePicture);
            _pickImage.onClick.AddListener(PickImage);
        }

        private void Start()
        {
            LoadAndDisplaySavedAvatar();
        }

        public void LoadAndDisplaySavedAvatar()
        {
            Sprite savedAvatar = _avatarStorage.LoadAvatarAsSprite();
            if (savedAvatar != null)
            {
                _avatarImage.sprite = savedAvatar;
            }
            else
            {
                Debug.LogError("Not loaded avatar");
            }
        }

        private void SetNewAvatar(Texture2D texture)
        {
            if (texture == null) return;

            NewAvatarTexture = texture;

            _avatarImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
        }

        private void PickImage()
        {
            NativeGallery.GetImageFromGallery((path) =>
            {
                if (path != null)
                {
                    Texture2D texture = NativeGallery.LoadImageAtPath(path, MaxSize, false);
                    if (texture == null)
                    {
                        return;
                    }

                    _avatarImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                    SetNewAvatar(texture);
                }
            });
        }

        private void TakePicture()
        {
            NativeCamera.TakePicture((path) =>
            {
                if (path != null)
                {
                    Texture2D texture = NativeCamera.LoadImageAtPath(path, MaxSize, false);
                    if (texture == null)
                    {
                        return;
                    }

                    _avatarImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                    SetNewAvatar(texture);
                }
            });
        }

        public void ClearNewAvatar()
        {
            NewAvatarTexture = null;
        }
    }
}