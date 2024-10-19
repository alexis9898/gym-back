using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WorkoutModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        //public DateTime End { get; set; }

        public List<MuscleModel>? Muscles { get; set; }
        public List<WorkoutExerciseModel>? WorkoutExercises { get; set; }

        //public int UserId {  get; set; }
    }
}
