namespace Заявки_на_доработку_ПО.Classes
{

    public class Software
    {
        public int Id { get; set; }
        public string Название { get; set; }

        public ICollection<Ticket>? Заявки { get; set; }
    }
}
