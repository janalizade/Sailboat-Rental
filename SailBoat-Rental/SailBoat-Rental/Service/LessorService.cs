using Sailboat_Rental.Model;
using SailBoat_Rental.Repository;

namespace SailBoat_Rental.Service
{
    public class LessorService
    {
        private LessorRepository lessorRepository;

        public LessorService(LessorRepository lessorRepository)
        {
            this.lessorRepository = lessorRepository;
        }

        public Lessor Create(Lessor lessor)
        {
            return this.lessorRepository.Create(lessor);
        }

        public List<Lessor> GetLessors()
        {
            return lessorRepository.GetLessors();
        }
    }
}