using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ExerciseRepository: IExerciseRepository
    {
        private readonly AppDataContext _context;

        public ExerciseRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<Exercise> Get(int id)
        {
            return await _context.Exercises.Where(x=>x.Id==id).FirstOrDefaultAsync();
        }
        public async  Task<List<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }
        public async Task<Exercise> Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }
        public async Task Set(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            return;
        }
        public async Task Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return;
        }


    }
}
