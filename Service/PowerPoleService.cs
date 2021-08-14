using Domain.Models;
using Domain.Models.Interfaces;
using Infrastructure;
using Infrastructure.Interfaces;
using Service.Common;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PowerPoleService : IPowerPoleService
    {
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversityLocalContext _universityLocalContext;

        public PowerPoleService(IModelDataAnnotationCheck modelDataAnnotationCheck, IUnitOfWork unitOfWork, IUniversityLocalContext universityLocalContext)
        {
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
            _unitOfWork = unitOfWork;
            _universityLocalContext = universityLocalContext;
        }

        public void AddPowerPole(string address,
                               string latitude,
                               string powerWire,
                               string streetLight)
        {
            var powerPole = new PowerPole
            {
                Address = address,
                Latitude = latitude,
                PowerWire = powerWire,
                StreetLight = streetLight
            };

            ValidateModelDataAnnotations(powerPole);

            //DB
            try
            {
                _unitOfWork.PowerPoleRepository.Add(powerPole);
            }
            catch
            {
                _unitOfWork.RejectChanges();
            }

            _unitOfWork.Commit();

            //LOCAL
            try
            {
                var id = _universityLocalContext.PowerPoles.Count + 1;
                powerPole.Id = id;
                _universityLocalContext.PowerPoles.Add(powerPole);
            }
            catch { }
        }

        public void DeleteStudent(int id)
        {
            var student = (from s in _unitOfWork.StudentRepository.Entities
                           where s.Id.Equals(id)
                           select s).First();

            _unitOfWork.StudentRepository.Remove(student);
            _unitOfWork.Commit();
        }

        public void DeleteStudentFromLocalRepository(int id)
        {
            var student = (from s in _universityLocalContext.Students
                           where s.Id.Equals(id)
                           select s).First();

            _universityLocalContext.Students.Remove(student);
        }

        public ICollection<Student> GetAll()
        {
            return _unitOfWork.StudentRepository.Entities.ToList();
        }

        public IStudent GetById(int id)
        {
            return (from s in _unitOfWork.StudentRepository.Entities
                    where s.Id.Equals(id)
                    select s).First();
        }

        public void ValidateModelDataAnnotations(IPowerPole powerPole)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(powerPole);
        }
    }
}
