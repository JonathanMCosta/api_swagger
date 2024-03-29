﻿using API.Data.Context;
using API.Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        #region [ DeleteAsync ]
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ InsertAsync ]
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
        #endregion

        #region [ ExistAsync ]
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }
        #endregion

        #region [ SelectAsync ]
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ UpdateAsync ]
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }
                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
        #endregion
    }
}
