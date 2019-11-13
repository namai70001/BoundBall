using UnityEngine;
using UnityEngine.UI;
using Framework.Singleton;

namespace Framework.Fade
{
    public class FadeManager : GameSingleton<FadeManager>
    {
        private enum FadeState
        {
            None, FadeIn, FadeOut
        }
        private FadeState state = FadeState.None;

        private float fadeTime;

        private GameObject fadeCanvasObject;
        private Image fadeImage;

        private string nextScene;

        private bool initialized = false;

        private float Alpha
        {
            get
            {
                return fadeImage.color.a;
            }
            set
            {
                fadeImage.color = new Color(0, 0, 0, value);
            }
        }

        private void Initialize()
        {
            fadeCanvasObject = new GameObject("FadeCanvas");
            fadeCanvasObject.transform.parent = transform;
            fadeCanvasObject.SetActive(false);

            Canvas fadeCanvas = fadeCanvasObject.AddComponent<Canvas>();
            fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            fadeCanvas.sortingOrder = 999;

            fadeCanvasObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            fadeCanvasObject.AddComponent<GraphicRaycaster>();

            GameObject fadeImageObject = new GameObject("FadeImage");
            fadeImageObject.transform.SetParent(fadeCanvasObject.transform, false);
            fadeImage = fadeImageObject.AddComponent<Image>();
            fadeImageObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
            fadeImage.color = Color.black;

            initialized = true;
        }

        private void Update()
        {
            if (state == FadeState.None) return;

            Alpha += Time.deltaTime / fadeTime * (state == FadeState.FadeIn ? 1f : -1f);

            if (Alpha > 0 && Alpha < 1) return;

            if (state == FadeState.FadeIn)
                FadeOut();
            else
                FadeFinish();
        }

        public void FadeIn(string nextScene, float fadeTime = 1.0f)
        {
            if (!initialized) Initialize();

            state = FadeState.FadeIn;
            fadeCanvasObject.SetActive(true);
            this.nextScene = nextScene;
            this.fadeTime = fadeTime;
            Alpha = 0.0f;
        }
        
        private void FadeOut()
        {
            state = FadeState.FadeOut;
        }

        private void FadeFinish()
        {
            state = FadeState.None;
            fadeCanvasObject.SetActive(false);
        }
    }
}
