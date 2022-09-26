using Sailboat_Rental.Model;
using SailBoat_Rental.Repository;

namespace SailBoat_Rental.Service
{
    public class BoatService
    {
        private BoatRepository boatRepository;

        public BoatService(BoatRepository boatRepository)
        {
            this.boatRepository = boatRepository;  
        }

        public Boat Create(Boat boat)
        {
            return this.boatRepository.Create(boat);
        }

        public List<Boat> GetBoats()
        {
            return this.boatRepository.GetBoats();
        }
        public List<Boat> GetBoatsByLessor(string lessorId)
        {
            return this.boatRepository.GetBoatByLessorId(lessorId);
        }
        public List<Boat> GetBoat(string lessorId,string categoryId)
        {
            return (this.boatRepository.GetBoat(lessorId, categoryId));
        }

    }
}
