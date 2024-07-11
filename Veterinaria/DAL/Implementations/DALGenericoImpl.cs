using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private VeteProV2Context _veteProV2Context;

        public DALGenericoImpl(VeteProV2Context veteProV2Context)
        {

            _veteProV2Context = veteProV2Context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _veteProV2Context.Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(int id)
        {

            return _veteProV2Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _veteProV2Context.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _veteProV2Context.Set<TEntity>().Attach(entity);
                _veteProV2Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _veteProV2Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
