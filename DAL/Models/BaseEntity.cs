using DAL.Ābstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public abstract class BaseEntity : IBaseEntity{ 
        [Key]
        public Guid Id { get; set; }
    }
}
