using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WorkoutExerciseModel
    {
        //all exercises that train workout
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        //public WorkoutModel? Workout { get; set; }
        public int ExerciseId { get; set; }
        public ExerciseModel? Exercise { get; set; }
        //public string? Exercise { get; set; }

        public List<SetModel> Sets { get; set; }
    }
}
