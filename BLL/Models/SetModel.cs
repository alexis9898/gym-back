using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SetModel
    {
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; }
        //public WorkoutExerciseModel? WorkoutExercise { get; set; }
        public int RepetitionsCount { get; set; }
        public double Weight { get; set; }
    }
}
