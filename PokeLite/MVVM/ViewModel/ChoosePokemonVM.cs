using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PokeLite.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PokeLite.MVVM.ViewModel
{
    public class ChoosePokemonVM : BaseVM
    {



        private ObservableCollection<Monster> monsters;

        public ObservableCollection<Monster> Monsters { get => monsters; set { SetProperty(ref monsters, value); OnPropertyChanged(nameof(Monsters)); } }


        private ExerciceMonsterContext _context = new ExerciceMonsterContext();


        public ICommand RequestChangeViewCommand { get; set; }


        public ChoosePokemonVM()
        {
            Monsters = new ObservableCollection<Monster>(_context.Monsters.Include(m => m.Spells));
            AddMonster = new RelayCommand(HandleAddMonster);
            RemoveMonster = new RelayCommand(HandleRemoveMonster);
            _player = _context.Players.Include(p => p.Monsters).First(p => p.Login == MainViewVM.User);
            RequestChangeViewCommand = new RelayCommand(HandleRequestChangeViewCommand);
        }

        public void HandleRequestChangeViewCommand()
        {
            if (CurrrentMonster == null) return;
            MainWindowVM.OnRequestVMChange?.Invoke(new CombatVM());
        }


        private Player _player { get; set; }

        private Monster selectedMonster;

        public Monster SelectedMonster { get => selectedMonster; set { SetProperty(ref selectedMonster, value); OnPropertyChanged(nameof(SelectedMonster)); } }

        public Monster? CurrrentMonster { get => _player.Monsters.FirstOrDefault(); }


        public ICommand AddMonster { get; set; }
        public ICommand RemoveMonster { get; set; }


        public void HandleAddMonster()
        {
            if (_player.Monsters.Count > 0) return;
            _player.Monsters.Add(selectedMonster);
            _context.SaveChanges();
            OnPropertyChanged(nameof(CurrrentMonster));

        }

        public void HandleRemoveMonster()
        {

            if (_player.Monsters.Count < 1) return;
            bool r = _player.Monsters.Remove(selectedMonster);
            _context.SaveChanges();
            OnPropertyChanged(nameof(CurrrentMonster));
        }
    }
}
