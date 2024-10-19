using AutoMapper;
using BLL.Interface;
using BLL.Models;
using DAL.Data;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WorkoutService:IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        private readonly IWorkoutExerciseService _workoutExerciseService;
        private readonly IWorkoutMuscleService _workoutMuscleService;

        public WorkoutService(IWorkoutRepository workoutRepository,IMapper mapper, IWorkoutExerciseService workoutExerciseService,IWorkoutMuscleService workoutMuscleService)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            this._workoutExerciseService = workoutExerciseService;
            this._workoutMuscleService = workoutMuscleService;
        }

        public async Task<WorkoutModel> Get(int workoutId)
        {
            var w=await _workoutRepository.GetWithInfo(workoutId);
            var workoutModel=_mapper.Map<WorkoutModel>(w);
            return workoutModel;
        }
        public async Task<WorkoutModel> Add(WorkoutModel workoutModel)
        {
            var muscles = workoutModel.Muscles;
            var workoutExercises = workoutModel.WorkoutExercises;
            workoutModel.Muscles = null;
            workoutModel.WorkoutExercises = null;
            if (workoutModel.Id != 0) return null;
            //workoutModel.Id = 0;
            var workout = _mapper.Map<Workout>(workoutModel);
            workout = await _workoutRepository.Add(workout);
            workoutModel=_mapper.Map<WorkoutModel>(workout);

            workoutModel.Muscles = await _workoutMuscleService.AddDeleteMuscleWorkout(muscles,workoutModel.Id);
            workoutModel.WorkoutExercises = await _workoutExerciseService.AddDeleteWorkoutExercises(workoutExercises,workout.Id);

            return workoutModel;
            
        }

        public async Task<WorkoutModel> Set(WorkoutModel workoutModel)
        {
            var muscles = workoutModel.Muscles;
            var workoutExercises = workoutModel.WorkoutExercises;
            workoutModel.Muscles = null;
            workoutModel.WorkoutExercises = null;
            var p=await _workoutRepository.Get(workoutModel.Id);
            if (p == null) return null;
            var workout = _mapper.Map<Workout>(p);
            await _workoutRepository.Set(workout);
            workoutModel = _mapper.Map<WorkoutModel>(workout);
            workoutModel.WorkoutExercises = await _workoutExerciseService.AddDeleteWorkoutExercises(workoutExercises, workout.Id);
            return workoutModel;
        }

        public async Task<bool> Delete(int workoutID)
        {
            var workout = await _workoutRepository.Get(workoutID);
            if (workout == null) return false;
            await _workoutRepository.Delete(workout);
            return true;
        }

        // add/set/delete WorkoutExercise
        //public async Task<List<WorkoutExerciseModel>> HandleExercises(List<WorkoutExerciseModel> workoutExercises, int workoutId)
        //{
        //    var exercises = await _workoutExerciseRepository.GetExerciseOfWorkout(workoutId);

        //    for (int i = 0; i < workoutExercises.Count; i++)
        //    {
        //        var exercise = workoutExercises[i].Exercise;
        //        workoutExercises[i].Exercise = null; //?
        //        //if(WorkoutExercises)
        //        if (workoutExercises[i].ExerciseId!=0 && exercises.TryGetValue(workoutExercises[i].ExerciseId, out var workoutExercise)) //Set
        //        {
        //            //workoutExercise=_mapper.Map<WorkoutExercise>(workoutExercises[i]);

                    
        //            workoutExercise.ExerciseId = workoutExercises[i].ExerciseId;
        //            workoutExercise.Weight = workoutExercises[i].Weight;
        //            workoutExercise.SetsCount = workoutExercises[i].SetsCount;
        //            workoutExercise.Workout = null;

        //            var current = workoutExercise;
        //            var prev = _mapper.Map<WorkoutExercise>(workoutExercises[i]);

        //            await _workoutExerciseRepository.Set(prev);
        //            exercises.Remove(workoutExercises[i].ExerciseId);
        //        }
        //        else //Add
        //        {
        //            workoutExercise = _mapper.Map<WorkoutExercise>(workoutExercises[i]);
        //            workoutExercise.WorkoutId = workoutId;
        //            workoutExercise=await _workoutExerciseRepository.Add(workoutExercise);
        //            workoutExercises[i].ExerciseId = workoutExercise.ExerciseId;
        //        }
        //    }

        //    foreach (var workoutExercise in exercises) //Delete
        //    {
        //        await _workoutExerciseRepository.Delete(workoutExercise.Value);
        //    }

        //    //await _workoutExerciseRepository.SaveChangesAsync();
        //    return workoutExercises;
        //}
    }
}
