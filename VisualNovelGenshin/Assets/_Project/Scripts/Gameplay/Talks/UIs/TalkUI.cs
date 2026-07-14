using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Scripts.Talks.UIs
{
    public class TalkUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private TMP_Text text;

        private CancellationTokenSource cts;
        private TalkPhaseUI talkPhaseUI;
        
        private int TotalCharacters => text.text.Length;
        private bool IsAllShown => text.maxVisibleCharacters == text.text.Length;
        
        public async void Sync(TalkPhaseUI phaseUI)
        {
            try
            {
                cts?.Cancel();
                cts?.Dispose();

                cts = CancellationTokenSource.CreateLinkedTokenSource(destroyCancellationToken);

                talkPhaseUI = phaseUI;
                for (int i = 0; i < talkPhaseUI.TalkTexts.Length; i++)
                {
                    var talkText = talkPhaseUI.TalkTexts[i];
                    text.text = talkText;
                    text.maxVisibleCharacters = 0;
                    try
                    {
                        await ShowCharacters(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        text.maxVisibleCharacters = TotalCharacters;
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void ClearUI()
        {
            text.text = string.Empty;
        }
        
        private async Awaitable ShowCharacters(CancellationToken token)
        {
            for (int i = 0; i <= TotalCharacters; i++)
            {
                text.maxVisibleCharacters = i;
                await Awaitable.WaitForSecondsAsync(.1f, token);
            }
            
            await Awaitable.WaitForSecondsAsync(1f, token);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (IsAllShown)
            {
                case true:
                    talkPhaseUI.NextTalk(true);
                    return;
                
                case false:
                    cts.Cancel();
                    return;
            }
        }

        private void OnDestroy()
        {
            cts?.Cancel();
            cts?.Dispose();
        }
    }
}