using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Services.Implementations
{
    public class AvatarService : IService<Avatar>
    {

        private ApplicationDbContext Context;

        public AvatarService(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public Avatar Create(Avatar avatar)
        {
            try
            {
                Context.Add(avatar);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return avatar;
        }

        public Avatar Delete(long Id)
        {
            var result = Context.Avatar.SingleOrDefault(x => x.AvatarId == Id);
            if (result != null)
            {
                try
                {
                    Context.Avatar.Remove(result);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public IEnumerable<Avatar> FindAll()
        {
            return Context.Avatar.ToList();
        }

        public Avatar FindByID(long Id)
        {
            return Context.Avatar
                .SingleOrDefault(x => x.AvatarId.Equals(Id));
        }

        public Avatar Update(Avatar avatar)
        {
            if (!Exists(avatar.AvatarId)) return null;
            var result = Context.Avatar.SingleOrDefault(x => x.AvatarId == avatar.AvatarId);
            if (result != null)
            {
                try
                {
                    //verificar se nao precisa usar USING
                    Context.Entry(result).CurrentValues.SetValues(avatar);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public bool Exists(long Id)
        {
            return Context.Avatar.Any(x => x.AvatarId.Equals(Id));
        }

    }
}
