using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Entity.Dtos.OurProgramDtos
{
    public class OurProgramWithInstructorViewModel
    {
        public ResultOurProgramDto? Program { get; set; }
        public string? InstructorFullName { get; set; }
        public string? InstructorTitle { get; set; }
        public string? InstructorImageUrl { get; set; }
    }

}
