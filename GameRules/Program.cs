using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroRuleEngine;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.IO;

namespace GameRules
{
    class Program
    {
        static void Main(string[] args)
        {
            MRE engine = new MRE();

            Rule health = new Rule//If health is less than 15 (very low)
            {
                MemberName = "Health",
                Operator = ExpressionType.LessThanOrEqual.ToString("g"),
                TargetValue = 15
            };
            Func<Player, bool> healthCompiled = engine.CompileRule<Player>(health);

            Rule speedUp = Rule.Create("PickUpCount", mreOperator.GreaterThanOrEqual, 4) &
                Rule.Create("Speed", mreOperator.LessThan, 10);//Pick ups give more speed if speed isnt to high already and you have som pick ups
            Func<Player, bool> speedUpCompiled = engine.CompileRule<Player>(speedUp);

            Rule pickUpsHeal = Rule.Create("PickUpCount", mreOperator.GreaterThan, 6) &
                Rule.Create("Lives", mreOperator.LessThanOrEqual, 2) &
                Rule.Create("Health", mreOperator.LessThan, 30);//Health if lives and health are low
            Func<Player, bool> pickUpsHealCompiled = engine.CompileRule<Player>(pickUpsHeal);

            List<Rule> rulesList = new List<Rule>()
            {
                health,
                speedUp,
                pickUpsHeal
            };

            Player player = new Player();

            Console.WriteLine(healthCompiled(player));
            Console.WriteLine(speedUpCompiled(player));
            Console.WriteLine(pickUpsHealCompiled(player));            

            player.SetHealth(20);
            player.SetPickUpCount(7);
            player.SetSpeed(9);
            player.SetLives(2);

            Console.WriteLine(healthCompiled(player));
            Console.WriteLine(speedUpCompiled(player));
            Console.WriteLine(pickUpsHealCompiled(player));

            string rulesJson = JsonConvert.SerializeObject(rulesList, Formatting.Indented);//Indented for nicer format and easier reading
            File.WriteAllText(@"..\..\..\Assets\Scripts\PlayerRules.json", rulesJson);

            Console.ReadLine();
        }
    }
}
