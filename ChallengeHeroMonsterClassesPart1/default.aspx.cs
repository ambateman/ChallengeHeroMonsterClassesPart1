using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{

   


public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character Hero = new Character();
            Character Monster = new Character();
            Hero.Name = "Huh-Yun-Mi";
            Hero.Health = 10000;
            Hero.DamageMaximum = 50;
            Hero.AttackBonus = 50;

            Monster.Name = "Grendel";
            Monster.Health = 1000;
            Monster.DamageMaximum = 10;
            Monster.AttackBonus = 2;

            //Initialize the result labels:
            lblInitial.Text = "Starting Out Stats: <br/>";
            lblPostRound.Text = "After One Round Each Stats: <br/>";
            CharacterStats(Hero,true);
            CharacterStats(Monster, true);

            //FIGHT!
            //First the hero -- I don't have to save the attack values to make this work, but I might need them later
            int HeroAttack = Hero.Attack();
            Monster.Defend(HeroAttack);
            int MonsterAttack = Monster.Attack();
            Hero.Defend(MonsterAttack);
            CharacterStats(Hero, false);
            CharacterStats(Monster, false);







        }


        private void CharacterStats(Character CharValues, bool Initial) {

            if (Initial)
            {
                lblInitial.Text += "Character Name: " + CharValues.Name + "     Health: " + CharValues.Health.ToString() + "<br/>";
            }
            else
            {
                lblPostRound.Text += "Character Name: " + CharValues.Name + "     Health: " + CharValues.Health.ToString() + "<br/>";
            }


        }



    }


    class Character
    {
        Random AttackValue = new Random();
        Random DefendValue = new Random();

        public string Name{ get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public int AttackBonus { get; set; }



        public int Attack()
        {   //Only allow the maximum amount (up to 2000) for a given hero (anything less, too, of course)
            return Math.Min(AttackValue.Next(0, 200), DamageMaximum);
        }

        public void Defend(int damage)
        {
            //to make it more realistic, I'm going to detect a random amount from the incoming damage
            int defenseValue = DefendValue.Next(0, 10);
            this.Health -= damage - defenseValue;

        }


    }




}