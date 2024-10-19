using AutoMapper;
using BLL.Interface;
using BLL.Models;
using DAL.Data;
using DAL.Interface;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ExerciseService: IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseModel>> GetAll()
        {
            var exercises = await _exerciseRepository.GetAll();
            return _mapper.Map<List<ExerciseModel>>(exercises);
        }

        public async Task<ExerciseModel> Get(int id)
        {
            var exerxise=await _exerciseRepository.Get(id);
            if (exerxise == null) return null;
            return _mapper.Map<ExerciseModel>(exerxise);
        }
        public async Task<ExerciseModel> Add(ExerciseModel exerciseModel)
        {
            exerciseModel.Id = 0;
            //exerciseModel.Muscles = null;
            var ex = _mapper.Map<Exercise>(exerciseModel);
            ex=await _exerciseRepository.Add(ex);
            return _mapper.Map<ExerciseModel>(ex);
        }
        public async Task<List<ExerciseModel>> AddList(List<ExerciseModel> exerciseModels)
        {
            for (int i = 0; i < exerciseModels.Count; i++)
            {
                var ex = await Add(exerciseModels[i]);
                exerciseModels[i].Id = ex.Id;   
            }
            return exerciseModels;
        }

    }

}
