using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ExerciseMuscle
    {
        public int ExerciseId {  get; set; }
        public Exercise Exercise { get; set; }
        public int MuscleId {  get; set; }
        public Muscle Muscle { get; set; }
    }
}
