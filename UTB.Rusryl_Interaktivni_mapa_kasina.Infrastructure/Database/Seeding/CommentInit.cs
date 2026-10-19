using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database.Seeding
{
    internal class CommentInit
    {
        public IList<Comment> GetComments()
        {
            IList<Comment> comments = new List<Comment>();

            comments.Add(new Comment()
            {
                Id = 1,
                Content = "Nejlepší kasino ve městě!",
                LocationId = 2,
                UserId = 1
            });

            comments.Add(new Comment()
            {
                Id = 2,
                Content = "Obrovský výběr knih, obsluha velmi příjemná. Vřele doporučuji tohle místo navštívit!",
                LocationId = 4,
                UserId = 1
            });

            comments.Add(new Comment()
            {
                Id = 3,
                Content = "Výběr obrovský, zboží domácí, zelenina čerstvá. Prostě super místo pro nákup.",
                LocationId = 5,
                UserId = 3
            });

            return comments;
        }
    }
}