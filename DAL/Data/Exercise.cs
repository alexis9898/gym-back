using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Exercise
    {
        public int Id {  get; set; }    
        public string Name { get; set; }

        public List<Muscle> Muscles { get; set;}
       // public List<ExerciseMuscle> exerciseMuscles{ get; set; }


    }
}
