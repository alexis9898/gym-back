using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class WorkoutMuscle
    {
        //all muscles including into workoug
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int MuscleId {  get; set; }
        public  Muscle Muscle { get; set;}

    }
}
