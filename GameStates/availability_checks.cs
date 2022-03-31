using System.Collections.Generic;
using March_Game_Jam.Entities;

namespace March_Game_Jam.GameStates
{
    public class availability_checks
    {
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