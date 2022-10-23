using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Repositories;
using ChemQuizWeb.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChemQuizWeb.Services.Implementations
{
    public class AvatarService : IAvatarService
    {

        private IAvatarRepository _repository;

        public AvatarService(IAvatarRepository repository)
        {
            this._repository = repository;
        }

        public Avatar Create(Avatar avatar)
        {
            try
            {
                _repository.Add(avatar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return avatar;
        }

        public void Delete(long Id)
        {
            try
            {
                Avatar avatar = _repository.Find(Id);
                _repository.Remove(avatar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Avatar> FindAll()
        {
            return _repository.List().ToList();
        }

        public Avatar FindByID(long Id)
        {
            return _repository.Find(Id);
        }

        public Avatar Update(Avatar avatar)
        {
            if (!Exists(avatar.AvatarId)) return null;
            try
            {
                _repository.Edit(avatar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return avatar;
        }

        public bool Exists(long Id)
        {
            return _repository.List().Any(x => x.AvatarId.Equals(Id));
        }

    }
}
