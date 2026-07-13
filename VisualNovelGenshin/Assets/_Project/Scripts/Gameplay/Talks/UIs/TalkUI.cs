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
                        text.maxVisibleCharacters = text.textInfo.characterCount;
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                var talkTexts = talkPhaseUI.TalkTexts;
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
            int totalCharacters = text.textInfo.characterCount;

            for (int i = 0; i <= totalCharacters; i++)
            {
                text.maxVisibleCharacters = i;
                await Awaitable.WaitForSecondsAsync(.3f, token);
            }
            
            await Awaitable.WaitForSecondsAsync(1f, token);
            talkPhaseUI.NextTalk(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            cts.Cancel();

            if (text.maxVisibleCharacters == text.textInfo.characterCount)
                talkPhaseUI.NextTalk(true);
            
        }

        private void OnDestroy()
        {
            cts?.Cancel();
            cts?.Dispose();
        }
    }
}