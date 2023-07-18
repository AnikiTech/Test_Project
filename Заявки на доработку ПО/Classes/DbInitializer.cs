namespace Заявки_на_доработку_ПО.Classes
{
    public class DbInitializer
    {
        public static void Initialize(SoftwareTicketsContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.Tickets.Any())
            {
                return;   
            }

            
            var ПО = Enumerable.Range(1, 20).Select(i => new Software { Название = $"ПО{i}" }).ToArray();
            context.Software.AddRange(ПО);
            context.SaveChanges();

            var ПО_ids = ПО.Select(p => p.Id).ToArray();

            var Заявки = Enumerable.Range(1, 20).Select(i => new Ticket
            {
                IdПО = ПО_ids[i - 1],
                Название = $"Заявка{i}",
                Email = $"email{i}@example.com",
                Описание = $"Описание{i}",
                ДатаОкончанияРазработки = DateTime.Now.AddDays(i)
            }).ToArray();

            context.Tickets.AddRange(Заявки);
            context.SaveChanges();
        }
    }

}
