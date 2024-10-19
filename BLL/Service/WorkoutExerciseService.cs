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
    public class WorkoutExerciseService: IWorkoutExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IWorkoutExerciseRepository _workoutExerciseRepository;
        private readonly ISetService _setService;

        public WorkoutExerciseService(IMapper mapper, IWorkoutExerciseRepository workoutExerciseRepository,ISetService setService, IExerciseService exerciseService, IMuscleService muscleService)
        {
            this._mapper = mapper;
            this._workoutExerciseRepository = workoutExerciseRepository;
            this._setService = setService;
        }

        public async Task<WorkoutExerciseModel> Add(WorkoutExerciseModel workoutExerciseModel)
        {
            //var sets = workoutExerciseModel.Sets;
            //workoutExerciseModel.Sets = null;

            
            var we = _mapper.Map<WorkoutExercise>(workoutExerciseModel); //add new
            we.Exercise = null;
            we = await _workoutExerciseRepository.Add(we);
            workoutExerciseModel = _mapper.Map<WorkoutExerciseModel>(we);
            return workoutExerciseModel;
        }

        public async Task<List<WorkoutExerciseModel>> AddDeleteWorkoutExercises(List<WorkoutExerciseModel> workoutExerciseModels, int workoutId)
        {
            var existWorkoutExercise=await _workoutExerciseRepository.GetExerciseOfWorkout(workoutId);

            for (int i = 0; i < workoutExerciseModels.Count; i++)
            {
                var sets = workoutExerciseModels[i].Sets;
                workoutExerciseModels[i].Sets = null;


                if (workoutExerciseModels[i].WorkoutId!=0 && existWorkoutExercise.TryGetValue(workoutExerciseModels[i].Id,out var workoutExercise)) //set
                {
                    existWorkoutExercise.Remove(workoutExercise.Id);

                    //var map=_mapper.Map<WorkoutExercise>(workoutExerciseModels[i]); 
                    //if (map == workoutExercise) //nothing change
                    //    continue;

                    workoutExercise.ExerciseId=workoutExerciseModels[i].ExerciseId;
                    workoutExercise.WorkoutId = workoutExercise.WorkoutId;

                    await _workoutExerciseRepository.Set(workoutExercise);
                    sets=await _setService.AddDeleteSet(sets, workoutExercise.Id);
                    //HandleSets()

                    continue;
                }
                workoutExerciseModels[i].WorkoutId = workoutId;

                var addWorkoutExercise = await Add(workoutExerciseModels[i]);
                sets = await _setService.AddDeleteSet(sets, addWorkoutExercise.Id);
                
                //HandleSets()                
                
            }

            foreach (var workoutExercise in existWorkoutExercise)
                await _workoutExerciseRepository.Delete(workoutExercise.Value);


            return workoutExerciseModels;

        }

       


        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
