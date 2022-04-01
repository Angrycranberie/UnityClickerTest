using TMPro;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreDisplay;
        [SerializeField] private TMP_Text _clickLevel;
        [SerializeField] private TMP_Text _upgradeError;
        [SerializeField] private TMP_Text _clickStatus;
        private int _tentLevel = 0;
        private int _score;
        private int _gain;
        private int _cost = 20;

        private void OnEnable()
        {
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _tentLevel.ToString());
            _gain = (int)Mathf.Round(Mathf.Pow(2, _tentLevel));
            _clickStatus.SetText(_gain.ToString()+" per click");
        }

        public void IncreaseScore()
        {
            _score+= _gain;
            _scoreDisplay.SetText(_score.ToString());
        }

        public void LevelUp()
        {
            if (_score < 20)
            {
                _upgradeError.SetText("Missing ressources");
                return;
            }

            
            _score -= _cost;
            
            _tentLevel++;
            
            _gain = (int)Mathf.Round(Mathf.Pow(2, _tentLevel));

            UpdateUI();
        }

        private void UpdateUI()
        {
            _upgradeError.SetText("");
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _tentLevel.ToString());
            _clickStatus.SetText(_gain.ToString() + " per click");
        }



    }
}