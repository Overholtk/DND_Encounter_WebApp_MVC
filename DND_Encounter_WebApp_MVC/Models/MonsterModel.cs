using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DND_Encounter_WebApp_MVC.Controllers
{
    //Model with all availible data from API
    public class MonsterModel
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Alignment { get; set; }
        public int Armor_class { get; set; }
        public int Hit_points { get; set; }
        public string Hit_dice { get; set; }
        public object Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<object> Proficiencies { get; set; }
        public List<object> Damage_Vulnerabilities { get; set; }
        public List<object> Damage_resistances { get; set; }
        public List<object> Damage_immunities { get; set; }
        public List<object> Condition_immunities { get; set; }
        public object Senses { get; set; }
        public string Languages { get; set; }
        public int Challenge_rating { get; set; }
        public List<object> Special_abilities { get; set; }
        public List<object> Actions { get; set; }
        public List<object> Legendary_actions { get; set; }
        public string URL { get; set; }
    }
}
