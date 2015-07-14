using CrudEmployeeApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CrudEmployeeApi.Repository
{
    public class UnitOfWork : IDisposable
    {
        private EntityContext _context = null;
        private GenericRepository<Employee> _employeeRepository;

        public UnitOfWork()
        {
            _context = new EntityContext();
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                {
                    this._employeeRepository = new GenericRepository<Employee>(_context);
                }
                return _employeeRepository;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorOuput = new List<string>();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    errorOuput.Add(string.Format("{0} - Entity of type {1} - in state {2} has the folowing validations error:",
                        DateTime.Now, eve.Entry.Entity.GetType(), eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorOuput.Add(string.Format("Property: {0} - error: {1}", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines("D:/errors.txt", errorOuput);
                throw ex;
            }
        }

        // Implemeting IDisposable
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}