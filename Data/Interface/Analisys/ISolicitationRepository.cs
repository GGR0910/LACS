﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Analisys
{
    public interface ISolicitationRepository : IBaseRepository<Solicitation>
    {
        public Solicitation? GetSolicitation(string solicitationId);
        public List<Solicitation> GetSolicitations();
    }
}
