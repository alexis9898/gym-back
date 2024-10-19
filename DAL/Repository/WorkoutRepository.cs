using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace DAL.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDataContext _context;

        public WorkoutRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<Workout> GetWithInfo(int Id)
        {
            var w=await _context.Workouts.Where(o=>o.Id==Id)
                .Include(x => x.Muscles)
                .Include(x => x.WorkoutExercises)
                    .ThenInclude(y => y.Exercise)
                .Include(x => x.WorkoutExercises)
                    .ThenInclude(y => y.Sets)
                .FirstOrDefaultAsync();
                    return w;
        }
        public async Task<Workout> Get(int Id)
        {
            return  await _context.Workouts.Where(o => o.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<Workout> Add(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }

        public async Task Set(Workout workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Delete(Workout workout)
        {
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return;
        }
 
        //public async Task UpdateComments(List<Comment> comments, CompanyNames company)
        //     var context = _companyDataProvider.GetContext(company);

        //var existingComments = await context.Comments
        //    .Where(c => comments.Select(c => c.Id).Contains(c.Id))
        //    .ToDictionaryAsync(
        //    c => c.Id, a => a);

        //    foreach (var comment in comments)
        //    {
        //        if (existingComments.TryGetValue(comment.Id, out var existingComment))   
        //        {
        //            context.Comments.Update(existingComment);

        //        }
        //        else
        //        {
        //            context.Comments.Add(comment);      
        //        }
        //    await context.SaveChangesAsync();
        //    }
        //}
    }
}
