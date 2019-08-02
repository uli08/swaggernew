using Microsoft.EntityFrameworkCore;
using Model;
using Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        bool Add(Employee model);
        bool Delete(int id);
        bool Update(Employee model);
        Employee Get(int id);
        
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbcontext _EmployeeDbcontext;

        public EmployeeService(EmployeeDbcontext EmployeeDbcontext)
        {
            _EmployeeDbcontext = EmployeeDbcontext;
        }

        ////////////////////////////////////////////////////////////////////////////////
        ///
        public IEnumerable<Employee> GetAll()//(Employee model)
        {
            var result = new List<Employee>();

            try
            {
                result = _EmployeeDbcontext.Employee.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public Employee Get(int id)
        {
            var result = new Employee();

            try
            {
                result = _EmployeeDbcontext.Employee.Single(x => x.EmployeeId == id);
            }
            catch (System.Exception)
            {

            }

            return result; 
        }


        public bool Add(Employee model)
        {
            try
            {
                _EmployeeDbcontext.Add(model);
                _EmployeeDbcontext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Employee model)
        {
            try
            {
                var originalModel = _EmployeeDbcontext.Employee.Single(x =>x.EmployeeId == model.EmployeeId);

                
                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.Bio = model.Bio;

                _EmployeeDbcontext.Update(originalModel);
                _EmployeeDbcontext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }


        public bool Delete(int id)
        {
            try
            {
                _EmployeeDbcontext.Entry(new Employee { EmployeeId = id }).State = EntityState.Deleted; ;
                _EmployeeDbcontext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

    

    }
}
