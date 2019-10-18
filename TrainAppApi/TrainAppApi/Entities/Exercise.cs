using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAppApi.Entities
{
    public class Exercise
    {
        public Guid ExerciseId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int RepetitionsCount { get; set; }
    }
}
