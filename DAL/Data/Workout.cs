using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Start {  get; set; }
        //public DateTime End { get; set; }
        public List<Muscle> Muscles {  get; set; }
        //public List<WorkoutMuscle> WorkoutMuscles{ get; set; }

        public List<WorkoutExercise>  WorkoutExercises {  get; set; }
        
        //public int UserId {  get; set; }
    }
}
