using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYSL.Web.ViewModels.Pet
{
    public class PetListDto
    {
        public IEnumerable<PetDto> PetViewList { get; set; }
    }
}
