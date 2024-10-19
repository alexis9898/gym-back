using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WorkoutMuscleModel
    {
        public int WorkoutId { get; set; }
        public WorkoutModel Workout { get; set; }
        public int MuscleId { get; set; }
        public MuscleModel Muscle { get; set; }
    }
}
