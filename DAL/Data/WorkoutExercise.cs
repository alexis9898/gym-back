using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{

    public class WorkoutExercise
    {
        //all exercises that train workout
        public int Id {  get; set; }
        public int WorkoutId {  get; set; }
        public Workout Workout { get; set; }
        public int ExerciseId {  get; set; }
        public Exercise Exercise {  get; set; } 
        //public string? Exercise { get; set; }

        public List<Set> Sets { get; set; }

    }
}
