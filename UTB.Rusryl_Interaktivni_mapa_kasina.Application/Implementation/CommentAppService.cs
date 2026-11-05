
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class CommentAppService
    {
        ICommentRepository _commentRepository;

        public CommentAppService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IList<Comment> SelectAll()
        {
            return _commentRepository.GetAll().ToList();
        }
    }
}
