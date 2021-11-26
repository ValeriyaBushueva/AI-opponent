using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerSlotRewardView : MonoBehaviour
{
   [SerializeField] private Image _selectBackGround;
   [SerializeField] private Image _iconCurrency;
   [SerializeField] private TMP_Text _textDay;
   [SerializeField] private TMP_Text _countReward;

   public void SetDate(Reward reward, int countDay, bool isSelect)
   {
      _iconCurrency.sprite = reward.IconCurrency;
      _textDay.text = $"Day {countDay}";
      _countReward.text = reward.CountCurrency.ToString();
      _selectBackGround.gameObject.SetActive(isSelect);
   }

}
