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
    public class ExerciseMuscleService:IExerciseMuscleService
    {
        private readonly IExerciseMuscleRepository _exerciseMuscleRepository;
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;
        private readonly IMuscleService _muscleService;

        public ExerciseMuscleService(IExerciseMuscleRepository exerciseMuscleRepository,IMapper mapper,IExerciseService exerciseService,IMuscleService muscleService)
        {
            this._exerciseMuscleRepository = exerciseMuscleRepository;
            this._mapper = mapper;
            this._exerciseService = exerciseService;
            this._muscleService = muscleService;
        }

        public async Task<List<ExerciseModel>> AddExercisesMuscle(List<ExerciseModel> exercises, int muscleId)
        {
          
            var exerciseMuscleExists=await _exerciseMuscleRepository.GetExerciseOfMuscle(muscleId);

            List<ExerciseModel> addedExercises=new List<ExerciseModel>();

            for (int i = 0; i < exercises.Count; i++)
            {
                if (exercises[i].Id != 0 && exerciseMuscleExists.ContainsKey(exercises[i].Id)) //exist in exerciseMuscle table
                    continue;

                var exercise = await Add(exercises[i].Id, muscleId);
                if (exercise == null)
                    continue;

                addedExercises.Add(exercise);
            }


            return addedExercises; //return added exercises of muscle
        }

        public async Task<ExerciseModel> Add(int exerciseId, int muscleId)
        {
            var muscle = await _muscleService.Get(muscleId);
            if (muscle == null)
                return null;

            var exercise = await _exerciseService.Get(exerciseId); //exercise not exist 
            if (exercise == null)
                return null;

            var exerciseMuscle = new ExerciseMuscle();
            exerciseMuscle.ExerciseId = exercise.Id;
            exerciseMuscle.MuscleId = muscleId;
            await _exerciseMuscleRepository.Add(exerciseMuscle);
            return exercise;

        }
        public async Task<bool> Delete(int exerciseId, int muscleId)
        {
            //var muscle = await _muscleService.Get(muscleId);
            //if (muscle == null)
            //    return false;

            //var exercise = await _exerciseService.Get(exerciseId); //exercise not exist 
            //if (exercise == null)
            //    return false;

            var em= await _exerciseMuscleRepository.Get(exerciseId,muscleId);
            if(em == null) 
                return false;

            await _exerciseMuscleRepository.Delete(em);
            return true;
        }

    }
}
