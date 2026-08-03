namespace Project.Gameplay.Scripts.ProgressSaves
{
    public static class ProgressSaveManager
    {
        private static readonly ProgressSave[] CurrentProgresses = new ProgressSave[6];
        
        public static void SaveProgression(ProgressSave currentProgress, int index = -1)
        {
            if (index < 0)
            {
                for (int i = 0; i < CurrentProgresses.Length; i++)
                {
                    CurrentProgresses[i] ??= currentProgress;
                    return;
                }
            }

            if (CurrentProgresses[index] != null)
            {
                //TODO lancer une phase de confirmation
            }
            CurrentProgresses[index] = currentProgress;
        }
    }
}