using PokeLite.Model;
using System.Windows;

namespace PokeLite.MVVM.ViewModel
{

    public class MonsterCombat(Monster monster)
    {
        public Monster Monster { get; set; } = monster;
        public int CurrentHp { get; set; } = monster.Health;
        public List<Spell> Spells { get; set; } = new(monster.Spells);

        public string? ImageUrl { get; set; } = monster.ImageUrl;
    }

    public static class CombatSystem
    {

        public static Action<MonsterCombat>? DeathEvent { get; set; } = HandleDeathEvent;



        public static void HandleDeathEvent(MonsterCombat m)
        {


            MessageBox.Show($"{m.Monster.Name} est mort !");

        }

        public static void Attack(this Spell a, MonsterCombat d)
        {
            d.CurrentHp -= a.Damage;
            if (d.CurrentHp < 0)
            {
                d.CurrentHp = 0;
                DeathEvent?.Invoke(d);
            }
        }

    }
}
