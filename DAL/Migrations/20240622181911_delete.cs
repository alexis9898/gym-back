using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutExercise_WorkoutExerciseId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutExercise_WorkoutExerciseId",
                table: "Sets",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutExercise_WorkoutExerciseId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutExercise_WorkoutExerciseId",
                table: "Sets",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
