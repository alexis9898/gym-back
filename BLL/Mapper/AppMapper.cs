using AutoMapper;
using BLL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<WorkoutModel,Workout>().ReverseMap()
                .ForMember(x=>x.WorkoutExercises, y=>y.MapFrom(z=>z.WorkoutExercises))
                .ForMember(x=>x.Muscles, y=>y.MapFrom(z=>z.Muscles));
            CreateMap<ExerciseModel,Exercise>().ReverseMap();
            CreateMap<MuscleModel, Muscle>().ReverseMap();
            CreateMap<WorkoutExerciseModel, WorkoutExercise>().ReverseMap();
            CreateMap<WorkoutMuscleModel,WorkoutMuscle>().ReverseMap();
            CreateMap<ExerciseMuscleModel,ExerciseMuscle>().ReverseMap();
            CreateMap<Set,SetModel>().ReverseMap();
        }
    }
}
