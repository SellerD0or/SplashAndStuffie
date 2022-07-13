using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestChangerPlayer : MonoBehaviour
{ 
    private ReloaderPlayerStats _reloader;
    [SerializeField] private TestEnemyText _enemyText;
    private SelecterCharacter _selecter;
    private PlayerInterface _interface;
    [SerializeField] private MoveableCamera _camera;
     private Player _player;
    private List< TestPlayerPosition> _positions = new List<TestPlayerPosition>();
    public bool IsStopped { get; set; }
    public List<Player> Players { get => _players; set => _players = value; }
        private List<TestPlayerHealthOutPut> _healthOutPuts = new List<TestPlayerHealthOutPut>();
    public List<TestPlayerHealthOutPut> HealthOutPuts { get => _healthOutPuts; set => _healthOutPuts = value; }
    public List<TestPlayerPosition> PlayerPositions { get => _playerPositions; set => _playerPositions = value; }

    private List<TestPlayerPosition> _playerPositions = new List<TestPlayerPosition>();
    private Enemy[] _enemies;
    private List<Player> _players = new List<Player>();
    private bool _ableToPressTab;
    private TestSkillCreater _skillCreater;
    private TestAbilityCreater _abilityCreater;
    [SerializeField] private CanvasGroup _canvasGroupOfInterface;
    private void Start() {
        _skillCreater = FindObjectOfType<TestSkillCreater>();
         _abilityCreater = FindObjectOfType<TestAbilityCreater>();
        _reloader = FindObjectOfType<ReloaderPlayerStats>();
        _selecter = FindObjectOfType<SelecterCharacter>();
        _interface = FindObjectOfType<PlayerInterface>();
        _selecter.CurrentCharacters = Players;
        Invoke(nameof(FindEnemies),0.1f);
        TestPlayerPosition[] positions = FindObjectsOfType<TestPlayerPosition>();
        _positions = positions.ToList();
    }
    private void FindEnemies()
    {
         _enemies = FindObjectsOfType<Enemy>();
         foreach (var item in _enemies)
         {
             item.IEnemyMovement.MinXForMovement = 55;
             item.gameObject.AddComponent<TestEnemyHealth>();
             TestEnemyHealth health = item.GetComponent<TestEnemyHealth>();
             health.EnemyText = _enemyText;
         }
         _ableToPressTab = true;
    }
   private void Update() {
       if (Input.GetKeyDown(KeyCode.Tab) && _player != null && _ableToPressTab)
       {
         Create();
       }
   }
   public void Create()
   {
         foreach (var enemy in _enemies)
           {
               enemy.Player = null;
           }
           TestPlayerPosition position = _positions.Find(e=>e.Player.Name == _player.Name);
           _player.transform.position = position.transform.position;
           Debug.Log(_player.Name + " HE NEEDS TO STIOo");
           position.StopPlayer(_player);
            _player.IPlayerAnimator.EnemyAnimator.animation.FadeIn("idle");
         BoardOfReloadingAbility board = _abilityCreater.CurrentBoards.Find(e=> e.Player.Name == _player.Name);
         _abilityCreater.SetActiveBoard(board,0,false);
                  PlayerInterfaceSkill skill = _skillCreater.CurrentSkills.Find(e=> e.Player.Name == _player.Name);
         _skillCreater.SetActiveBoard(skill,0,false);
         ChangCanvas(0,false);
           _player = null;

           IsStopped = false;
           _camera.CurrentPlayer = null;
           _camera.transform.position = new Vector3(9.2f, 3.37f, -10f);
   }
   private void ChangCanvas(float alpha, bool blocksRaycasts)
   {
                _canvasGroupOfInterface.alpha = alpha;
         _canvasGroupOfInterface.blocksRaycasts = blocksRaycasts;

   }
   public void ChangeCurrentPlayer(Player player)
   {
       foreach (var item in HealthOutPuts)
       {
           item.CanvasGroup.alpha = 0;
           item.CanvasGroup.blocksRaycasts = false;
       }
      TestPlayerHealthOutPut healthOutPut  = HealthOutPuts.Find(e=> e.Player.Name == player.Name);
      healthOutPut.CanvasGroup.alpha = 1; 
      healthOutPut.CanvasGroup.blocksRaycasts = true;


       Debug.Log(player.Name + " CURRENT PLAYER!!!!");
       foreach (var enemy in _enemies)
       {
           enemy.Player = player;
       }
       _player = player;
       _interface.GetterPlayer.CreatedPlayer = player;
       Player player1 = _selecter.CurrentCharacters.Find(e=> e.Name == player.Name);
     _selecter.CurrentPlayer = player1; 
     _reloader.CurrentPlayer = player1;
     ChangCanvas(1,true);
       _interface.Show();
       _camera.CurrentPlayer = _player;

   }
}
