
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.Implementation
{
    public class CommentAppService : ICommentAppService
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

        public void Create(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            Comment? comment = _commentRepository.GetById(id);
            if(comment != null)
            {
                _commentRepository.Delete(comment);
                deleted = true;
            }
            return deleted;
        }
    }
}
