using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using March_Game_Jam.Entities;
using System;
using System.Collections.Generic;
using March_Game_Jam.Helpers;

namespace March_Game_Jam.GameStates
{
    public class FightScene : GameState
    {
        public static Child child;
        public static Dad dad;
        public static ActionButton[] actionList = new ActionButton[4];
        public static Texture2D background,
        bottomMenu;
        public static Rectangle backgroundRect,
        bottomMenuRect;
        public static List<March_Game_Jam.Helpers.Action> current_action_list;
        public static List<March_Game_Jam.Helpers.Problem> possible_problem_list;
        public static March_Game_Jam.Helpers.Problem current_problem;
        
        public static Random rnd = new Random();
        //used to randomly select problem from possible problem pool
        public static int round;
        //current round during a given life stage.
        public int child_life_stage;
        //child's life stage (baby, child, teen, college). An int from 0 to 3. May not be necessary here, may only be necessary in child, but I added it here to sync up with the round tracker.
        public FightScene() : base()
        {
            //Instantiate and draw Dad and Child Objects.
            dad = new Dad(100, 250);
            child = new Child(700, 250);
            void Test() {
                Console.WriteLine("test");
            };
            actionList[0] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 1", Test);
            actionList[1] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 2", Test);
            actionList[2] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 3", Test);
            actionList[3] = new Entities.ActionButton(100, 300, 100, 30, "Action Number 4", Test);
        }

        public void updateAvailableActions()
        {
            foreach (Dictionary<dynamic,dynamic> an_action_name in Game1.actions_dict["actions"]) {
                //First clear the current available action list.
                current_action_list.Clear();
                //Parameters needs to be named in the action_list.json
                //The parameters should cover thresholds for certain stats in father
                //or child, the age of the child (or the round), and flag checks.
                bool is_available = should_this_action_be_available(an_action_name);
                if (is_available)
                {
                    //add name of action to availableActionsList
                    Helpers.Action an_action = new Helpers.Action(an_action_name["action_name"]);
                    current_action_list.Add(an_action);
                }
            }
        }

        public bool should_this_action_be_available(Dictionary<dynamic,dynamic> an_action)
        {
            bool dad_stat_check_bool = dad_stat_check(an_action,dad);
            bool child_stat_check_bool = child_stat_check(an_action,child);
            bool round_check_bool = round_check(an_action);
            bool age_check_bool = age_check(an_action,child);
            bool dad_flag_pass_check_bool = dad_flag_pass_check(an_action,dad);
            bool dad_flag_block_check_bool = dad_flag_block_check(an_action,dad);
            bool child_flag_pass_check_bool = child_flag_pass_check(an_action,child);
            bool child_flag_block_check_bool = child_flag_block_check(an_action,child);
            return (dad_stat_check_bool && child_stat_check_bool && round_check_bool && age_check_bool && dad_flag_pass_check_bool && dad_flag_block_check_bool && child_flag_pass_check_bool && child_flag_block_check_bool);
        }

        public void updateCurrentProblem()
        {
            foreach(Dictionary<dynamic,dynamic> a_problem_name in Game1.problems_dict["problems"])
            {
                possible_problem_list.Clear();
                bool is_available = should_this_problem_be_available(a_problem_name);
                if (is_available)
                {
                    //add to possible problem pool
                    Problem new_problem = new Problem(a_problem_name["problem_name"]);
                    possible_problem_list.Add(new_problem);
                }
            }
            int rnd_int = rnd.Next(possible_problem_list.Count);
            current_problem = possible_problem_list[rnd_int];
        }

        public bool should_this_problem_be_available(Dictionary<dynamic,dynamic> a_problem_name)
        {
            //Logic for checking whether a problem can possibly occur now.
            bool dad_stat_check_bool = dad_stat_check(a_problem_name,dad);
            bool child_stat_check_bool = child_stat_check(a_problem_name,child);
            bool round_check_bool = round_check(a_problem_name);
            bool age_check_bool = age_check(a_problem_name,child);
            bool dad_flag_pass_check_bool = dad_flag_pass_check(a_problem_name,dad);
            bool dad_flag_block_check_bool = dad_flag_block_check(a_problem_name,dad);
            bool child_flag_block_check_bool = child_flag_block_check(a_problem_name,child);
            bool child_flag_pass_check_bool = child_flag_pass_check(a_problem_name,child);
            return (dad_stat_check_bool && child_stat_check_bool && round_check_bool && age_check_bool && dad_flag_pass_check_bool && dad_flag_block_check_bool && child_flag_pass_check_bool && child_flag_block_check_bool);
        }


        public override void Update()
        {
            
        }

        public override async void Draw(SpriteBatch sb)
        {
            backgroundRect = new Rectangle(0, 0, Game1.screen_width, background.Bounds.Height * Game1.screen_width / background.Bounds.Width);
            sb.Draw(background, backgroundRect, background.Bounds, Color.White);
            bottomMenuRect = new Rectangle(0, Game1.screen_height - (bottomMenu.Bounds.Height * Game1.screen_width / bottomMenu.Bounds.Width), Game1.screen_width, bottomMenu.Bounds.Height * Game1.screen_width / bottomMenu.Bounds.Width);
            sb.Draw(bottomMenu, bottomMenuRect, bottomMenu.Bounds, Color.White);
            double xScaling = (double)bottomMenuRect.Width / bottomMenu.Bounds.Width;
            double yScaling = (double)bottomMenuRect.Height / bottomMenu.Bounds.Height;
            Console.WriteLine(xScaling);
            actionList[0].hitBox.X = (int)(105 * xScaling);
            actionList[0].hitBox.Y = Game1.screen_height - (int)(306 * yScaling);
            actionList[0].hitBox.Width = (int)(402 * xScaling);
            actionList[0].hitBox.Height = (int)(128 * yScaling);
            actionList[1].hitBox.X = actionList[0].hitBox.X;
            actionList[1].hitBox.Y = Game1.screen_height - (int)(152 * yScaling);
            actionList[2].hitBox.X = (int)(535 * xScaling);
            actionList[2].hitBox.Y = actionList[0].hitBox.Y;
            actionList[3].hitBox.X = actionList[2].hitBox.X;
            actionList[3].hitBox.Y = actionList[1].hitBox.Y;
            for(int i = 1; i < 4; i++) {
                actionList[i].hitBox.Width = actionList[0].hitBox.Width;
                actionList[i].hitBox.Height = actionList[0].hitBox.Height;
            }
        }
        public static bool dad_stat_check(Dictionary<dynamic,dynamic> a_dict, Dad dad){
            //this needs to work whether the filter exists or not.            
            bool current_returnable = true;
            if (a_dict.ContainsKey("father_stat_threshold")){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"]["father_stat_threshold"];
                foreach(string stat in check_dict.Keys){
                    if ((check_dict[stat]["lower"] <=dad.GetType().GetField(stat).GetValue(dad) as dynamic) &&((check_dict[stat]["upper"] >=dad.GetType().GetField(stat).GetValue(dad) as dynamic))){
                        current_returnable = true;
                    }
                    else{
                        current_returnable = false;
                        return current_returnable;
                    }
                }
            }
            return current_returnable;
        }
        public static bool child_stat_check(Dictionary<dynamic,dynamic> a_dict,Child child){
            bool current_returnable = true;
            if (a_dict.ContainsKey("child_stat_threshold")){
                Dictionary<dynamic,dynamic>  check_dict = a_dict["availability"]["child_stat_threshold"];
                foreach(string stat in check_dict.Keys){
                    if ((check_dict[stat]["lower"] <=child.GetType().GetField(stat).GetValue(child) as dynamic) &&((check_dict[stat]["upper"] >=child.GetType().GetField(stat).GetValue(child) as dynamic))){
                        current_returnable = true;
                    }
                    else{
                        current_returnable = false;
                        return current_returnable;
                    }
                }
            }
            return current_returnable;
        }
        public static bool round_check(Dictionary<dynamic,dynamic> a_dict){
            if (a_dict.ContainsKey("round_threshold")){
                Dictionary<dynamic,dynamic>  check_dict = a_dict["availability"]["round_threshold"];
                if ((check_dict["round_threshold"]["lower"] <=FightScene.round) &&((check_dict["round_threshold"]["upper"] >=FightScene.round))){
                    return true;
                }
                else{
                    return false;
                }
            }
            return true;
        }
        public static bool age_check(Dictionary<dynamic,dynamic> a_dict,Child child){
            bool current_returnable = true;
            if (a_dict.ContainsKey("age_threshold")){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"]["age_threshold"];
                if ((check_dict["age_threshold"]["lower"] <=child.age) &&((check_dict["age_threshold"]["upper"] >=child.age))){
                    return true;
                }
                else{
                    return false;
                }
            }
            return current_returnable;
        }

        public static bool dad_flag_pass_check(Dictionary<dynamic,dynamic> a_dict,Dad dad){
            string field = "dad_flag_pass_check";
            if (a_dict.ContainsKey(field)){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"][field];
                if (check_dict[field].Intersect(dad.flags).Any()){
                    return true;
                }
                else{
                    return false;
                }
            }
            return true;
        }
        public static bool dad_flag_block_check(Dictionary<dynamic,dynamic> a_dict,Dad dad){
            string field = "dad_flag_block_check";
            if (a_dict.ContainsKey(field)){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"][field];
                if (check_dict[field].Intersect(dad.flags).Any()){
                    return false;
                }
                else{
                    return true;
                }
            }
            return true;
        }
        public static bool child_flag_pass_check(Dictionary<dynamic,dynamic> a_dict,Child child){
            string field = "child_flag_pass_check";
            if (a_dict.ContainsKey(field)){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"][field];
                if (check_dict[field].Intersect(child.flags).Any()){
                    return true;
                }
                else{
                    return false;
                }
            }
            return true;
        }
        public static bool child_flag_block_check(Dictionary<dynamic,dynamic> a_dict,Child child){
            string field = "child_flag_block_check";
            if (a_dict.ContainsKey(field)){
                Dictionary<dynamic,dynamic> check_dict = a_dict["availability"][field];
                if (check_dict[field].Intersect(child.flags).Any()){
                    return true;
                }
                else{
                    return false;
                }
            }
            return true;
        }
    }
}
