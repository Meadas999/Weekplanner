using InterfaceLibrary;

namespace DALMemoryStore
{
    public class ActiviteitenMSDAL : IActiviteitenContainer
    {
        private readonly List<ActiviteitDTO> _activiteiten = new();
        public ActiviteitenMSDAL(int aantal)
        {
            FillActList(aantal);
        }
        private void FillActList(int aantal)
        {
            for (int i = 1; i < aantal +1 ; i++)
            {
                _activiteiten.Add(new ActiviteitDTO(i, "Training", "Training", "Training", DateTime.Now));
            }
            _activiteiten.Add(new ActiviteitDTO(13, "Training", "Training", "Training", DateTime.Now));
            _activiteiten.Add(new ActiviteitDTO(13, "Training1", "Training1", "Training", DateTime.Now));
            _activiteiten.Add(new ActiviteitDTO(13, "Training2", "Training2", "Training", DateTime.Now));
        }
        public void AddActivityToUserWithDayOnly(int id, ActiviteitDTO activiteit)
        {
            _activiteiten.Add(activiteit);
        }
        public List<ActiviteitDTO> GetAllEvents(int id)
        {
            List<ActiviteitDTO> act = new();
            foreach (ActiviteitDTO item in _activiteiten)
            {
                if (item.Id == id)
                {
                    act.Add(item);
                }
            }
            return act;
        }
        public void UpdateActivityWithDayOnly(ActiviteitDTO activiteit, int id) 
        {
            foreach(ActiviteitDTO item in _activiteiten)
            {
                if(item.Id == activiteit.Id)
                {
                    item.Name = activiteit.Name;
                    item.Type = activiteit.Type;
                    item.Description = activiteit.Description;
                    item.Date = activiteit.Date;
                }
            }
        }
        public ActiviteitDTO GetActivityById(int id)
        {
            foreach (ActiviteitDTO item in _activiteiten)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public void DeleteActivityById(int id) 
        {
            foreach (ActiviteitDTO item in _activiteiten.ToList())
            {
                if(item.Id == id)
                {
                    _activiteiten.Remove(item);
                }
            }
        }
    }
}