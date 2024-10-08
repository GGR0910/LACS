﻿using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Interface;

namespace Data.Repository
{
    public class SolicitationRepository : BaseRepository<Solicitation>, ISolicitationRepository
    {
        public SolicitationRepository(DataContext baseContext) : base(baseContext)
        {

        }

        public Result<Solicitation> GetSolicitation(string solicitationId)
        {
            Result<Solicitation> result = new Result<Solicitation>();
            Solicitation? solicitation = _context.Solicitation
                .Include(s => s.Samples)
                .ThenInclude(s => s.Analist)
                .Include(s => s.Samples)
                .Include(s => s.Samples)
                .Include(s => s.SolicitationType)
                .FirstOrDefault(x => x.Id == solicitationId);


            if (solicitation == null)
                result.Message = "Solicitation not found.";
            else
            {
                result.Return = solicitation;
                result.Success = true;
            }

            return result;
        }

        public Task<DataTableReturn<Solicitation>> GetSolicitations(int page, int pageSize, string? requesterId, int? solicitationTypeId, int? analisysTypeId, bool? resultsDelivered, DateTime? initialDate, DateTime? finalDate)
        {
            IQueryable<Solicitation> solicitations = _context.Solicitation
                .Include(s => s.Samples)
                .ThenInclude(s => s.Analist)
                .Include(s => s.Samples)
                .Include(s => s.Samples)
                .Include(s => s.SolicitationType)
                .Where(s => !s.Deleted && s.ExpectedCompletionDate == null);

            int recordsTotal = solicitations.Count();


            if (solicitationTypeId.HasValue)
                solicitations = solicitations.Where(s => s.SoliciationTypeId == solicitationTypeId);


            if (resultsDelivered.HasValue)
                solicitations = solicitations.Where(s => s.ResultsDelivered == resultsDelivered);

            if (initialDate.HasValue)
                solicitations = solicitations.Where(s => s.CreatedAt >= initialDate);

            if (finalDate.HasValue)
                solicitations = solicitations.Where(s => s.CreatedAt <= finalDate);

            solicitations = solicitations.OrderBy(s => s.ExpectedCompletionDate).Skip((page - 1) * pageSize).Take(pageSize);

            DataTableReturn<Solicitation> dataTableReturn = new DataTableReturn<Solicitation>()
            {
                Data = solicitations.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = solicitations.Count(),
                Page = page
            };

            return Task.FromResult(dataTableReturn);
        }
    }
}
