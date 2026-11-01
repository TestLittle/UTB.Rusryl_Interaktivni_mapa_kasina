using System;
using System.Collections.Generic;
using System.Text;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Repository
{
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        public CommentRepository(CasinoMapDbContext context) : base(context) {
        
        }
    }
}
