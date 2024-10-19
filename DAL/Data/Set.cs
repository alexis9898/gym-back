using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Set
    {
        public int Id { get; set; }
        public int WorkoutExerciseId {  get; set; }
        public WorkoutExercise WorkoutExercise { get; set; }
        public int RepetitionsCount { get; set; }
        public double Weight { get; set; }
    }
}
