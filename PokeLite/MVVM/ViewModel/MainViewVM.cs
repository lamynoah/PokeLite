using CommunityToolkit.Mvvm.Input;
using PokeLite.Model;
using System.Windows;
using System.Windows.Input;

namespace PokeLite.MVVM.ViewModel
{
    public class MainViewVM : BaseVM
    {
        //Called from view (With data binding)







        public ICommand RequestChangeViewCommand { get; set; }


        ExerciceMonsterContext _context = new ExerciceMonsterContext();
        public MainViewVM()
        {
            //Configure command to callback "HandleRequestChangeViewCommand"
            //when command is called

            RequestLogin = new RelayCommand(HandleRequestLogin);
            RequestChangeViewCommand = new RelayCommand(HandleRequestChangeViewCommand);

        }

        public void HandleRequestChangeViewCommand()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new SettingVM());
        }






        //Override from BaseVM
        public override void OnShowVM()
        {
            //Display popup for information
            //MessageBox.Show("Main view display");
        }

        private string password;

        public string Password { get => password; set { SetProperty(ref password, value); OnPropertyChanged(nameof(Password)); } }

        private string username;

        public string Username { get => username; set { SetProperty(ref username, value); OnPropertyChanged(nameof(Username)); } }

        public static Login? User { get; set; }

        public ICommand RequestLogin { get; set; }

        public void HandleRequestLogin()
        {
            Login? found = _context.Logins.FirstOrDefault(x => x.Username == username && x.PasswordHash == HashPassword.CreateHash(Password));
            if (found != null)
            {
                User = found;
                //MessageBox.Show($"found : {found.Username} , {found.Id}");
                MainWindowVM.OnRequestVMChange?.Invoke(new ChoosePokemonVM());
            }
            else
            {
                MessageBox.Show("Pas le bon mot de passe ou nom d'utilisateur ");

            }
        }

    }
}
