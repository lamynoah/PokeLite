using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PokeLite.Model;
using System.Windows;
using System.Windows.Input;

namespace PokeLite.MVVM.ViewModel
{
    public class CombatVM : BaseVM
    {

        private MonsterCombat myMonster;

        public ICommand attack { get; set; }

        public MonsterCombat MyMonster { get => myMonster; set => SetProperty(ref myMonster, value); }

        private MonsterCombat ennemyMonster;

        public MonsterCombat EnnemyMonster { get => ennemyMonster; set => SetProperty(ref ennemyMonster, value); }


        public ICommand RequestChangeViewCommand { get; set; }

        public void HandleRequestChangeViewCommand()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new ChoosePokemonVM());
        }



        private int score;
        public int Score { get => score; set { SetProperty(ref score, value); OnPropertyChanged(nameof(Score)); } }

        private ExerciceMonsterContext _context = new ExerciceMonsterContext();

        public CombatVM()
        {

            var _player = _context.Players.Include(p => p.Monsters).ThenInclude(m => m.Spells).First(p => p.Login == MainViewVM.User);
            myMonster = new(_player.Monsters.First());
            var allMonsters = _context.Monsters.Include(m => m.Spells).ToList();
            if (allMonsters.Any())
            {
                Random random = new Random();
                int randomIndex = random.Next(allMonsters.Count);
                EnnemyMonster = new MonsterCombat(allMonsters[randomIndex]);

            }
            attack = new RelayCommand<Spell>(HandleAttack);
        }

        public void HandleAttack(Spell s)
        {
            if (s == null)
            {
                return;
            }
            MessageBox.Show($"{EnnemyMonster.CurrentHp} : {s.Damage}");
            s.Attack(EnnemyMonster);
            EnnemiHp = (double)ennemyMonster.CurrentHp / (double)ennemyMonster.Monster.Health * 100.0;
            //MessageBox.Show($"{EnnemyMonster.CurrentHp} ");

            if (EnnemyMonster.CurrentHp > 0)
            {
                Random r = new Random();
                Spell randomSpell = EnnemyMonster.Spells[r.Next(0, EnnemyMonster.Monster.Spells.Count)];

                MessageBox.Show($"{EnnemyMonster.Monster.Name}  attaque avec {randomSpell.Name}  {randomSpell.Damage}");
                randomSpell.Attack(MyMonster);
                MyHp = (double)MyMonster.CurrentHp / (double)MyMonster.Monster.Health * 100.0;

            }

            if (EnnemyMonster.CurrentHp == 0)
            {

                Score++;
                MessageBox.Show($"Score : {Score}");
                var allMonsters = _context.Monsters.Include(m => m.Spells).ToList();
                if (allMonsters.Any())
                {
                    Random random = new Random();
                    int randomIndex = random.Next(allMonsters.Count);
                    EnnemyMonster = new MonsterCombat(allMonsters[randomIndex]);


                    EnnemyMonster.CurrentHp = EnnemyMonster.Monster.Health;

                    MessageBox.Show($"Un nouvel ennemi est apparu ! {EnnemyMonster.Monster.Name}");
                }
            }

            if (MyMonster.CurrentHp == 0)
            {

                MessageBox.Show($"Score : {Score}");
                Score = 0;

                HandleRequestChangeViewCommand();

            }

        }

        private double ennemiHp = 100;
        private double myHp = 100;

        public double EnnemiHp { get => ennemiHp; set { SetProperty(ref ennemiHp, value); OnPropertyChanged(nameof(EnnemiHp)); } }
        public double MyHp { get => myHp; set { SetProperty(ref myHp, value); OnPropertyChanged(nameof(MyHp)); } }


    }
}
