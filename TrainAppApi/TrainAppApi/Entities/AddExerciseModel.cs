using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAppApi.Entities
{
    public class AddExerciseModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int RepetitionsCount { get; set; }
    }
}
