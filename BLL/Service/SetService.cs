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
    public class SetService : ISetService
    {
        private readonly ISetRepository _setRepository;
        private readonly IMapper _mapper;

        public SetService(ISetRepository setRepository,IMapper mapper)
        {
            this._setRepository = setRepository;
            this._mapper = mapper;
        }
        public async Task<SetModel> Add(SetModel setModel)
        {
            var set = _mapper.Map<Set>(setModel);
            set=await _setRepository.Add(set);
            setModel.Id = set.Id;
            return setModel;

        }

        public async Task<List<SetModel>> AddDeleteSet(List<SetModel> setModels, int workoutExerciseId)
        {
            var existSets = await _setRepository.GetSetsOfWorkoutExercise(workoutExerciseId);

            for (int i = 0; i < setModels.Count; i++)
            {
                //setModels[i].WorkoutExercise = null;

                if (setModels[i].Id!=0 && existSets.TryGetValue(setModels[i].Id, out var set)) //Set(update)
                {
                    existSets.Remove(setModels[i].Id); //when we find we remove from existSets (the existSets are stay sre removed)

                    var map = _mapper.Map<Set>(setModels[i]);
                    if (map == set) //nothing change(not need to update)
                        continue;

                    set.WorkoutExerciseId= workoutExerciseId;
                    set.Weight = setModels[i].Weight;
                    set.RepetitionsCount = setModels[i].RepetitionsCount;

                    continue;
                }

                //add
                setModels[i].WorkoutExerciseId= workoutExerciseId;
                setModels[i]= await Add(setModels[i]);

            }


            foreach (var set in existSets)
                await _setRepository.Delete(set.Value);

            return setModels;
        }

       
    }
}
