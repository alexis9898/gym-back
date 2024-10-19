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
    public class MuscleService:IMuscleService
    {
        private readonly IMuscleRepository _muscleRepository;
        private readonly IMapper _mapper;

        public MuscleService(IMuscleRepository muscleRepository,IMapper mapper)
        {
            _muscleRepository = muscleRepository;
            _mapper = mapper;
        }

        public async Task<MuscleModel> Get(int id)
        {
            var muscle=await _muscleRepository.Get(id);
            if (muscle == null) return null;
            return _mapper.Map<MuscleModel>(muscle);
        }

        public async Task<List<MuscleModel>> GetAll()
        {
            var list = await _muscleRepository.GetAll();
            return _mapper.Map<List<MuscleModel>>(list); 
        }
        public async Task<MuscleModel> Add(MuscleModel  muscleModel)
        {

            muscleModel.Exercise = null;
            muscleModel.Id = 0;
            var muscle = _mapper.Map<Muscle>(muscleModel);
            muscle=await _muscleRepository.Add(muscle);
            return _mapper.Map<MuscleModel>(muscle);

        }

        public async Task<MuscleModel> Set(MuscleModel muscleModel)
        {
            var muscle = await _muscleRepository.Get(muscleModel.Id);
            if (muscle == null) return null;
            muscle.Name = muscleModel.Name;
            await _muscleRepository.Set(muscle);
            return muscleModel;
        }
        public async Task<bool> Delete(int id)
        {
            var muscle = await _muscleRepository.Get(id);
            if (muscle == null) return false;
            await _muscleRepository.Delete(muscle);
            return true;
        }


    }
}
