﻿using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class City: AuditableEntity, IBaseDomain
    {
        public string SehirAdi { get; set; }

    }
}
