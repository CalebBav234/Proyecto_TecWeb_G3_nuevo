using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _repo;

        public CertificateService(ICertificateRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Certificate>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Certificate?> GetOne(Guid id)
        {
            try
            {
                return await _repo.GetOne(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task Add(Certificate certificate)
        {
            certificate.Id = Guid.NewGuid();
            await _repo.Add(certificate);
        }

        public async Task Update(Certificate certificate)
        {
            var existing = await GetOne(certificate.Id);
            if (existing == null) throw new Exception($"Certificate with ID {certificate.Id} not found.");

            existing.StudentId = certificate.StudentId;
            existing.Title = certificate.Title;
            existing.Description = certificate.Description;

            await _repo.Update(existing);
        }

        public async Task Delete(Certificate certificate)
        {
            await _repo.Delete(certificate);
        }

        public async Task<IEnumerable<Certificate>> GetByStudentId(Guid studentId)
        {
            return await _repo.GetByStudentId(studentId);
        }

        public async Task<Certificate?> GetByTitle(string title)
        {
            try
            {
                return await _repo.GetByTitle(title);
            }
            catch
            {
                return null;
            }
        }
    }
}
