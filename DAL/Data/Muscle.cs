using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkoutMuscle> WorkoutMuscles { get; set; }
        public List<Workout> Workouts { get; set; }  
       // public List<ExerciseMuscle> exerciseMuscles { get; set; } 
        public List<Exercise> Exercise { get; set; }


    }
}
