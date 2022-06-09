using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class ViolationActors
    {
        public Guid Id { get; set; }
        public string IdNO { get; set; }
        public string Name { get; set; }
        public string ActorGroup { get; set; }
        public bool ISNMDT { get; set; }
        public string ActorNameId { get; set; }
    }
}
