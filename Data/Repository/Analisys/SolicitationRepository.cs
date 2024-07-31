using Data.Context;
using Data.Interface.Analisys;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Analisys
{
    public class SolicitationRepository : BaseRepository<Solicitation>, ISolicitationRepository
    {
        public SolicitationRepository(DataContext baseContext) : base(baseContext)
        {

        }

        public Solicitation? GetSolicitation(string solicitationId)
        {
            return _context.Solicitation.Include(s => s.Samples)
                 .ThenInclude(sa => sa.SamplePhisicalState)
                 .Include(s => s.Samples)
                 .ThenInclude(sa => sa.SampleType)
                 .Include(s => s.AnalisysType).FirstOrDefault(s => s.Id == solicitationId);
        }

        public List<Solicitation> GetSolicitations()
        {
            List<Solicitation> solicitations = _context.Solicitation.Where(s => !s.Deleted && s.ExpectedCompletionDate == null).ToList();
            List<User> users = _context.Users.ToList();
            List<Sample> samples = _context.Sample.ToList();
            List<SolicitationType> solicitationTypes = _context.SolicitationTypes.ToList();
            List<AnalisysType> analisysTypes = _context.AnalisysTypes.ToList();

            foreach (var solicitation in solicitations)
            {
                solicitation.Samples = samples.Where(s => s.SolicitationId == solicitation.Id).ToList();
                solicitation.Requester = users.FirstOrDefault(u => u.Id == solicitation.RequesterId);
                solicitation.AnalisysType = analisysTypes.FirstOrDefault(a => a.Id == solicitation.AnalisysTypeId);
                solicitation.SolicitationType = solicitationTypes.FirstOrDefault(st => st.Id == solicitation.SoliciationTypeId);
            }


            return solicitations;
        }
    }
}
