using AutoMapper;
using BLL.Interface;
using BLL.Models;
using DAL.Data;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WorkoutMuscleService:IWorkoutMuscleService
    {
        private readonly IMapper _mapper;
        private readonly IWorkoutMuscleRepository _workoutMuscleRepository;
        private readonly IMuscleService _muscleService;
        private readonly IWorkoutMuscleService _workoutMuscleService;

        public WorkoutMuscleService(IMapper mapper,IWorkoutMuscleRepository workoutMuscleRepository, IMuscleService muscleService)
        {
            this._mapper = mapper;
            this._workoutMuscleRepository = workoutMuscleRepository;
            this._muscleService = muscleService;
        }

      

        public async Task<List<MuscleModel>> AddDeleteMuscleWorkout(List<MuscleModel> muscles, int workoutId)
        {
            var existsMusclesWorkout = await _workoutMuscleRepository.GetMusclesOfWorkout(workoutId);

            for (int i = 0; i < muscles.Count; i++)
            {
                if (muscles[i].Id != 0 && existsMusclesWorkout.ContainsKey(muscles[i].Id)) //already exist in WorkoutMuscle table
                {
                    existsMusclesWorkout.Remove(muscles[i].Id); //for delete , we dont want delete it
                    continue;
                }
                
                var addMuscle = await Add(workoutId, muscles[i].Id);
                if (addMuscle == null)
                    continue;

                muscles[i] = addMuscle;
               
            }

            foreach (var muscle in existsMusclesWorkout) //delete (what that Stayed here need deleted)
            {
                var workoutMuscle = await _workoutMuscleRepository.Get(workoutId, muscle.Key);
                await _workoutMuscleRepository.Delete(workoutMuscle);
            }

            return muscles;
        }

        public async Task<MuscleModel> Add(int workoutId, int muscleId)
        {
            //var workout = await _workoutMuscleService.AddDeleteExercisesMuscle(workoutId);
            //if (workout == null)
            //    return null;

            var muscle=await _muscleService.Get(muscleId);
            if (muscle == null)
                return null;

            var workoutMuscle = new WorkoutMuscle();
            workoutMuscle.WorkoutId= workoutId;
            workoutMuscle.MuscleId= muscleId;
            workoutMuscle = await _workoutMuscleRepository.Add(workoutMuscle);

            return muscle;

        }
        public async Task<bool> Delete(int workoutId, int muscleId)
        {
          
            var workoutMuscle=await _workoutMuscleRepository.Get(workoutId, muscleId);
            if (workoutMuscle == null) return false;
            await _workoutMuscleRepository.Delete(workoutMuscle);
            return true;
        }

    }
}
