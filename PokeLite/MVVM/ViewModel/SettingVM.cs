using CommunityToolkit.Mvvm.Input;
using PokeLite.Model;
using System.Windows.Input;

namespace PokeLite.MVVM.ViewModel
{
    public class SettingVM : BaseVM
    {

        private string dBServ = ExerciceMonsterContext.NomServ;

        public ICommand RequestChangeViewCommand { get; set; }
        public SettingVM()
        {
            //Configure command to callback "HandleRequestChangeViewCommand"
            //when command is called
            RequestChangeViewCommand = new RelayCommand(HandleApply);
        }




        public string DBServ { get => dBServ; set { SetProperty(ref dBServ, value); OnPropertyChanged(nameof(DBServ)); } }

        public void HandleApply()
        {
            if (DBServ != null)
            {
                using ExerciceMonsterContext _context = new ExerciceMonsterContext();
                ExerciceMonsterContext.NomServ = DBServ;
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
                LogicDB.AddUser(new() { Username = "Noah", PasswordHash = HashPassword.CreateHash("Noah") });
                LogicDB.AddOther();
                MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM());
            }
        }
    }
}
