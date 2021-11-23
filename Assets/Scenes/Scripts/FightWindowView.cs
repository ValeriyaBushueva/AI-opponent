using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class FightWindowView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countHealthText;
    
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countPowerEnemyText;
    
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _minusCoinsButton;
    
    [SerializeField] private Button _addHealthButton;
    [SerializeField] private Button _minusHealthButton;
    
    [FormerlySerializedAs("_addPowerhutton")] [SerializeField] private Button _addPowerButton;
    [SerializeField] private Button _minusPowerButton;
    
    [SerializeField] private Button _fightButton;

    private Money _money;
    private Health _health;
    private Power _power;
    
    private Enemy _enemy;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private void Start()
    {
        _enemy = new Enemy("Enemy");
        
        _money = new Money();
        _money.Attach(_enemy);
        
        _health = new Health();
        _health.Attach(_enemy);

        _power = new Power();
      _power.Attach(_enemy);
      
      _addCoinsButton.onClick.AddListener((() => ChangeMoney(true)));
      _minusCoinsButton.onClick.AddListener((() => ChangeMoney(false)));
      
      _addHealthButton.onClick.AddListener((() => ChangeHealth(true)));
      _minusHealthButton.onClick.AddListener((() => ChangeHealth(false)));
      
      _addPowerButton.onClick.AddListener((() => ChangePower(true)));
      _minusPowerButton.onClick.AddListener((() => ChangePower(false)));
      
      _fightButton.onClick.AddListener(Fight);
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();
      
        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();
      
        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();
      
        _fightButton.onClick.RemoveAllListeners();
        
        _money.Detach(_enemy);
       _health.Detach(_enemy);
        _power.Detach(_enemy);
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer > _enemy.Power ? "Win" : "Lose");
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountMoneyPlayer++;
        }
        else
        {
            _allCountMoneyPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountHealthPlayer++;
        }
        else
        {
            _allCountHealthPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Health);
    }
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountPowerPlayer++;
        }
        else
        {
            _allCountPowerPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Power);
    }
    
    

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;
            case DataType.Health:
                _countHealthText.text = $"PlayerHealth: {countChangeData}";
                _health.CountHealth = countChangeData;
                break;
            case DataType.Power:
                _countPowerText.text = $"Player Power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;
        }
        
        _countPowerEnemyText.text = $"Player Enemy: {_enemy.Power}";
    }
}
