namespace PokeLite.Model
{
    public class LogicDB
    {
        static ExerciceMonsterContext _context = new ExerciceMonsterContext();

        public static Login AddUser(Login User)
        {
            _context.Logins.Add(User);
            _context.SaveChanges();
            return User;
        }


        public static void AddOther()
        {


            Login login1 = _context.Logins.First();
            Login login2 = _context.Logins.Find(5)!;


            var player1 = new Player { Name = "Sacha", Login = login1 };
            var player2 = new Player { Name = "Ondine", Login = login2 };


            var monster1 = new Monster { Name = "Pikachu", Health = 100, ImageUrl = "/image/pikachu.png" };
            var monster2 = new Monster { Name = "Dracaufeu", Health = 200, ImageUrl = "/image/dracaufeu.png" };
            var monster3 = new Monster { Name = "Bulbizarre", Health = 150, ImageUrl = "/image/bulbizare.jpg" };
            var monster4 = new Monster { Name = "Carapuce", Health = 120, ImageUrl = "/image/carapuce.jpg" };
            var monster5 = new Monster { Name = "Rondoudou", Health = 80, ImageUrl = "/image/rondoudou.png" };
            var monster6 = new Monster { Name = "Miaouss", Health = 90, ImageUrl = "/image/Miaouss.png" };
            var monster7 = new Monster { Name = "Evoli", Health = 110, ImageUrl = "/image/evoli.png" };
            var monster8 = new Monster { Name = "Ronflex", Health = 300, ImageUrl = "/image/ronflex.png" };
            var monster9 = new Monster { Name = "Ectoplasma", Health = 170, ImageUrl = "/image/Ectoplasma.png" };
            var monster10 = new Monster { Name = "Mewtwo", Health = 400, ImageUrl = "/image/mewto.png" };


            var spell1 = new Spell { Name = "Éclair", Damage = 90, Description = "Une attaque électrique puissante." };
            var spell2 = new Spell { Name = "Lance-Flammes", Damage = 95, Description = "Une attaque de feu dévastatrice." };
            var spell3 = new Spell { Name = "Fouet Lianes", Damage = 45, Description = "Une attaque de type plante avec des lianes." };
            var spell4 = new Spell { Name = "Pistolet à O", Damage = 40, Description = "Une attaque de type eau." };
            var spell5 = new Spell { Name = "Berceuse", Damage = 0, Description = "Endort l'adversaire." };
            var spell6 = new Spell { Name = "Griffe", Damage = 40, Description = "Une attaque physique basique." };
            var spell7 = new Spell { Name = "Vive-Attaque", Damage = 50, Description = "Une attaque rapide et physique." };
            var spell8 = new Spell { Name = "Ultralaser", Damage = 150, Description = "Une attaque extrêmement puissante." };
            var spell9 = new Spell { Name = "Ball’Ombre", Damage = 80, Description = "Une attaque de type spectre." };
            var spell10 = new Spell { Name = "Frappe Psy", Damage = 120, Description = "Une attaque de type psychique." };


            monster1.Spells = new List<Spell>() { spell1, spell7, spell6, spell3 };
            monster2.Spells = new List<Spell>() { spell2, spell7, spell8, spell6 };
            monster3.Spells = new List<Spell>() { spell3, spell7, spell5, spell6 };
            monster4.Spells = new List<Spell>() { spell4, spell7, spell6, spell5 };
            monster5.Spells = new List<Spell>() { spell5, spell7, spell6, spell3 };
            monster6.Spells = new List<Spell>() { spell6, spell7, spell1, spell5 };
            monster7.Spells = new List<Spell>() { spell7, spell6, spell8, spell2 };
            monster8.Spells = new List<Spell>() { spell8, spell7, spell6, spell1 };
            monster9.Spells = new List<Spell>() { spell9, spell7, spell6, spell1 };
            monster10.Spells = new List<Spell>() { spell10, spell7, spell8, spell9 };


            player1.Monsters = (new[] { monster1 });
            _context.AddRange(player1, player2);
            _context.AddRange(monster1, monster2, monster3, monster4, monster5, monster6, monster7, monster8, monster9, monster10);
            _context.AddRange(spell1, spell2, spell3, spell4, spell5, spell6, spell7, spell8, spell9, spell10);
            _context.SaveChanges();

        }



    }
}
