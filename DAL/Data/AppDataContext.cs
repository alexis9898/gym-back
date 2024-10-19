using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options):base(options) { }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Muscle> Muscles{ get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise>  WorkoutExercise { get; set; }
        public DbSet<WorkoutMuscle>  WorkoutMuscles{ get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscle { get; set; }
        public DbSet<Set> Sets { get; set; }  



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           
            //modelBuilder.Entity<WorkoutExercise>(entity =>
            //{
            //    entity.HasKey(x => new { x.WorkoutId, x.ExerciseId});
            //});

            modelBuilder.Entity<WorkoutMuscle>(entity =>
            {
                entity.HasKey(x => new { x.WorkoutId, x.MuscleId });
            });

            modelBuilder.Entity<ExerciseMuscle>(entity =>
            {
                entity.HasKey(x => new { x.MuscleId, x.ExerciseId });
            });

            var workoutExercise = modelBuilder.Entity<WorkoutExercise>();
            var workout = modelBuilder.Entity<Workout>();
            var exercise = modelBuilder.Entity<Exercise>();
            var muscle = modelBuilder.Entity<Muscle>();
            var set= modelBuilder.Entity<Set>();

            muscle.HasMany(x => x.Exercise).WithMany(x => x.Muscles).UsingEntity<ExerciseMuscle>();
            
            workout.HasMany(x=>x.Muscles).WithMany(x=>x.Workouts).UsingEntity<WorkoutMuscle>();
            
            workout
                .HasMany(x=>x.WorkoutExercises)
                .WithOne(x=>x.Workout)
                .HasForeignKey(x=>x.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            workoutExercise
                .HasOne(x=>x.Workout)
                .WithMany(x=>x.WorkoutExercises)
                .HasForeignKey(x=>x.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);


            workoutExercise
                .HasMany(x=>x.Sets)
                .WithOne(x=>x.WorkoutExercise)
                .HasForeignKey(x=>x.WorkoutExerciseId) 
                .OnDelete(DeleteBehavior.Cascade);
            set
                .HasOne(x=>x.WorkoutExercise)
                .WithMany(x=>x.Sets)
                .HasForeignKey(x=>x.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.Cascade);
              
            


          //  muscle.HasMany(x => x.)
          

            //workoutExercise
            //    .HasOne(x=>x.Exercise)
            //    .WithMany()
            //    .HasForeignKey(x=>x.ExerciseId)
            //    .OnDelete(DeleteBehavior.Restrict);
          
            //workout
            //    .HasMany(x=>x.WorkoutExercises)
            //    .WithOne(x=>x.Workout)
            //    .HasForeignKey(x=>x.WorkoutId)
            //    .OnDelete(DeleteBehavior.Restrict);


            //workout
            //    .HasMany(x => x.Muscles)
            //    .WithMany()
            //    .UsingEntity<WorkoutMuscle>(
            //        x=>x.HasOne(y=>y.Muscle)
            //        .WithMany()
            //    );
            //    .UsingEntity<FilmCategory>(
            //        x => x.HasOne(f => f.Category)
            //        .WithMany(x => x.FilmCategories).HasForeignKey(c => c.CategoryId),
            //        x => x.HasOne(f => f.Film)
            //        .WithMany(x => x.FilmCategories).HasForeignKey(c => c.FilmId)
            //        );





            base.OnModelCreating(modelBuilder);
        }
    }
}
